using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Nola.Core.Models.Question;
using Nola.Service.Services;
using Nola.ViewModels.Question;

namespace Nola.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService questionService;

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }
        // GET: Question
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult ManageQuestions()
        {
            var list = Mapper.Map<IEnumerable<ShortQuestionViewModel>>(questionService.GetAll());
            return View(list);
        }

        public ActionResult QuestionsList()
        {
            var list = Mapper.Map<IEnumerable<ShortQuestionViewModel>>(questionService.GetAll());
            return PartialView("_QuestionsList", list);
        }

        [HttpGet]
        public ActionResult Edit(int? id, QuestionType? type)
        {
            if (id == null)
            {       
                switch (type)
                {
                    case QuestionType.SingleAnswer:
                        return PartialView("_SingleAnswerQuestionEdit", new SingleAnswerQuestion());
                    case null:
                        return ErrorPage("Некорректные параметры запроса");
                }
            }
            else
            {
                var question = questionService.GetQuestion(id.Value);
                return FindQuestionView(question);               
            }
            return ErrorPage("Некорректные параметры");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSingleAnswer(SingleAnswerQuestion question)
        {
            if (ModelState.IsValid)
            {
                if(question.Id == 0)
                    questionService.AddQuestion(question);
                else
                    questionService.UpdateQuestion(question);
                questionService.Commit();
                return QuestionsList();
            }
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return PartialView("_SingleAnswerQuestionEdit", question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BaseQuestion question)
        {
            if (ModelState.IsValid)
            {
                questionService.DeleteQuestion(question);
                questionService.Commit();
                return QuestionsList();
            }
            return ErrorPage("Некорректные параметры");
        }

        private ActionResult FindQuestionView(BaseQuestion question)
        {
            if (question == null)
            {
                return ErrorPage("Вопроса не существует");
            }
            if (question is SingleAnswerQuestion)
                return PartialView("_SingleAnswerQuestionEdit", (SingleAnswerQuestion) question);
            return ErrorPage("Некорректные параметры");
        }

        private ActionResult ErrorPage(string message)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView("Error", message);
        }
    }
}
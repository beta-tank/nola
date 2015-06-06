using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Edit(int? id, QuestionType? type)
        {
            if (id == null)
            {       
                switch (type)
                {
                    case QuestionType.SingleAnswer:
                        return PartialView("_SingleAnswerQuestionEdit", new SingleAnswerQuestion());
                    case null:
                        return PartialView("Error", "Некорректные параметры запроса");
                }
            }
            else
            {
                var question = questionService.GetQuestion(id.Value);
                if(question == null)
                    return PartialView("Error", "Вопроса не существует");
                if(question is SingleAnswerQuestion)
                    return PartialView("_SingleAnswerQuestionEdit", question as SingleAnswerQuestion);               
            }
            return PartialView("Error", "Некорректные параметры");
        }
    }
}
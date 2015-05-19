namespace Nola.Core.Models.Users
{
    public static class ClaimTypes
    {
        public static string Permission = "UserHasPermission";
    }

    public static class ClaimPermissionTypes
    {
        public static string AddTest = "UserCanAddTest";
        public static string DoTest = "UserCanDoTest";
        public static string PartisipateInOlimpiad = "UserCanPartisipateInOlimpiad";
    }
}
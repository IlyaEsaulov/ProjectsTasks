using System.Web.Routing;

namespace ProjectTasks
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("default", "", "~/Views/TaskList.aspx");
        }
    }
}
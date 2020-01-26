using ProjectTasks.Controllers;
using ProjectTasks.Models;
using System;
using System.Web.UI.WebControls;

namespace ProjectTasks.Views
{
    public partial class TaskList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                TasksControllers tasks = new TasksControllers();
                ListTask.DataSource = tasks.TaskList();
                ListTask.DataBind();
        }

        protected void DeleteTask(object sender, EventArgs e)
        {
            Tasks tasks = new Tasks();
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            tasks.Id = Id;
            TasksControllers tasksControllers = new TasksControllers();
            tasksControllers.Delete(tasks);
            Page_Load(sender, e);
        }

        protected void UpdateTask(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect(string.Format("Task.aspx?id={0}", Id));
        }

        protected void CreateNewTask_Click(object sender, EventArgs e)
        {
            Response.Redirect("Task.aspx");
        }
    }
}
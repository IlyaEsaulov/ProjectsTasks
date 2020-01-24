using ProjectTasks.Controllers;
using ProjectTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTasks.Views
{
    public partial class Task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                TasksControllers tasksControllers = new TasksControllers();
                if (Id != 0)
                {
                    string getInfo = tasksControllers.GetTask(Id);
                    string[] val = getInfo.Split(new char[] { '|' });
                    id.Text = val[0];
                    title.Text = val[1];
                    workload.Text = val[2];
                    dateStart.Text = val[3];
                    dateFinish.Text = val[4];
                    status.Text = val[5];
                    DropDownList1.SelectedValue = val[6];
                    buttonAdd.Visible = false;
                    buttonEdit.Visible = true;
                }
                else
                {
                    buttonAdd.Visible = true;
                    buttonEdit.Visible = false;
                }
                IEnumerable<Persons> data = tasksControllers.PersonDataView();
                List<Persons> list = data.ToList();
                foreach (Persons p in list)
                {
                    ListItem li = new ListItem();
                    li.Text = p.Name + " "+ p.Surname +" " + p.Fathername;
                    li.Value = Convert.ToString(p.Id);
                    DropDownList1.Items.Add(li);
                }
                
            }
        }
        protected void AddTask(object sender, EventArgs e)
        {
            Tasks task = new Tasks
            {
                Title = title.Text,
                Workload = workload.Text,
                DateStart = Convert.ToDateTime(dateStart.Text),
                DateFinish = Convert.ToDateTime(dateFinish.Text),
                Status = status.Text,
                IdPerson = Convert.ToInt32(DropDownList1.SelectedValue)
            };

            TasksControllers tasksControllers = new TasksControllers();
            tasksControllers.Add(task);
            Response.Redirect("TaskList.aspx");
        }

        protected void EditTask(object sender, EventArgs e)
        {
            Tasks task = new Tasks
            {
                Id=Convert.ToInt32(id.Text),
                Title = title.Text,
                Workload = workload.Text,
                DateStart = Convert.ToDateTime(dateStart.Text),
                DateFinish = Convert.ToDateTime(dateFinish.Text),
                Status = status.Text,
                IdPerson = Convert.ToInt32(DropDownList1.SelectedValue)
            };

            TasksControllers tasksControllers = new TasksControllers();
            tasksControllers.Add(task);
            Response.Redirect("TaskList.aspx");
        }
    }
}
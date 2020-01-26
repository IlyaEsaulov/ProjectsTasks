using ProjectTasks.Controllers;
using ProjectTasks.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
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
                IEnumerable<Persons> data = tasksControllers.PersonDataView();
                List<Persons> list = data.ToList();
                foreach (Persons p in list)
                {
                    ListItem ddList = new ListItem
                    {
                        Text = p.Name + " " + p.Surname + " " + p.Fathername,
                        Value = Convert.ToString(p.Id)
                    };
                    PersonsList.Items.Add(ddList);
                }
                if (Id != 0)
                {
                    string getInfo = tasksControllers.GetTask(Id);
                    string[] val = getInfo.Split(new char[] { '|' });
                    id.Text = val[0];
                    title.Text = val[1];
                    workload.Text = val[2];
                    DateTime dtStart = DateTime.ParseExact(val[3], "dd.MM.yyyy h:mm:ss", CultureInfo.InvariantCulture);
                    DateTime dtFinish = DateTime.ParseExact(val[4], "dd.MM.yyyy h:mm:ss", CultureInfo.InvariantCulture);
                    dateStart.Text = dtStart.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture);
                    dateFinish.Text = dtFinish.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); ;
                    StatusList.SelectedItem.Text = val[5];
                    PersonsList.SelectedValue = val[6];
                    buttonAdd.Visible = false;
                    buttonEdit.Visible = true;
                }
                else
                {
                    buttonAdd.Visible = true;
                    buttonEdit.Visible = false;
                }
            }
        }
        protected void AddTask(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DateTime dtStart = DateTime.ParseExact(dateStart.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime dtFinish = DateTime.ParseExact(dateFinish.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                Tasks task = new Tasks
                {
                    Title = title.Text,
                    Workload = Convert.ToInt32(workload.Text),
                    DateStart = Convert.ToDateTime(dtStart.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture).ToString()),
                    DateFinish = Convert.ToDateTime(dtFinish.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture).ToString()),
                    Status = StatusList.SelectedItem.Text,
                    IdPerson = Convert.ToInt32(PersonsList.SelectedValue)
                };

                TasksControllers tasksControllers = new TasksControllers();
                tasksControllers.Add(task);
                Response.Redirect("TaskList.aspx");
            }
            else
            {
                status.ForeColor = Color.Red;
                status.Text = "Validation Failed!";
            }
        }

        protected void EditTask(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                DateTime dtStart = DateTime.ParseExact(dateStart.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime dtFinish = DateTime.ParseExact(dateFinish.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                Tasks task = new Tasks
                {
                    Id = Convert.ToInt32(id.Text),
                    Title = title.Text,
                    Workload = Convert.ToInt32(workload.Text),
                    DateStart = Convert.ToDateTime(dtStart.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)),
                    DateFinish = Convert.ToDateTime(dtFinish.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture)),
                    Status = StatusList.SelectedItem.Text,
                    IdPerson = Convert.ToInt32(PersonsList.SelectedValue)
                };

                TasksControllers tasksControllers = new TasksControllers();
                tasksControllers.Update(task);
                Response.Redirect("TaskList.aspx");
            }
            else
            {
                status.ForeColor = Color.Red;
                status.Text = "Validation Failed!";
            }
        }
    }
}
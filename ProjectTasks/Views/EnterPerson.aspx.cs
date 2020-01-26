using ProjectTasks.Controllers;
using ProjectTasks.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTasks.Views
{
    public partial class EnterPerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                if (Id != 0)
                {
                    PersonsController persons = new PersonsController();
                    string data = persons.GetPerson(Id);
                    string[] val = data.Split(new char[] { ' ' });
                    id.Text = val[0];
                    name.Text = val[1];
                    surname.Text = val[2];
                    fathername.Text = val[3];
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

        protected void AddPerson(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Persons persons = new Persons
                {
                    Name = name.Text,
                    Surname = surname.Text,
                    Fathername = fathername.Text
                };

                PersonsController personsController = new PersonsController();
                personsController.Add(persons);
                Response.Redirect("PersonList.aspx");
            }
            else
            {
                status.ForeColor = Color.Red;
                status.Text = "Validation Failed!";
            }
        }

        protected void EditPerson(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Persons persons = new Persons
                {
                    Id = Convert.ToInt32(id.Text),
                    Name = name.Text,
                    Surname = surname.Text,
                    Fathername = fathername.Text
                };
                PersonsController personsController = new PersonsController();
                personsController.Update(persons);
                Response.Redirect("PersonList.aspx");
            }
            else
            {
                status.ForeColor = Color.Red;
                status.Text = "Validation Failed!";
            }
        }
    }
}
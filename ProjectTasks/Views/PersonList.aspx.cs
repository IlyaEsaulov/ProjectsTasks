using ProjectTasks.Controllers;
using ProjectTasks.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectTasks.Views
{
    public partial class PersonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                PersonsController persons = new PersonsController();
                ListPerson.DataSource = persons.PersonsList();
                ListPerson.DataBind();

        }

        protected void DeletePerson(object sender, EventArgs e)
        {
            Persons persons = new Persons();
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            persons.Id = Id;
            PersonsController personsController = new PersonsController();
            personsController.Delete(persons);
            Page_Load( sender,  e);
        }

        protected void UpdatePerson(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Response.Redirect(string.Format("EnterPerson.aspx?id={0}", Id));

        }

        protected void CreateNewPerson_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnterPerson.aspx");
        }

    }
}
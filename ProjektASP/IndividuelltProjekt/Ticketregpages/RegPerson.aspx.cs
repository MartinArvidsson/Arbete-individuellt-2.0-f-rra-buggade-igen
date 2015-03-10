using IndividuelltProjekt.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltProjekt.Ticketregpages
{
    public partial class RegPerson : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get
            {
                return _service ?? (_service = new Service());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Person> PersonListView_GetData()
        {
            return Service.GetPersons();

        }

        public void PersonListView_InsertItem(Person person)
        {
            Service.SavePerson(person);
        }
        public void PersonListView_DeleteItem(int PersonID)
        {
            Service.DeletePerson(PersonID);
        }

        public void PersonListView_UpdateItem(int personID)
        {
            //try
            //{
                var person = Service.GetPerson(personID);
                if (person == null)
                {
                    throw new NotImplementedException();

                    //ModelState.AddModelError(String.Empty,
                    //    String.Format("Kunden med kundnummer {0} hittades inte.", personID));
                    //return;
                }

                if (TryUpdateModel(person))
                {
                    //Session["ValidationSession"] = "Du har Uppdaterat kontakten";
                    //Response.Redirect("Default.aspx");

                    Service.SavePerson(person);
                }
            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            //}
        }
    }
}
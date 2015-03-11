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
            if (Session["ValidationSession"] != null)
            {
                MessagePlaceholder.Visible = true;
                ConfirmationLabel.Text = Session["ValidationSession"] as string;

                Session["ValidationSession"] = null;
            }
        }

        public IEnumerable<Person> PersonListView_GetData()
        {
            return Service.GetPersons();

        }

        public void PersonListView_InsertItem(Person person)
        {
            try
            {
                Service.SavePerson(person);
                Session["ValidationSession"] = "Du har lagt till kontakten";

            }
            catch (Exception)
            {
                
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Personuppgiften skulle Tas Läggas till.");
            }
        }
        public void PersonListView_DeleteItem(int PersonID)
        {
            try
            {
                Service.DeletePerson(PersonID);
                Session["ValidationSession"] = "Du har tagit bort kontakten";
            }
            catch (Exception)
            {
                
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Personuppgiften skulle Tas bort.");
            }
        }

        public void PersonListView_UpdateItem(int personID)
        {
            try
            {
                var person = Service.GetPerson(personID);
                if (person == null)
                {
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte.", personID));
                    return;
                }

                if (TryUpdateModel(person))
                {     
                    Service.SavePerson(person);
                    Session["ValidationSession"] = "Du har Uppdaterat kontakten";
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Personuppgiften skulle uppdateras.");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:61141/Ticketregpages/ChooseTicket.aspx");
        }


    }
}
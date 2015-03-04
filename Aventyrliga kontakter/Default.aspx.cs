using Aventyrliga_kontakter.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aventyrliga_kontakter
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ValidationSession"] != null)
            {
                ConfirmationLabel.Text = Session["ValidationSession"] as string;

                Session["ValidationSession"] = null;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Contact> ContactListView_GetData(int maximumRows , int startRowIndex, out int totalRowCount)
        {
            return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                Session["ValidationSession"] = "Du har lagt till kontakten";
                Response.Redirect("Default.aspx");

                    Service.SaveContact(contact);
                //}
                //catch (Exception) //Undantaget som kastas i Service.cs, Mer specifikt Service.SaveContact
                //{
                //    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle läggas till.");
                //}
            }
        }

        
        public void ContactListView_UpdateItem(int contactId)
        {
            //try
            //{
                var contact = Service.GetContact(contactId);
                if (contact == null)
                {
                    

                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte.", contactId));
                    return;
                }

                if (TryUpdateModel(contact))
                {
                    Session["ValidationSession"] = "Du har Uppdaterat kontakten";
                    Response.Redirect("Default.aspx");
                    Service.SaveContact(contact);
                }
            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            //}
        }

        public void ContactListView_DeleteItem(int contactId)
        {
            //try
            //{
            Session["ValidationSession"] = "Du har tagit bort kontakten";
            Response.Redirect("Default.aspx");
                Service.DeleteContact(contactId);
            //}
            //catch (Exception )
            //{
            //    ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle tas bort.");
            //}
        }
    }
}
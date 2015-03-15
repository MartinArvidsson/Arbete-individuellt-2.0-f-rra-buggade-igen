using IndividuelltProjekt.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltProjekt.Ticketregpages
{
    public partial class ChooseTicket : System.Web.UI.Page
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

        public IEnumerable<Ticket>TicketListView_GetData()
        {
            return Service.GetTickets();
        }

        public void TicketListView_AddFaktura(object sender, EventArgs e)
        {
            try
            {
            LinkButton btn = (LinkButton)(sender);
                 string BiljettID = btn.CommandArgument;
                    
               

                Response.RedirectToRoute("FinishReg", new { id2 = BiljettID });
            
            Session["ValidationSession"] = string.Format("Du Valde Biljett nummer:{0} för registrering, Tryck på avsluta registering för att bli klar.", BiljettID);
            }
            catch(Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Fakturan skulle skapas.");
            }
        }
    }
}
using IndividuelltProjekt.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltProjekt.Ticketregpages
{
    public partial class FinishReg : System.Web.UI.Page
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

        public IEnumerable<Person> Transactionview_GetData([RouteData] int id, [RouteData] int id2)
        {
            Label PersonLabel = (Label)Transactionview.FindControl("PersonLabel");
            PersonLabel.Text = id.ToString();

            Label BiljettLabel = (Label)Transactionview.FindControl("BiljettLabel");
            BiljettLabel.Text = id2.ToString();

            return Service.GetPerson(id) as IEnumerable<Person>;
        }
        public void Transactionview_InsertItem(Transaction transaction)
        {
            try
            {
                Service.SaveTransaction(transaction);
                Session["ValidationSession"] = "Du har lagt till Transaktionen";
                Button1.Enabled = true;
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då transaktionen skulle Tas och Läggas till.");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("Start");
        }
    }
}
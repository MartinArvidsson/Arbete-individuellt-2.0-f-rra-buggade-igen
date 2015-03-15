using IndividuelltProjekt.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltProjekt.Ticketregpages
{
    public partial class Start : System.Web.UI.Page
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
        public IEnumerable<Transaction> Transactionview_GetData()
        {
            return Service.GetTransactions();
            
        }
        public void Transactionview_InsertItem(Transaction transaction)
        {
            try
            {
                Service.SaveTransaction(transaction);
                Session["ValidationSession"] = "Du har lagt till Transaktionen";
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då transaktionen skulle Tas och Läggas till.");
            }
        }
        public void Transactionview_DeleteItem(int TransactionID)
        {
            try
            {
                Service.DeleteTransaction(TransactionID);
                Session["ValidationSession"] = "Du har tagit bort Transaktionen";
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då Transaktionen skulle Tas bort.");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:61141/Ticketregpages/RegPerson.aspx");
        }
    }
}
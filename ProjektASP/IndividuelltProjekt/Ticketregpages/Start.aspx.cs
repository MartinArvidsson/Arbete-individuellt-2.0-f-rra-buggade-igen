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

        }

        public IEnumerable<Transaction> Transactionview_GetData()
        {
            return Service.GetTransactions();
            
        }

        public void Transactionview_InsertItem(Transaction transaction)
        {
            Service.SaveTransaction(transaction);
        }
        public void Transactionview_DeleteItem(int TransactionID)
        {
            Service.DeleteTransaction(TransactionID);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:61141/Ticketregpages/RegPerson.aspx");
        }

    }
}
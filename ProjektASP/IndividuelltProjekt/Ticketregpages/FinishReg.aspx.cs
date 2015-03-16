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
        protected void Button1_Click(object sender, EventArgs e)
        {
            var PersonID = int.Parse(RouteData.Values["id"].ToString());
            var BiljettID = int.Parse(RouteData.Values["id2"].ToString());
            try
            {
                Transaction tran = new Transaction();
                tran.PersonID = PersonID;
                tran.BiljettID = BiljettID;

                //Skicka in parametrar till Service.SaveTransaction.
                Service.SaveTransaction(tran);               
                Response.RedirectToRoute("Start");
                Session["ValidationSession"] = "Transaktionen lades till";
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då transaktionen skulle Tas och Läggas till.");
            }
        }
    }
}
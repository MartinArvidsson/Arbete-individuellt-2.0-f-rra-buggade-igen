﻿using IndividuelltProjekt.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                //var messageplaceholder = Master.FindControl("MessagePlaceholderText") as PlaceHolder;
                //messageplaceholder.Visible = true;

                //var ConfirmationLabel = Master.FindControl("ConfirmationLabelText") as Label;
                //ConfirmationLabel.Text = Session["ValidationSession"] as string;

                Session["ValidationSession"] = null;
            }
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
    }
}
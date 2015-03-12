using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IndividuelltProjekt.Shared
{
    public partial class Masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public PlaceHolder MessagePlaceholderText
        {
            get{ return MessagePlaceholder;}
            set{ MessagePlaceholder = value;}
        }

        public string ConfirmationLabelText
        {
            get { return ConfirmationLabel.Text; }
            set { ConfirmationLabel.Text = value;}
        }
    }
}
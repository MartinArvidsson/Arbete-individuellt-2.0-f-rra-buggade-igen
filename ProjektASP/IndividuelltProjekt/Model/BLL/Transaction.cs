using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.BLL
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public int PersonID { get; set; }

        public int BiljettID { get; set; }

        public string Fnamn { get; set; }

        public string Enamn { get; set; }
        public string Fdatum { get; set; }
    }
}
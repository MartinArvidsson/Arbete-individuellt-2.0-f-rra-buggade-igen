using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.BLL
{
    public class Ticket
    {
        public int BiljettID { get; set; }

        public string Biljettnamn { get; set; }

        public decimal kostnad { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.BLL
{
    public class Person
    {
        public int PersonID { get; set; }

        //[Required(ErrorMessage = "En Epost måste anges.")]

        //[StringLength(50, ErrorMessage = "En epost får max vara 50 tecken.")]

        //[RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?",
        //    ErrorMessage = "Epostadressen MÅSTE vara av giltigt format")]
        public string Fnamn { get; set; }

        //[Required(ErrorMessage = "Ett förnamn måste anges.")]
        //[StringLength(50, ErrorMessage = "Ett förnamn får max vara 50 tecken.")]
        public string Enamn { get; set; }

        //[Required(ErrorMessage = "Ett förnamn måste anges.")]
        //[StringLength(50, ErrorMessage = "Ett förnamn får max vara 50 tecken.")]
        public string Fdatum { get; set; }
    }
}
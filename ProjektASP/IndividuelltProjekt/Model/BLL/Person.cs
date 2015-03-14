using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndividuelltProjekt.Model.BLL
{
    public class Person
    {
        public int PersonID { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(20, ErrorMessage = "Ett förnamn får max vara 20 tecken.")]
        public string Fnamn { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(20, ErrorMessage = "Ett efternamn får max vara 20 tecken.")]
        public string Enamn { get; set; }

        [Required(ErrorMessage = "Ett datum måste anges.")]
        [StringLength(10, ErrorMessage = "Ett datum får max vara 10 tecken.")]
        public string Fdatum { get; set; }
    }
}
using Aventyrliga_kontakter.Model.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aventyrliga_kontakter.BLL
{
    public class Contact : ValidationExtensions
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "En Epost måste anges.")]
        [StringLength(50, ErrorMessage = "En epost får max vara 50 tecken.")]
        [RegularExpression(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", ErrorMessage="Epostadressen MÅSTE vara av giltigt format")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(50, ErrorMessage = "Ett förnamn får max vara 50 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(50, ErrorMessage = "Ett Efternamn får max vara 50 tecken.")]
        public string LastName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aventyrliga_kontakter.BLL
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Required(ErrorMessage = "En Epost måste anges.")]
        [StringLength(30, ErrorMessage = "Max 30 tecken.")]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Ett förnamn måste anges.")]
        [StringLength(30, ErrorMessage = "Max 30 tecken.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Ett efternamn måste anges.")]
        [StringLength(30, ErrorMessage = "Max 30 tecken.")]
        public string LastName { get; set; }
    }
}
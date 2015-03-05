using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aventyrliga_kontakter.Model.BLL
{
    public abstract class ValidationExtensions
    {
        public bool Validate(out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(this);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(this, validationContext, validationResults);
        }
    }
}
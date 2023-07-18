using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18yearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer  = validationContext.ObjectInstance as Customer;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth Date is required");
            }
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            if(age < 18)
            {
                return new ValidationResult("Customer must be at least 18 years of age");
            }
            return ValidationResult.Success;

        }
    }
}
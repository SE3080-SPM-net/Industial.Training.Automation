using Industial.Training.Automation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Industial.Training.Automation.CustomValidations
{
    public class ValidateInstructorEmail: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string check = "sliit.lk";
            string email;

            var model = (RegisterInstructorViewModel)validationContext.ObjectInstance;
            email = model.Email;

            string[] ToCheck = email.Split('@');

            if (ToCheck[1].Equals(check))
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Please enter a valid intitute email");




        }
    }
}
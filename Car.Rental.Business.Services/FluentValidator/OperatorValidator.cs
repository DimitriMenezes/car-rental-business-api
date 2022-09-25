using Car.Rental.Services.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Services.FluentValidator
{
    public class OperatorValidator : AbstractValidator<OperatorModel>
    {
        public OperatorValidator()
        {                
            RuleFor(i => i.Name)
                .NotEmpty()
                .WithMessage("Name is Required");
            RuleFor(i => i.Password)
                .NotEmpty()
                .WithMessage("Password is required");
            RuleFor(i => i.EnrollmentCode)
                .NotEmpty()
                .WithMessage("EnrollmentCode is Required");
        }
    }
}

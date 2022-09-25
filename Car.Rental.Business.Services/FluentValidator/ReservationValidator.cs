using Car.Rental.Business.Services.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Business.Services.FluentValidator
{
    public class ReservationValidator : AbstractValidator<ReservationModel>
    {
        public ReservationValidator()
        {
            RuleFor(i => i.EndDate).GreaterThan(i => i.StartDate)
                .WithMessage("End Date Should be Greather than Start");
        }
    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(100).When(c => c.BrandId == 1);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).Must(StartWith2).WithMessage("model year 2 ile başlamalı");
        }

        private bool StartWith2(string arg)
        {
            return arg.StartsWith("2");
        }
    }
}
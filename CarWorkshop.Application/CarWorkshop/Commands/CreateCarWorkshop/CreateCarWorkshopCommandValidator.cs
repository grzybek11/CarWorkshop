﻿using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CreateCarWorkshopCommandValidator(ICarWorkshopRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter name")
                .MinimumLength(2).WithMessage("Name should have atleast 2 charakters")
                .MinimumLength(20).WithMessage("Name should have maximum 20 charakters")
                .Custom((value, context) =>
                    {
                        var existingCarWorkshop = repository.GetByName(value).Result;
                        if (existingCarWorkshop != null)
                        {
                            context.AddFailure($"{value} is not unique name for car workshop");
                        }
                    });

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MinimumLength(12);

        }
    }
}

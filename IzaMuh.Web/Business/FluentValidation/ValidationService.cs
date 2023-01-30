using DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class ValidationService : AbstractValidator<Service>
    {
        public ValidationService()
        {
            RuleFor(x => x.Name).MaximumLength(150).WithMessage("150 Karakterden Fazla Olamaz");
           

        }
    }
}

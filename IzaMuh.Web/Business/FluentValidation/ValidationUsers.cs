using DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    internal class ValidationUsers : AbstractValidator<Users>
    {
        public ValidationUsers()
        {
            RuleFor(x => x.Username).MaximumLength(25).WithMessage("25 Karakterden Fazla Olamaz");
            RuleFor(x => x.Password).MaximumLength(25).WithMessage("25 Karakterden Fazla Olamaz");

        }
    }
}

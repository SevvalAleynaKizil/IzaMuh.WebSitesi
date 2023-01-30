using DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class ValidationComments: AbstractValidator<Comments>
    {
        public ValidationComments() 
        {
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("30 Karakterden Fazla Olamaz").MinimumLength(1).WithMessage("1 Karakterden Az Olamaz");
        }
    }
}

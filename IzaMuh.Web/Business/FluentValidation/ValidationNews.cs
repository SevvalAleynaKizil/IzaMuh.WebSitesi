using DataAccess.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class ValidationNews: AbstractValidator<News>
    {
        public ValidationNews() 
        {
            RuleFor(x => x.Newsname).MaximumLength(50).WithMessage("50 Karakterden Fazla Olamaz").MinimumLength(3).WithMessage("3 Karakterden Az Olamaz");
        }
    }
}

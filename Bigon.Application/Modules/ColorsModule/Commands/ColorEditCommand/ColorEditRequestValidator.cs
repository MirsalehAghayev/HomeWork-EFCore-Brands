using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Application.Modules.ColorsModule.Commands.ColorEditCommand
{
    class ColorEditRequestValidator : AbstractValidator<ColorEditRequest>
    {
        public ColorEditRequestValidator()
        {
            RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("");
        }
    }
}

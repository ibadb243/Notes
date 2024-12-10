using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateCommand
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand => updateNoteCommand.Title).NotEmpty().MaximumLength(256);
            RuleFor(updateNoteCommand => updateNoteCommand.Details).MaximumLength(4096);
        }
    }
}

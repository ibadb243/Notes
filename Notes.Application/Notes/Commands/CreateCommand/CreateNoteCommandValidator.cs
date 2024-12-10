using FluentValidation;

namespace Notes.Application.Notes.Commands.CreateCommand
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand => createNoteCommand.Title).NotEmpty().MaximumLength(256);
            RuleFor(createNoteCommand => createNoteCommand.Details).MaximumLength(4096);
        }
    }
}

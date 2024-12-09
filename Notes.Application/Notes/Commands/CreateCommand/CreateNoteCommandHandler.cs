using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.CreateCommand
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INoteDbContext _context;

        public CreateNoteCommandHandler(INoteDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateNoteCommand command, CancellationToken cancellationToken)
        {
            var note = new Note()
            {
                Id = Guid.NewGuid(),
                UserId = command.UserId,
                Title = command.Title,
                Details = command.Details,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
            };

            await _context.Notes.AddAsync(note, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}

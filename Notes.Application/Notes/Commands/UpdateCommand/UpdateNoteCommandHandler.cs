using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Notes.Commands.UpdateCommand
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INoteDbContext _context;

        public UpdateNoteCommandHandler(INoteDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == command.Id, cancellationToken);

            if (entity == null || entity.UserId == command.UserId)
                throw new NotFoundException(nameof(Note), command.Id);

            entity.Title = command.Title;
            entity.Details = command.Details;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Notes.Application.Notes.Commands.DeleteCommand
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INoteDbContext _context;

        public DeleteNoteCommandHandler(INoteDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteNoteCommand command, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FirstOrDefaultAsync(note => note.Id == command.Id, cancellationToken);

            if (entity == null || entity.UserId == command.UserId)
                throw new NotFoundException(nameof(Note), command.Id);

            _context.Notes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

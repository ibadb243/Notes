using Microsoft.EntityFrameworkCore;
using Nodes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    public interface INoteDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nodes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.HasIndex(_ => _.Id).IsUnique();

            builder.HasIndex(_ => _.UserId);

            builder.Property(_ => _.Title).HasMaxLength(256);
            builder.Property(_ => _.Details).HasMaxLength(4096);
        }
    }
}

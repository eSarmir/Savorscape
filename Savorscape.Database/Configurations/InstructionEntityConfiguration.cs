using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Savorscape.Database.Models;

namespace Savorscape.Database.Configurations
{
    public class InstructionEntityConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder
                .HasKey(i => i.InstructionID);
            builder
                .Property(i => i.Order)
                .IsRequired();
            builder
                .Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}

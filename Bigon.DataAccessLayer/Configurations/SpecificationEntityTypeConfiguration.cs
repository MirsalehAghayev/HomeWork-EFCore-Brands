using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Configurations
{
    class SpecificationEntityTypeConfiguration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.Property(m=>m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m=>m.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Specifications");
        }
    }
}

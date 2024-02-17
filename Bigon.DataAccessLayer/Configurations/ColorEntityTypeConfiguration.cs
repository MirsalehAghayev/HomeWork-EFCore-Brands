using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Configurations
{
    class ColorEntityTypeConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(m=>m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m=>m.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
            builder.Property(m=>m.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Colors");
        }
    }
}

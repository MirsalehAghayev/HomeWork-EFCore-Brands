using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Configurations
{
    class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(m=>m.Id).HasColumnType("int").UseIdentityColumn(1,1);
            builder.Property(m=>m.Name).HasColumnType("nvarchar").HasMaxLength(300).IsRequired();
            builder.Property(m=>m.ParentId).HasColumnType("int");
            builder.Property(m=>m.Type).HasColumnType("int").IsRequired();

            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("Categories");



            builder.HasOne<Category>()
                .WithMany()
                .HasPrincipalKey(m=>m.Id)
                .HasForeignKey(m=>m.ParentId)
                .OnDelete(DeleteBehavior.NoAction);


        }
    }
}

﻿using Bigon.Domain;
using Bigon.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bigon.DataAccessLayer.Configurations
{
    class ContectPostEntityTypeConfiguration : IEntityTypeConfiguration<ContactPost>
    {
        public void Configure(EntityTypeBuilder<ContactPost> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int").UseIdentityColumn(1, 1);
            builder.Property(m => m.FullName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(m => m.Subject).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Message).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.Answer).HasColumnType("nvarchar(max)");
            builder.Property(m => m.AnsweredAt).HasColumnType("datetime");
            builder.Property(m => m.AnsweredBy).HasColumnType("int");



            builder.ConfigureAuditable();
            builder.HasKey(m => m.Id);
            builder.ToTable("ContactPosts");
        }
    }
}
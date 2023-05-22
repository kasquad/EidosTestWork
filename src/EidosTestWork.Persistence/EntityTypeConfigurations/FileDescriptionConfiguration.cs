using System;
using EidosTestWork.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EidosTestWork.Persistence.EntityTypeConfigurations;

public class FileDescriptionConfiguration : IEntityTypeConfiguration<FileDescription>
{
    public void Configure(EntityTypeBuilder<FileDescription> builder)
    {
        builder
            .ToTable(Environment.GetEnvironmentVariable("POSTGRES_MINIO_EVENTS_TABLE"));

        // builder
        //     .ToTable("files");

        builder
            .HasKey(f => f.Path);

        builder
            .Property(f => f.Path)
            .HasColumnName("key");
        
        builder
            .Property(f => f.Description)
            .HasColumnType("jsonb")
            .HasColumnName("value");
    }
}
using EidosTestWork.Application.Models;
using EidosTestWork.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Npgsql.BackendMessages;

namespace EidosTestWork.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FileDescriptionConfiguration());
    }
    
    public DbSet<FileDescription> FilesDescription { get; set; }
}
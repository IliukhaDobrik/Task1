using DataLayer.Configurations;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }

    public DbSet<Data> Informations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DataConfigurations());
    }
}
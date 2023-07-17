using Desafio.Domain.Entities;
using Desafio.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infra.Context;

public class AppDbContext : DbContext
{
    public DbSet<ImportacaoCNAB> importacaoCNABs { get; set; }

   

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ImportacaoCNABMap());
    }
}


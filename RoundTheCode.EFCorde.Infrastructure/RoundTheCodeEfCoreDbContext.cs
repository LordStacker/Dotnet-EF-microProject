using Microsoft.EntityFrameworkCore;
using RoundTheCode.EFCore.Application.Context;
using RoundTheCode.EFCore.Domain.Entities;
using System.Reflection;

namespace RoundTheCode.EFCore.Infrastructure
{
    public class RoundTheCodeEfCoreDbContext : DbContext, IRoundTheCodeEfCoreDbContext
    {
        public RoundTheCodeEfCoreDbContext(DbContextOptions<RoundTheCodeEfCoreDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly()
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}


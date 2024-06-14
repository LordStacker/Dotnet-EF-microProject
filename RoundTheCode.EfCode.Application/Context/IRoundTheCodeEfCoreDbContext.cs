using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RoundTheCode.EFCore.Domain.Entities;


namespace RoundTheCode.EFCore.Application.Context
{
    public interface IRoundTheCodeEfCoreDbContext
    {
        DbSet<Product> Products { get; set; }
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry Remove(object entity);

    }
}


using Microsoft.EntityFrameworkCore;
using RoundTheCode.EFCore.Application.Context;
using RoundTheCode.EFCore.Application.Models;
using RoundTheCode.EFCore.Domain.Entities;

namespace RoundTheCode.EFCore.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRoundTheCodeEfCoreDbContext _roundTheCodeEfCoreDbContext;
        public ProductService(IRoundTheCodeEfCoreDbContext roundTheCodeEfCoreDbContext) {
            _roundTheCodeEfCoreDbContext = roundTheCodeEfCoreDbContext;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _roundTheCodeEfCoreDbContext.Products.SingleAsync(x => x.Id == id);
            _roundTheCodeEfCoreDbContext.Remove(product);

            await _roundTheCodeEfCoreDbContext.SaveChangesAsync();
        }

        public  async Task<PaginationResults<GetProduct>> GetAllAsync(int skip, int take)
        {
            var query = _roundTheCodeEfCoreDbContext.Products.Include(s => s.Category);
            return new PaginationResults<GetProduct>(
                await query.Select(product => new GetProduct
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryName = product.Category != null ? product.Category.Name : null
                }
                ).Skip(skip).Take(take).ToListAsync(),
                take,
                await query.CountAsync()
              );
        }

        public async Task<List<GetProduct>> GetAllSync()
        {
            return await _roundTheCodeEfCoreDbContext.Products.Include(s => s.Category).Select(product => new GetProduct{ 
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category != null ? product.Category.Name : null
            }).ToListAsync();
        }

        public async Task<GetProduct?> GetAsync(int id)
        {
            var product = await _roundTheCodeEfCoreDbContext.Products.Include(s => s.Category).FirstOrDefaultAsync(x => x.Id == id);

            if(product == null)
                return null;
            return new GetProduct
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category?.Name
            };
        }

        public async Task<int> InsertAsync(InsertUpdateProduct insertUpdate)
        {
            var product = new Product
            {
                Name = insertUpdate.Name,
                Description = insertUpdate.Description,
                Price = insertUpdate.Price,
                CategoryId = insertUpdate.CategoryId,
            };

            await _roundTheCodeEfCoreDbContext.Products.AddAsync(product);
            await _roundTheCodeEfCoreDbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task UpdateAsync(int id, InsertUpdateProduct updateProduct)
        {
            var product = await _roundTheCodeEfCoreDbContext.Products.SingleAsync(x => x.Id == id);
            product.Name = updateProduct.Name;
            product.Description = updateProduct.Description;
            product.Price = updateProduct.Price;
            product.CategoryId = updateProduct.CategoryId;
            await _roundTheCodeEfCoreDbContext.SaveChangesAsync();
        }
    }
}

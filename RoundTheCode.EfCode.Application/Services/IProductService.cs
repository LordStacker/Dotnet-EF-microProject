
using RoundTheCode.EFCore.Application.Models;

namespace RoundTheCode.EFCore.Application.Services
{
    public interface IProductService
    {
        Task<int> InsertAsync(InsertUpdateProduct insertUpdate);

        Task UpdateAsync(int id, InsertUpdateProduct updateProduct);


        Task DeleteAsync(int id);

        Task<GetProduct?> GetAsync(int id);

        Task<List<GetProduct>> GetAllSync();

        Task<PaginationResults<GetProduct>> GetAllAsync(int skip, int take);
    }
}

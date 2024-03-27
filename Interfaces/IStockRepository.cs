using morningclassonapi.DTO.Account;
using morningclassonapi.Helper;
using morningclassonapi.Model;

namespace morningclassonapi.Interfaces
{
    public interface IStockRepository
    {

        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock> GetByIdAsync(int Id);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto);
        Task<List<Stock?>> GetAllAsync(QueryObject query);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExist(int id);
    }
}

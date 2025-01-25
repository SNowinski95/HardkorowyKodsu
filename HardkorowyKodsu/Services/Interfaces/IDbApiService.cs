using HardkorowyKodsu.Models;

namespace HardkorowyKodsu.Services.Interfaces
{
    public interface IDbApiService
    {
        Task<IEnumerable<string>> GetAllTablesAsync();
        Task<IEnumerable<string>> GetAllViewsAsync();
        Task<IEnumerable<Column>> GetColumnsAsync(string tableName);
    }
}

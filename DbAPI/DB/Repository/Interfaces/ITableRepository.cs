using DbAPI.DB.Models;

namespace DbAPI.DB.Repository.Interfaces
{
    public interface ITableRepository
    {
        Task<IEnumerable<string>> GetAllTablesAsync();
        Task<IEnumerable<string>> GetAllViewsAsync();
        Task<IEnumerable<Column>> GetColumnsAsync(string columnName);
    }
}

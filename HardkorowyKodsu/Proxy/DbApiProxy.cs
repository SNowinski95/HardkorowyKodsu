using HardkorowyKodsu.Models;
using RestEase;

namespace HardkorowyKodsu.Proxy
{
    public interface IDbApiProxy
    {
        [Header("Token")]
        string Token { get; set; }
        [Get("/Table/GetTables")]
        Task<IEnumerable<string>> GetAllTablesAsync();
        [Get("/Table/GetViews")]
        Task<IEnumerable<string>> GetAllViewsAsync();
        [Get("/Table/GetColumns/{tableName}")]
        Task<IEnumerable<Column>> GetColumnsAsync([Path]string tableName);
    }
}

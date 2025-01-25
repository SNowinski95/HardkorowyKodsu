using HardkorowyKodsu.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.ApplicationServices;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

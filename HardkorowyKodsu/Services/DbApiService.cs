using HardkorowyKodsu.Models;
using HardkorowyKodsu.Proxy;
using HardkorowyKodsu.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using RestEase;

namespace HardkorowyKodsu.Services
{
    public class DbApiService : IDbApiService
    {
        private readonly IDbApiProxy _proxy;

        public DbApiService(IDbApiProxy proxy, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(proxy);
            _proxy = proxy;
            var apiToken = configuration["ApiToken"];
            ArgumentException.ThrowIfNullOrWhiteSpace(apiToken);
            _proxy.Token = apiToken;
        }

        public async Task<IEnumerable<string>> GetAllTablesAsync()
        {
            return await ExceptionWraperAsync(_proxy.GetAllTablesAsync, "Unable to load tables");
        }

        public async Task<IEnumerable<string>> GetAllViewsAsync()
        {
            return await ExceptionWraperAsync(_proxy.GetAllViewsAsync, "Unable to load Views");
        }

        public async Task<IEnumerable<Column>> GetColumnsAsync(string tableName)
        {
            
            return await ExceptionWraperAsync(async()=>await _proxy.GetColumnsAsync(tableName), "Unable to load Columns");
        }
        private static async Task<IEnumerable<T>> ExceptionWraperAsync<T>(Func<Task<IEnumerable<T>>> call, string ErrorCaption = "")
        {
            try
            {
                return await call();
            }
            catch (ApiException e)
            {
                MessageBox.Show($"request issue {e.Message}", ErrorCaption);
                return [];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, ErrorCaption);
                return [];
            }
        }
    }
}

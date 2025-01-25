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
            return await ExceptionWraperAsync(_proxy.GetAllTablesAsync);
        }

        public async Task<IEnumerable<string>> GetAllViewsAsync()
        {
            return await ExceptionWraperAsync(_proxy.GetAllViewsAsync);
        }

        public async Task<IEnumerable<Column>> GetColumnsAsync(string tableName)
        {
            
            return await ExceptionWraperAsync(async()=>await _proxy.GetColumnsAsync(tableName));
        }
        private static async Task<T> ExceptionWraperAsync<T>(Func<Task<T>> call)
        {
            try
            {
                return await call();
            }
            catch (ApiException e)
            {
                MessageBox.Show(e.Message,"request issue");
                return default;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return default;
            }
        }
    }
}

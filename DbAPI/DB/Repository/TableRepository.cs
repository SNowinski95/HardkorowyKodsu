using Dapper;
using DbAPI.DB.Models;
using DbAPI.DB.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DbAPI.DB.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly IDbContext _dbContext;

        private readonly ILogger<ITableRepository> _logger;

        public TableRepository(IDbContext dbContext, ILogger<ITableRepository> logger) 
        {
            ArgumentNullException.ThrowIfNull(dbContext);
            ArgumentNullException.ThrowIfNull(logger);
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Column>> GetColumnsAsync(string tableName)
        {
            return await ExceptionWraper(async () =>
            {
                using var connection = _dbContext.GetConnection();
                const string sql = "SELECT COLUMN_NAME Name, COLUMN_TYPE Type FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'sakila' AND TABLE_NAME =@tableName;";
                var collumns = await connection.QueryAsync<Column>(sql, new { tableName });
                _logger.LogInformation("{sql} \nget {Count} rows", sql, collumns.Count());
                return collumns ?? Enumerable.Empty<Column>();
            });

        }

        public async Task<IEnumerable<string>> GetAllTablesAsync()
        {
            return await ExceptionWraper(async () =>
            {
                using var connection = _dbContext.GetConnection();
                const string sql = "SHOW FULL TABLES IN sakila WHERE TABLE_TYPE = 'BASE TABLE';";
                var tables = await connection.QueryAsync<string>(sql);
                _logger.LogInformation("{sql}  \nget {Count} rows", sql, tables.Count());
                return tables ?? Enumerable.Empty<string>();
            });
        }

        public async Task<IEnumerable<string>> GetAllViewsAsync()
        {
            return await ExceptionWraper(async () =>
            {
                using var connection = _dbContext.GetConnection();
                const string sql = "SHOW FULL TABLES IN sakila WHERE TABLE_TYPE = 'VIEW';";
                var tables = await connection.QueryAsync<string>(sql);
                _logger.LogInformation("{sql} \nget {Count} rows", sql, tables.Count());
                return tables ?? Enumerable.Empty<string>();
            });
            
        }
        private async Task<T> ExceptionWraper<T>(Func<Task<T>> dbRequest)
        {
            try
            {
                return await dbRequest();
            }
            catch(MySqlException ex)
            {
                _logger.LogError(ex, "execute database querry exeption");
                throw;
            }
        }
    }
}

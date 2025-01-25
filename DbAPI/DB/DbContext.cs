using System.Data;

namespace DbAPI.DB
{
    public interface IDbContext
    {   
        IDbConnection GetConnection();
    }

    public class DbContext : IDbContext, IDisposable
    {
        private bool _disposed;
        private readonly string? _connectionString;
        private IDbConnection _connection;
        public DbContext(IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);
            _connectionString = configuration.GetConnectionString("SqlConnection");
            ArgumentException.ThrowIfNullOrWhiteSpace(_connectionString);


        }
        public IDbConnection GetConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString);
                _connection.Open();
            }
            return _connection;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _connection.Close();
                _connection.Dispose();
            }
            _disposed= true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

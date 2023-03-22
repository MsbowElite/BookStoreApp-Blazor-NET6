using System.Data;

namespace BookStoreApp.API.Data
{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}

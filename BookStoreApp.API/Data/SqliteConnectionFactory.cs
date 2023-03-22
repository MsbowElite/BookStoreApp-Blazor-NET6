﻿using Microsoft.Data.Sqlite;
using System.Data;

namespace BookStoreApp.API.Data
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly string connectionString;

        public SqliteConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}

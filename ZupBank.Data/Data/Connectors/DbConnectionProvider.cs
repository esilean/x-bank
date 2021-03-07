using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace ZupBank.Data.Data.Connectors
{
    public class DbConnectionProvider : IDisposable
    {
        protected IDbConnection DbConnection { get; private set; }

        private string _cnn;

        public DbConnectionProvider(string cnn)
        {
            _cnn = cnn;
        }

        public IDbConnection GetConnection()
        {
            DbConnection = new SqlConnection(_cnn);
            return DbConnection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && DbConnection != null)
                DbConnection.Close();
        }
    }
}

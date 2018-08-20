using BancoSowConnect.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Infrastructure.Repository.Repositories
{
    public class FactoryConnection : IFactoryConnection
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionStringsBancoSowConnect"].ConnectionString;

        private bool disposed = false;

        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");

                var conn = factory.CreateConnection();

                conn.ConnectionString = connectionString;

                return conn;
            }
        }

        ~FactoryConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }
    }
}

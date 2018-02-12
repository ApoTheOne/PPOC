using Microsoft.Extensions.Configuration;
// using Dapper;
using Npgsql;
using System.Data;

namespace CorePOC.DataLayer.InfraStructure
{
    public class ConnectionFactory: IConnectionFactory
    {
        // To detect redundant call
        private bool disposedValue = false;
        //private readonly string connectionString = ConfigurationManager.ConnectionStrings["DTAppCon"].ConnectionString;
        private string connectionString;

        public ConnectionFactory(IConfiguration configuration)
        {
            connectionString = configuration["Logging:DBInfo:ConnectionString"];
        }

        public IDbConnection GetConnection
        {
            get
            {
                return  new NpgsqlConnection(connectionString);
            }
        }

        protected   virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ConnectionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
    }
}

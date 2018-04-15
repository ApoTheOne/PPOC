using System;
using System.Data;

namespace CorePOC.DataLayer.InfraStructure
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection{get;}
    }
}
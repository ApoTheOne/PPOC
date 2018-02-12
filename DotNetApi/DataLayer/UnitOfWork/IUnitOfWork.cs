using System;
using CorePOC.DataLayer.Repositories;

namespace CorePOC.DataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }
        void Complete();
    }
}
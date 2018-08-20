using System;
using System.Data;

namespace BancoSowConnect.Infrastructure.Repository.Interfaces
{
    public interface IFactoryConnection : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}

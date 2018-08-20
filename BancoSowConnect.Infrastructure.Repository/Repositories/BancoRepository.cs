using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BancoSowConnect.Domain.Entity;
using BancoSowConnect.Infrastructure.Repository.Interfaces;
using Dapper;
using System.Linq;

namespace BancoSowConnect.Infrastructure.Repository.Repositories
{
    public class BancoRepository : BaseRepository, IBancoRepository
    {
        IFactoryConnection _db = null;

        public BancoRepository(IFactoryConnection db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(new { ID_BANCO = id });

                db.Execute("SP_D_BANCO", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(BancoEntity t)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(new { Nome = t.Nome, ID_BANCO = t.Id });

                db.Execute("SP_U_BANCO", p, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insert(BancoEntity t)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@BancoID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { Nome = t.Nome, ID_USUARIO_CRIO = t.IdUsuarioCrio });

                int resultado = db.Execute("SP_I_BANCO", p, commandType: CommandType.StoredProcedure);

                if (resultado != 0)
                    return p.Get<int>("@BancoID");
                return 0;
            }
        }

        public IEnumerable<BancoEntity> SelectAll()
        {
            using (var db = _db.GetConnection)
            {
                var resultado = db.Query<BancoEntity>("SP_S_BANCO", null, commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public BancoEntity GetById(int id)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(new { ID_BANCO = id });

                var resultado = db.Query<BancoEntity>("SP_S_BANCO", p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return resultado;
            }
        }
    }
}

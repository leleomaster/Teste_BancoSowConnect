using BancoSowConnect.Domain.Entity;
using BancoSowConnect.Infrastructure.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BancoSowConnect.Infrastructure.Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        IFactoryConnection _db = null;

        public PessoaRepository(IFactoryConnection db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(new { ID_PESSOA = id });

                db.Execute("SP_D_PESSOA", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(PessoaEntity t)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(new { ID_PESSOA = t.Id, NOME = t.Nome, ID_CONTA = t.Conta.Id, ID_ENDERECO = t.Endereco.Id, ID_TIPO_PESSOA = (int)t.TipoPessoa });

                db.Execute("SP_U_PESSOA", p, commandType: CommandType.StoredProcedure);
            }
        }

        public int Insert(PessoaEntity t)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.Add("@PessoaID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { NOME = t.Nome, ID_CONTA = t.Conta.Id, ID_ENDERECO = t.Endereco.Id, ID_TIPO_PESSOA = (int)t.TipoPessoa });

                int resultado = db.Execute("SP_I_PESSOA", p, commandType: CommandType.StoredProcedure);

                if (resultado != 0)
                    return p.Get<int>("@PessoaID");
                return 0;
            }
        }

        public IEnumerable<PessoaEntity> SelectAll()
        {
            using (var db = _db.GetConnection)
            {
                var resultado = db.Query<PessoaEntity>("SP_S_PESSOA", null, commandType: CommandType.StoredProcedure);

                return resultado;
            }
        }

        public PessoaEntity GetById(int id)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                p.AddDynamicParams(new { ID_PESSOA = id });

                var resultado = db.Query<PessoaEntity>("SP_S_PESSOA", p, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return resultado;
            }
        }

        public IEnumerable<PessoaEntity> GetByName(string name)
        {
            using (var db = _db.GetConnection)
            {
                DynamicParameters p = new DynamicParameters();

                Func<PessoaEntity, EnderecoEntity, ContaEntity, DocumentoEntity, PessoaEntity> mapper = ((pes, end, cont, doc) =>
                {
                    pes.Endereco = end;
                    pes.Conta = cont;
                    if (pes.Documentos == null)
                    {
                        pes.Documentos = new List<DocumentoEntity>();
                    }
                    pes.Documentos.Add(doc);
                    return pes;
                });

                p.AddDynamicParams(new { NOME = name });

                var resultado = db.Query(
                    "SP_S_PESSOA",                   
                    map: mapper,
                    param: p,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "CONTA,ENDERECO,DOCUMENTO");

                return resultado;
            }
        }
    }
}

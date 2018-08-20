using BancoSowConnect.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public class ContaEntity
    {
        public int Id { get; set; }

        public decimal Numero { get; set; }

        public TipoContaEnum TipoConta { get; set; }

        public PessoaEntity Pessoa { get; set; }

        public BancoEntity Banco { get; set; }

        public DateTime DataCriada { get; set; }

        public int IdUsuaroCrio { get; set; }

        public decimal Saldo { get; set; }

        public bool Ativa { get; set; }

        public IEnumerable<TransferenciaEntity> Transferencias { get; set; }
    }
}

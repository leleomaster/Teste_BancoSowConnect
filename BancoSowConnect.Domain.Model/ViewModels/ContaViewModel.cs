using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoSowConnect.Domain.Entity.Enums;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class ContaViewModel
    {
        public int Id { get; set; }

        public decimal Numero { get; set; }

        public TipoContaEnum TipoConta { get; set; }

        public PessoaViewModel Pessoa { get; set; }

        public BancoViewModel Banco { get; set; }

        public DateTime DataCriada { get; set; }

        public int IdUsuaroCrio { get; set; }

        public decimal Saldo { get; set; }

        public bool Ativa { get; set; }

        public IEnumerable<TransferenciaViewModel> Transferencias { get; set; }

        public IEnumerable<OperacaoContaViewModel> OperacaoContas { get; set; }

        public string EhAtiva
        {
            get
            {
                return Ativa ? "Ativa" : "Inativa";
            }
        }
    }
}

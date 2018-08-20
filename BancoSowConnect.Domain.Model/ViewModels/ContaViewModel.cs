using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class ContaViewModel
    {
        public decimal Numero { get; set; }

        public string TipoConta { get; set; }

        public PessoaViewModel Pessoa { get; set; }

        public string NomeBanco { get; set; }

        public DateTime DataCriada { get; set; }

        public decimal Saldo { get; set; }

        public bool EhAtiva { get; set; }

        public string Ativa
        {
            get
            {
                return EhAtiva ? "Ativa" : "Inativa";
            }
        }
    }
}

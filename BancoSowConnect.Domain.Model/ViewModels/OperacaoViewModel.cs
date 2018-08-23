using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class OperacaoViewModel
    {
        [Display(Name = "Nome da Pessoa")]
        public string NomePessoa { get; set; }

        public string IdPessoa { get; set; }

        [Display(Name = "Saldo da Conta")]
        public string SaldoConta { get; set; }

        public bool EhDebito { get; set; }

        [Display(Name = "Valor")]
        public string Valor { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class PesquisaPessoaViewModel
    {
        [Display(Name = "Nome da Pessoa")]
        public string Nome { get; set; }

        [Display(Name = "CPF/CNPJ")]
        public string Documento { get; set; }

        public bool EhCPF { get; set; }

        [Display(Name = "Número da Conta")]
        public string NumeroConta { get; set; }

        public List<PessoaViewModel> ListaPessoa { get; set; }
    }
}

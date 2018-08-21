using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        public List<DocumentoViewModel> Documentos { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public ContaViewModel Conta { get; set; }
        
        [Required(ErrorMessage = "O Tipo de Pessoa é obrigatório")]
        public string TipoPessoa { get; set; }
    }
}
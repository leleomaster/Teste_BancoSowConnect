using System.Collections.Generic;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class PessoaViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<DocumentoViewModel> Documentos { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public ContaViewModel Conta { get; set; }

        public string TipoPessoa { get; set; }
    }
}
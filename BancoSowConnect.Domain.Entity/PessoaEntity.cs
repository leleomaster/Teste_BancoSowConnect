using BancoSowConnect.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public class PessoaEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<DocumentoEntity> Documentos { get; set; }

        public EnderecoEntity Endereco { get; set; }

        public ContaEntity Conta{ get; set; }

        public TipoPessoaEnum TipoPessoa { get; set; }
    }
}

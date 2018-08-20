using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public class EnderecoEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CEP { get; set; }

        public string Bairro { get; set; }

        public CidadeEntity Cidade { get; set; }

    }
}

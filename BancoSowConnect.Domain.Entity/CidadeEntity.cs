using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public sealed class CidadeEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<EnderecoEntity> Enderecos { get; set; }

        public EstadoEntity Estado { get; set; }
    }
}

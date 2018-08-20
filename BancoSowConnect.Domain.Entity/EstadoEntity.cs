using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public sealed class EstadoEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<CidadeEntity> Cidades { get; set; }

        public PaisEntity Pais { get; set; }
    }
}

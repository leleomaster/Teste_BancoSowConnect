using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public sealed class PaisEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<EstadoEntity> Estados { get; set; }
    }
}

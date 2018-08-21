using System.Collections.Generic;

namespace BancoSowConnect.Domain.Entity
{
    public sealed class PaisEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<EstadoEntity> Estados { get; set; }
    }
}

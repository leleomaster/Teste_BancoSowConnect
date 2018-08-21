using System.Collections.Generic;

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

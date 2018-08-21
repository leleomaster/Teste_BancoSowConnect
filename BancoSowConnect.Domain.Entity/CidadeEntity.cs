using System.Collections.Generic;

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

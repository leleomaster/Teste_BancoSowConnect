using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public class BancoEntity
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdUsuarioCrio { get; set; }

        public DateTime DataCriada { get; set; }

        public IEnumerable<ContaEntity> Contas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public class OperacaoContaEntity
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public TipoOperacaoEntity TipoOperacao { get; set; }
        public decimal Valor{ get; set; }
    }
}

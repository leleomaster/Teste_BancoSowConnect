using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class OperacaoContaViewModel
    {
        public int Id { get; set; }
        public int IdConta { get; set; }
        public TipoOperacaoViewModel TipoOperacao { get; set; }
        public decimal Valor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class OperacaoContaViewModel
    {
        public int Id { get; set; }
        public int IdConta { get; set; }

        [Display(Name = "Tipo de Operação")]
        public TipoOperacaoViewModel TipoOperacao { get; set; }

        [Display(Name = "Valor")]
        public decimal Valor { get; set; }
    }
}

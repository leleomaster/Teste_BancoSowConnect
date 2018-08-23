using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class TipoOperacaoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O tipo de operação é obrigatório")]
        public string Nome { get; set; }
    }
}

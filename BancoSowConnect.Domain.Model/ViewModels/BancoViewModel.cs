using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class BancoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "O tamanho do nome deve estar entre 3 e 35")]
        public string Nome { get; set; }

        public int IdUsuario { get; set; }
    }
}

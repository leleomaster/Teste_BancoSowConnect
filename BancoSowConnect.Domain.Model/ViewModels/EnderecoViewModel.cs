using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Endereço é obrigatório")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string CEP { get; set; }


        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string Bairro { get; set; }

        public CidadeViewModel Cidade { get; set; }
    }
}

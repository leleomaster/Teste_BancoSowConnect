using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class CidadeViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }

        public EstadoViewModel Estado { get; set; }
    }
}

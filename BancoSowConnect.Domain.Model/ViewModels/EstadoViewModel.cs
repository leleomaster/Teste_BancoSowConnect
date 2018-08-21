using System.Collections.Generic;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class EstadoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<CidadeViewModel> Cidades { get; set; }

        public PaisViewModel Pais { get; set; }
    }
}

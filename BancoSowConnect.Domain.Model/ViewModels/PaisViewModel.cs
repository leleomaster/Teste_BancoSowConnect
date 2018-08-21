using System.Collections.Generic;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class PaisViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<EstadoViewModel> Estados { get; set; }
    }
}

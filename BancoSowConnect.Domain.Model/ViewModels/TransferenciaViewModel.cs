using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ViewModels
{
    public class TransferenciaViewModel
    {
        public int Id { get; set; }

        public ContaViewModel ContaDebito { get; set; }

        public ContaViewModel ContaCredito { get; set; }

        public DateTime Data { get; set; }

        public string Valor { get; set; }
    }
}

using System;

namespace BancoSowConnect.Domain.Entity
{
    public class TransferenciaEntity
    {
        public int Id { get; set; }

        public ContaEntity ContaDebito { get; set; }

        public ContaEntity ContaCredito { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorContaDebito { get; set; }

        public decimal ValorContaCredito { get; set; }
    }
}
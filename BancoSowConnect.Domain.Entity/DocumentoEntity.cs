using BancoSowConnect.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity
{
    public sealed class DocumentoEntity
    {
        public int Id { get; set; }

        public decimal Numero { get; set; }

        public DateTime DataEmissao { get; set; }

        public string EmitidoPor { get; set; }

        public TipoDocumentoEntity TipoDocumentoEntity{ get; set; }
    }
}

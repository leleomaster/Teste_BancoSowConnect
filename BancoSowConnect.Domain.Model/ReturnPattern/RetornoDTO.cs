using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ReturnPattern
{
    public class RetornoDTO
    {
        public string Message { get; set; }

        public EStatusResponse EStatusResponse { get; set; }
    }
}

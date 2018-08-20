using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ReturnPattern
{
    public class BaseRetornoDTO<T> : RetornoDTO
    {
        public T Value { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}

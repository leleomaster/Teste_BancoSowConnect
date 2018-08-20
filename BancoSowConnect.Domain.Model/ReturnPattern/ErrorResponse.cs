using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ReturnPattern
{
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorText { get; set; }

        public Dictionary<int, string> ErrorIdentify { get; set; }
    }
}

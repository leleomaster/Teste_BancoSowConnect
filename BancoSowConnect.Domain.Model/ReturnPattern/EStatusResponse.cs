using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Model.ReturnPattern
{
    public enum EStatusResponse
    {
        Success = 1,
        ErrorAplicacao = 2,
        ErrorBanco = 3,
        ErrorValidacao = 4
    }
}

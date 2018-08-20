using BancoSowConnect.Domain.Model.ReturnPattern;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Aplication.Service
{
    public sealed class BaseExceptionSystem<T>
    {

        public static void BaseHandleExcetion(Action action, string mensagem, ref BaseRetornoDTO<T> retornoDTO)
        {
            try
            {
                action.Invoke();

                retornoDTO.Message = mensagem;
                retornoDTO.EStatusResponse = EStatusResponse.Success;
            }
            catch (SqlException ex)
            {
                // log = Stack trace, classe and method
                retornoDTO.EStatusResponse = EStatusResponse.ErrorBanco;
                retornoDTO.Message = MensagemSistema.SqlException;
            }
            catch (TimeoutException tmOut)
            {
                // log = Stack trace, classe and method
                retornoDTO.EStatusResponse = EStatusResponse.ErrorBanco;
                retornoDTO.Message = MensagemSistema.TimeoutException;
            }
            catch (NullReferenceException exNullRef)
            {
                // log = Stack trace, classe and method
                retornoDTO.EStatusResponse = EStatusResponse.ErrorAplicacao;
                retornoDTO.Message = MensagemSistema.NullReferenceException;
            }
            catch (Exception ex)
            {
                // log = Stack trace, classe and method
                retornoDTO.EStatusResponse = EStatusResponse.ErrorAplicacao;
                retornoDTO.Message = MensagemSistema.DefaultException;
            }
        }
    }
}

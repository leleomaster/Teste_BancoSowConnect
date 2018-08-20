using BancoSowConnect.Aplication.Service;
using BancoSowConnect.Domain.Model.ReturnPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoSowConnect.Apresentation.Web
{
    public class BaseHandleExceptionWeb<T>
    {
        public static void BaseHandleExcetion(Action action, ref BaseRetornoDTO<T> retornoDTO)
        {
            try
            {
                action.Invoke();

                retornoDTO.EStatusResponse = EStatusResponse.Success;
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
                retornoDTO.Message = MensagemSistema.APIIndisponivel;
            }
        }
    }
}
using BancoSowConnect.Apresentation.Web.DesignPatterns.Singletons;
using BancoSowConnect.Domain.Model.ReturnPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using BancoSowConnect.Aplication.Service;

namespace BancoSowConnect.Apresentation.Web.ComunicationAPI
{
    public class CallAPIHttpClient<T>
    {
        private readonly HttpClient _httpClient;

        public CallAPIHttpClient()
        {
            _httpClient = HttpClienteSingletion.GetInstanceHttpClient;
        }

        private BaseRetornoDTO<T> DeserializeObject(string json)
        {
            return JsonConvert.DeserializeObject<BaseRetornoDTO<T>>(json);
        }

        private string SerializeObject(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public async Task<BaseRetornoDTO<T>> GetAsync(int? id, string nameMethod)
        {
            BaseRetornoDTO<T> retorno = null;
            try
            {
                nameMethod = id == null ? nameMethod : $"{nameMethod}?id={id}";

                var responseTask = await _httpClient.GetAsync(nameMethod);

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsStringAsync();
                    retorno = DeserializeObject(readTask);
                }
            }
            catch (Exception ex)
            {
                // Log ex
                retorno = new BaseRetornoDTO<T>()
                {
                    EStatusResponse = EStatusResponse.ErrorAplicacao,
                    Message = MensagemSistema.APIIndisponivel
                };
            }
            return retorno;
        }

        public async Task<BaseRetornoDTO<int>> PostAsync(T t, string nameMethod)
        {
            BaseRetornoDTO<int> retorno = null;

            try
            {
                var json = SerializeObject(t);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var responseTask = await _httpClient.PostAsync(nameMethod, content);

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<BaseRetornoDTO<int>>(readTask);
                }
            }
            catch (Exception ex)
            {
                // Log ex
                retorno = new BaseRetornoDTO<int>()
                {
                    EStatusResponse = EStatusResponse.ErrorAplicacao,
                    Message = MensagemSistema.APIIndisponivel
                };
            }
            return retorno;
        }

        public async Task<BaseRetornoDTO<bool>> PutAsync(T t, string nameMethod)
        {
            var json = SerializeObject(t);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            BaseRetornoDTO<bool> retorno = null;
            try
            {
                var responseTask = await _httpClient.PutAsync(nameMethod, content);

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<BaseRetornoDTO<bool>>(readTask);
                }
            }
            catch (Exception ex)
            {
                // Log ex
                retorno = new BaseRetornoDTO<bool>()
                {
                    EStatusResponse = EStatusResponse.ErrorAplicacao,
                    Message = MensagemSistema.APIIndisponivel
                };
            }
            return retorno;
        }

        public async Task<BaseRetornoDTO<bool>> DeleteAsync(int id, string nameMethod)
        {
            BaseRetornoDTO<bool> retorno = null;
            try
            {
                nameMethod = $"{nameMethod}?id={id}";

                var responseTask = await _httpClient.DeleteAsync(nameMethod);

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<BaseRetornoDTO<bool>>(readTask);
                }
            }
            catch (Exception ex)
            {
                // Log ex
                retorno = new BaseRetornoDTO<bool>()
                {
                    EStatusResponse = EStatusResponse.ErrorAplicacao,
                    Message = MensagemSistema.APIIndisponivel
                };
            }
            return retorno;
        }
    }
}
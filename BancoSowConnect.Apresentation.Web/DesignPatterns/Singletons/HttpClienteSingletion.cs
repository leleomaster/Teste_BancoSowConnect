using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace BancoSowConnect.Apresentation.Web.DesignPatterns.Singletons
{
    public static class HttpClienteSingletion
    {
        private static readonly int _connectionTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["connection_timeout_segunds_HttpClient"]);
        private static readonly string _urlAPI = ConfigurationManager.AppSettings["url_api"];
        private static HttpClient _httpClientInstance;

        public static HttpClient GetInstanceHttpClient
        {
            get
            {
                if (_httpClientInstance == null)
                    _httpClientInstance = CreateHttpClient();
                return _httpClientInstance;
            }
        }

        private static HttpClient CreateHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            HttpClient client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(_connectionTimeout);
            client.BaseAddress = new Uri(_urlAPI);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

    }
}
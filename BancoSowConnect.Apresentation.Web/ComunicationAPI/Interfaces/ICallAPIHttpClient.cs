using BancoSowConnect.Domain.Model.ReturnPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Apresentation.Web.ComunicationAPI.Interfaces
{
    public interface ICallAPIHttpClient<T>
    {
        BaseRetornoDTO<T> DeserializeObject(string json);

        string SerializeObject(T obj);

        Task<BaseRetornoDTO<T>> GetAsync(int id, string nameMethod);

        Task<BaseRetornoDTO<List<T>>> GetListAsync(string nameMethod);

        Task<BaseRetornoDTO<int>> PostAsync(T t, string nameMethod);

        Task<BaseRetornoDTO<bool>> PutAsync(T t, string nameMethod);

        Task<BaseRetornoDTO<bool>> DeleteAsync(int id, string nameMethod);
    }
}

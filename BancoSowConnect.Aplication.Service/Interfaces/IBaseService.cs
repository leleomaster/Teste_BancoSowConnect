using BancoSowConnect.Domain.Model.ReturnPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Aplication.Service.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        BaseRetornoDTO<bool> Update(T t);
        BaseRetornoDTO<int> Insert(T t);
        BaseRetornoDTO<bool> Delete(int id);

        BaseRetornoDTO<List<T>> SelectAll();
        BaseRetornoDTO<T> GetById(int id);
    }
}
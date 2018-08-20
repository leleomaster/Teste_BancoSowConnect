using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Infrastructure.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Update(T t);
        int Insert(T t);
        void Delete(int id);

        IEnumerable<T> SelectAll();
        T GetById(int id);
    }
}

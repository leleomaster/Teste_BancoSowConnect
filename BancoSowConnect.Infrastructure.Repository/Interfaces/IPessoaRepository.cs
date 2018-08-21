using BancoSowConnect.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Infrastructure.Repository.Interfaces
{
    public interface IPessoaRepository : IBaseRepository<PessoaEntity>
    {
        IEnumerable<PessoaEntity> GetByName(string name);
    }
}

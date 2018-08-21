using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using System.Collections.Generic;

namespace BancoSowConnect.Aplication.Service.Interfaces
{
    public interface IPessoaService : IBaseService<PessoaViewModel>
    {
        BaseRetornoDTO<List<PessoaViewModel>> GetByName(string name);
    }
}

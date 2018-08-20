using BancoSowConnect.Aplication.Service.Interfaces;
using BancoSowConnect.Domain.Entity.Business.Interfaces;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using BancoSowConnect.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Aplication.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaBusiness _pessoaBusiness;

        public PessoaService(IPessoaRepository pessoaRepository, IPessoaBusiness pessoaBusiness)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaBusiness = pessoaBusiness;
        }

        public BaseRetornoDTO<bool> Delete(int id)
        {
            BaseRetornoDTO<bool> retornoDTO = new BaseRetornoDTO<bool>();

            BaseExceptionSystem<bool>.BaseHandleExcetion(() =>
            {
                _pessoaRepository.Delete(id);
                retornoDTO.Value = true;

            }, MensagemSistema.FormataMensagem(MensagemSistema.Excluir, "Pessoa"), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<PessoaViewModel> GetById(int id)
        {
            BaseRetornoDTO<PessoaViewModel> retornoDTO = new BaseRetornoDTO<PessoaViewModel>();

            BaseExceptionSystem<BancoViewModel>.BaseHandleExcetion(() =>
            {
                var banco = _pessoaRepository.GetById(id);

                retornoDTO.Value = BancoMapper.DomainTOViewModel(banco);

            }, MensagemSistema.FormataMensagem(MensagemSistema.NenhumResultadoEncontrado, "Banco"), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<int> Insert(PessoaViewModel t)
        {
            throw new NotImplementedException();
        }

        public BaseRetornoDTO<List<PessoaViewModel>> SelectAll()
        {
            throw new NotImplementedException();
        }

        public BaseRetornoDTO<bool> Update(PessoaViewModel t)
        {
            throw new NotImplementedException();
        }
    }
}

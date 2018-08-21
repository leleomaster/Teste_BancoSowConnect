using AutoMapper;
using BancoSowConnect.Aplication.Service.Interfaces;
using BancoSowConnect.Domain.Entity;
using BancoSowConnect.Domain.Entity.Business.Interfaces;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using BancoSowConnect.Infrastructure.Repository.Interfaces;
using System.Collections.Generic;

namespace BancoSowConnect.Aplication.Service.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IBancoBusiness _bancoBusiness;

        public BancoService(IBancoRepository bancoRepository, IBancoBusiness bancoBusiness)
        {
            _bancoRepository = bancoRepository;
            _bancoBusiness = bancoBusiness;
        }

        public BaseRetornoDTO<bool> Delete(int id)
        {
            BaseRetornoDTO<bool> retornoDTO = new BaseRetornoDTO<bool>();

            BaseExceptionSystem<bool>.BaseHandleExcetion(() =>
            {
                _bancoRepository.Delete(id);
                retornoDTO.Value = true;

            }, MensagemSistema.FormataMensagem(MensagemSistema.Excluir, MensagemSistema.Banco), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<BancoViewModel> GetById(int id)
        {
            BaseRetornoDTO<BancoViewModel> retornoDTO = new BaseRetornoDTO<BancoViewModel>();

            BaseExceptionSystem<BancoViewModel>.BaseHandleExcetion(() =>
            {
                var banco = _bancoRepository.GetById(id);

                retornoDTO.Value = Mapper.Map<BancoEntity, BancoViewModel>(banco);

            }, MensagemSistema.FormataMensagem(MensagemSistema.NenhumResultadoEncontrado, MensagemSistema.Banco), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<int> Insert(BancoViewModel t)
        {
            BaseRetornoDTO<int> retornoDTO = new BaseRetornoDTO<int>();

            BaseExceptionSystem<int>.BaseHandleExcetion(() =>
            {
                var banco = Mapper.Map<BancoViewModel, BancoEntity>(t);

                retornoDTO.Value = _bancoRepository.Insert(banco);

            }, MensagemSistema.FormataMensagem(MensagemSistema.Cadastrar, MensagemSistema.Banco), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<List<BancoViewModel>> SelectAll()
        {
            BaseRetornoDTO<List<BancoViewModel>> retornoDTO = new BaseRetornoDTO<List<BancoViewModel>>();

            BaseExceptionSystem<List<BancoViewModel>>.BaseHandleExcetion(() =>
            {
                var listaBanco = _bancoRepository.SelectAll();

                retornoDTO.Value = new List<BancoViewModel>();

                foreach (var bancoEntity in listaBanco)
                {
                    retornoDTO.Value.Add(Mapper.Map<BancoEntity,BancoViewModel>(bancoEntity));
                }

            }, MensagemSistema.FormataMensagem(MensagemSistema.NenhumResultadoEncontrado, MensagemSistema.Banco), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<bool> Update(BancoViewModel t)
        {
            BaseRetornoDTO<bool> retornoDTO = new BaseRetornoDTO<bool>();

            BaseExceptionSystem<bool>.BaseHandleExcetion(() =>
            {
                var banco = Mapper.Map<BancoViewModel, BancoEntity>(t);
                _bancoRepository.Update(banco);
                retornoDTO.Value = true;

            }, MensagemSistema.FormataMensagem(MensagemSistema.Alterar, MensagemSistema.Banco), ref retornoDTO);

            return retornoDTO;
        }
    }
}

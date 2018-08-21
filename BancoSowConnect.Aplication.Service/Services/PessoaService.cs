using AutoMapper;
using BancoSowConnect.Aplication.Service.Interfaces;
using BancoSowConnect.Domain.Entity;
using BancoSowConnect.Domain.Entity.Business;
using BancoSowConnect.Domain.Entity.Business.Interfaces;
using BancoSowConnect.Domain.Model.ReturnPattern;
using BancoSowConnect.Domain.Model.ViewModels;
using BancoSowConnect.Infrastructure.Repository;
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
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IContaRepository _contaRepository;
        private readonly IPessoaBusiness _pessoaBusiness;

        public PessoaService(IPessoaRepository pessoaRepository, IPessoaBusiness pessoaBusiness,
            IDocumentoRepository documentoRepository, IContaRepository contaRepository)
        {
            _pessoaRepository = pessoaRepository;
            _documentoRepository = documentoRepository;
            _contaRepository = contaRepository;
            _pessoaBusiness = pessoaBusiness;
        }

        public BaseRetornoDTO<bool> Delete(int id)
        {
            BaseRetornoDTO<bool> retornoDTO = new BaseRetornoDTO<bool>();

            BaseExceptionSystem<bool>.BaseHandleExcetion(() =>
            {
                _pessoaRepository.Delete(id);
                retornoDTO.Value = true;

            }, MensagemSistema.FormataMensagem(MensagemSistema.Excluir, MensagemSistema.Pessoa), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<PessoaViewModel> GetById(int id)
        {
            BaseRetornoDTO<PessoaViewModel> retornoDTO = new BaseRetornoDTO<PessoaViewModel>();

            BaseExceptionSystem<PessoaViewModel>.BaseHandleExcetion(() =>
            {
                var pessoaEntity = _pessoaRepository.GetById(id);

                retornoDTO.Value = Mapper.Map<PessoaEntity, PessoaViewModel>(pessoaEntity);

            }, MensagemSistema.FormataMensagem(MensagemSistema.NenhumResultadoEncontrado, MensagemSistema.Pessoa), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<List<PessoaViewModel>> GetByName(string name)
        {
            BaseRetornoDTO<List<PessoaViewModel>> retornoDTO = new BaseRetornoDTO<List<PessoaViewModel>>();

            BaseExceptionSystem<List<PessoaViewModel>>.BaseHandleExcetion(() =>
            {
                List<PessoaEntity> listapessoa = _pessoaRepository.GetByName(name).ToList();

                retornoDTO.Value = Mapper.Map<List<PessoaEntity>, List<PessoaViewModel>>(listapessoa);

            }, MensagemSistema.FormataMensagem(MensagemSistema.NenhumResultadoEncontrado, MensagemSistema.Pessoa), ref retornoDTO);

            return retornoDTO;
        }
    
        public BaseRetornoDTO<int> Insert(PessoaViewModel t)
        {
            BaseRetornoDTO<int> retornoDTO = new BaseRetornoDTO<int>();

            BaseExceptionSystem<int>.BaseHandleExcetion(() =>
            {
                BaseTransactionScope.WapperWrapper(() =>
                {
                    var pessoa = Mapper.Map<PessoaViewModel, PessoaEntity>(t);

                    retornoDTO.Value = _pessoaRepository.Insert(pessoa);

                    pessoa.Conta.Numero = ContaNumeroBusiness.GerarNumero();
                    pessoa.Conta.Pessoa = new PessoaEntity() { Id = retornoDTO.Value };
                    _contaRepository.Insert(pessoa.Conta);

                    foreach (var documento in pessoa.Documentos)
                    {
                        _documentoRepository.Insert(documento);
                    }

                });
            }, MensagemSistema.FormataMensagem(MensagemSistema.Cadastrar, MensagemSistema.Pessoa), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<List<PessoaViewModel>> SelectAll()
        {
            BaseRetornoDTO<List<PessoaViewModel>> retornoDTO = new BaseRetornoDTO<List<PessoaViewModel>>();

            BaseExceptionSystem<List<PessoaViewModel>>.BaseHandleExcetion(() =>
            {
                var listapessoa = _pessoaRepository.SelectAll().ToList();
                
                retornoDTO.Value = Mapper.Map<List<PessoaEntity>, List<PessoaViewModel>>(listapessoa);

            }, MensagemSistema.FormataMensagem(MensagemSistema.NenhumResultadoEncontrado, MensagemSistema.Pessoa), ref retornoDTO);

            return retornoDTO;
        }

        public BaseRetornoDTO<bool> Update(PessoaViewModel t)
        {
            BaseRetornoDTO<bool> retornoDTO = new BaseRetornoDTO<bool>();

            BaseExceptionSystem<bool>.BaseHandleExcetion(() =>
            {
                BaseTransactionScope.WapperWrapper(() =>
                {
                    var pessoa = Mapper.Map<PessoaViewModel, PessoaEntity>(t);

                    _pessoaRepository.Update(pessoa);
                    _contaRepository.Update(pessoa.Conta);

                    foreach (var documento in pessoa.Documentos)
                    {
                        _documentoRepository.Update(documento);
                    }

                    retornoDTO.Value = true;
                });
            }, MensagemSistema.FormataMensagem(MensagemSistema.Alterar, MensagemSistema.Pessoa), ref retornoDTO);

            return retornoDTO;
        }
    }
}

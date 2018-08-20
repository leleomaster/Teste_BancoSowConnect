using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity.Mappers
{
    public static class PessoaMapper
    {
        public static PessoaViewModel DomainTOViewModel(PessoaEntity pessoa)
        {
            return new PessoaViewModel
            {
                Id = pessoa.Id,
                IdUsuario = pessoa.IdUsuarioCrio,
                Nome = pessoa.Nome
            };
        }

        public static PessoaEntity ViewModelToDomain(PessoaViewModel pessoa)
        {
            return new PessoaEntity
            {
                Id = pessoa.Id,
                IdUsuarioCrio = pessoa.IdUsuario,
                Nome = pessoa.Nome
            };
        }
    }
}

using BancoSowConnect.Domain.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Domain.Entity.Mappers
{
    public static class BancoMapper
    {
        public static BancoViewModel DomainTOViewModel(BancoEntity banco)
        {
            return new BancoViewModel
            {
                Id = banco.Id,
                IdUsuario = banco.IdUsuarioCrio,
                Nome = banco.Nome
            };
        }

        public static BancoEntity ViewModelToDomain(BancoViewModel banco)
        {
            return new BancoEntity
            {
                Id = banco.Id,
                IdUsuarioCrio = banco.IdUsuario,
                Nome = banco.Nome
            };
        }
    }
}

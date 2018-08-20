using BancoSowConnect.Aplication.Service.Interfaces;
using BancoSowConnect.Aplication.Service.Services;
using BancoSowConnect.Domain.Entity.Business.Implementation;
using BancoSowConnect.Domain.Entity.Business.Interfaces;
using BancoSowConnect.Infrastructure.Repository.Interfaces;
using BancoSowConnect.Infrastructure.Repository.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Infrastructure.IoC
{
    public static class NinjectRegister
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            // AplicationService
            kernel.Bind<IBancoService>().To<BancoService>();


            // Business
            kernel.Bind<IBancoBusiness>().To<BancoBusiness>();           


            // Repository
            kernel.Bind<IBancoRepository>().To<BancoRepository>();
            kernel.Bind<IFactoryConnection>().To<FactoryConnection>();


        }
    }
}

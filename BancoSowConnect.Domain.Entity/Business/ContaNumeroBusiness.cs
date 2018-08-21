using BancoSowConnect.Domain.Entity.Business.Interfaces;
using System;

namespace BancoSowConnect.Domain.Entity.Business
{
    public static class ContaNumeroBusiness
    {
        public static decimal GerarNumero()
        {
            string numero = null;
            Random rnd = new Random();

            for (int ctr = 1; ctr <= 4; ctr++)
            {
                numero += rnd.Next(1000, 10001);
            }
            return Convert.ToDecimal(numero);
        }
    }
}

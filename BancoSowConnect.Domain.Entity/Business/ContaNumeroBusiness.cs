using BancoSowConnect.Domain.Entity.Business.Interfaces;
using System;
using System.Linq;

namespace BancoSowConnect.Domain.Entity.Business
{
    public static class ContaNumeroBusiness
    {
        public static string NumeroTransacao { get; set; }

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

        public static string FormatarTransacao()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            NumeroTransacao = new string(Enumerable.Repeat(chars, 15)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            // Numero de transacao formatado
            return NumeroTransacao;
        }
    }
}

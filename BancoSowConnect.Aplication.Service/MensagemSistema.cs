using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoSowConnect.Aplication.Service
{
    public class MensagemSistema
    {
        public const string SqlException = "Banco de dados indisponível, tente mais tarde.";
        public const string TimeoutException = "Sistema está com muitos acessos, tente mais tarde.";
        public const string NullReferenceException = "Ocorreu um erro no sistema, favor entrar em contato com o administrador do sistema.";
        public const string DefaultException = "Erro disconhecido.";

        public const string Cadastrar = "{0} cadastrado com suscesso.";
        public const string Excluir = "{0} excluído com suscesso.";
        public const string Alterar = "{0} alterado com suscesso.";
        public const string NenhumResultadoEncontrado = "Nenhum restulado encontrado para a pesquisa do {0}";

        public const string APIIndisponivel = "API indisponível. tente novamente mais tarde";

        public const string Banco = "Banco";
        public const string Pessoa = "Pessoa";
        public const string Conta = "Conta";
        public const string Documento = "Documento";

        public static string FormataMensagem(string mensagem, string texto)
        {
            return string.Format(mensagem, texto);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using PersonalNutri.Dominio.VO;
using PersonalNutri.UI.Console.Util;

namespace PersonalNutri.UI.Console.Helpers
{
    public class CadastroDeClienteHelper
    {
        public Nome ObterNome()
        {
            string primeiroNome = "";
            string texto = "";
            do
            {
                texto = "Primeiro Nome: ";
                ConsoleUtil.Escrever(texto);
                primeiroNome = ConsoleUtil.LerEntradaDoUsuario();
            } while (string.IsNullOrEmpty(primeiroNome));

            texto = "Sobrenome:";
            ConsoleUtil.Escrever(texto);
            var sobrenome = ConsoleUtil.LerEntradaDoUsuario();

            var nome = new Nome(primeiroNome, sobrenome);
            return nome; ;
        }

        public Endereco ObterEndereco()
        {
            //TODO: INTEGRAÇÃO COM API DE CEPS
            //TODO: VALIDAÇÃO DOS FORMATOS DOS CAMPOS DIGITADDOS

            string texto = "CEP: ";
            ConsoleUtil.Escrever(texto);
            var cep = ConsoleUtil.LerEntradaDoUsuario();

            texto = "Rua: ";
            ConsoleUtil.Escrever(texto);
            var rua = ConsoleUtil.LerEntradaDoUsuario();

            texto = "Bairro: ";
            ConsoleUtil.Escrever(texto);
            var bairro = ConsoleUtil.LerEntradaDoUsuario();

            texto = "Cidade: ";
            ConsoleUtil.Escrever(texto);
            var cidade = ConsoleUtil.LerEntradaDoUsuario();

            texto = "Numero: ";
            ConsoleUtil.Escrever(texto);
            var numero = ConsoleUtil.LerEntradaDoUsuario();

            texto = "Complemento: ";
            ConsoleUtil.Escrever(texto);
            var complemento = ConsoleUtil.LerEntradaDoUsuario();

            texto = "UF: ";
            ConsoleUtil.Escrever(texto);
            var uf = ConsoleUtil.LerEntradaDoUsuario();

            return new Endereco()
            {
                Cep = long.Parse(cep),
                Bairro = bairro,
                Cidade = cidade,
                LinhaDeEndereco = rua,
                Complemento = complemento,
                Numero = int.Parse(numero),
                Uf = uf
            };
        }

        public DateTime ObterDataDeNascimento()
        {
            DateTime dataRetorno = DateTime.Now;
            string dataNascimento = "";
            string texto = "Data de nascimeto (ddMMAAAA): ";
            do
            {
                ConsoleUtil.Escrever(texto);
                dataNascimento = ConsoleUtil.LerEntradaDoUsuario();


            } while (dataNascimento != null && DateTime.TryParseExact(dataNascimento, "ddMMyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataRetorno) == false);

            return dataRetorno;
        }

        public Email ObterEmail()
        {
            string texto = "E-Mail: ";
            string emailInformado = "";

            do
            {
                ConsoleUtil.Escrever(texto);
                emailInformado = ConsoleUtil.LerEntradaDoUsuario();

            } while (Email.EhValido(emailInformado) == false);

            return new Email(emailInformado);

        }

        public IEnumerable<Telefone> ObterTelefones()
        {
            List<Telefone> telefones = new List<Telefone>();
            
            string texto = "Adicionar outro telefone? [S/N]: ";
            string addOutro = "";

            do
            {
                var telefone = ObterTelefone();
                telefones.Add(telefone);
                ConsoleUtil.Escrever(texto);
                addOutro = ConsoleUtil.LerEntradaDoUsuario();

            } while (addOutro.ToUpper().Equals("S"));
            
            return telefones;
            }

        public Telefone ObterTelefone()
        {

            string texto = "Telefone (99999999999): ";
            string telefoneInformado = "";
            long telefoneNumerico = 0;
            do
            {
                ConsoleUtil.Escrever(texto);
                telefoneInformado = ConsoleUtil.LerEntradaDoUsuario();
                long.TryParse(telefoneInformado, out telefoneNumerico);

            } while (telefoneNumerico == 0 || Telefone.EhValido(telefoneNumerico) == false);

            return new Telefone(telefoneNumerico);
        }
    }
}

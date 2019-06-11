using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Dominio.Testes.Entidades
{
    [TestClass]
    public class ComoUmCliente
    {
        [TestMethod]
        public void DevePermitirInclusaoDeTelefones()
        {
            var nome = new Nome("Weberth", "Soares");
            var endereco = RetornarEnderecoValido();
            var dataNascimento = new DateTime(1990,8,16);
            var email = new Email("teste@teste.com.br");
            var telefones = new List<Telefone>() { new Telefone(31988778787) };
            var cliente = new Cliente(nome, endereco, dataNascimento, email, telefones);


            //incluir um telefone
            long telefoneDeTeste = 31988776655;
            cliente.AdicionarTelefone(telefoneDeTeste);

            var telefonesDoCliente = cliente.Telefones;

            //validar a existência do telefone
            Assert.IsTrue(telefonesDoCliente.Any(x=>x.Numero == telefoneDeTeste));

        }
        [TestMethod]
        public void DevePermitirAlteracaoDONome()
        {
            var nomeInicial = new Nome("Weberth", "Soares");
            var nomeAlterado = new Nome("Joao", "Silva");
            var endereco = RetornarEnderecoValido();
            var dataNascimento = new DateTime(1990, 8, 16);
            var email = new Email("teste@teste.com.br");
            var telefones = new List<Telefone>() {new Telefone(31988778787)};
            var cliente = new Cliente(nomeInicial, endereco, dataNascimento,email,telefones);

            //Validar nome atual
            Assert.AreEqual(cliente.Nome, nomeInicial);

            cliente.AlterarNome(nomeAlterado);

            //Validar novo nome
            Assert.AreEqual(cliente.Nome, nomeAlterado);
        }

        private Endereco RetornarEnderecoValido()
        {
            var endereco = new Endereco()
            {
                Cep = 31742260,
                Bairro = "FLORAMAR",
                Cidade = "BELO HORIZONTE",
                LinhaDeEndereco = "R. ALGA VERMELHA",
                Numero = 120,
                Complemento = ""
            };

            return endereco;}
    }
}

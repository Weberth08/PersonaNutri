using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Dominio.Testes.Entidades
{
    [TestClass]
    public class ComoUmaConsultaNutricional
    {
        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void DeveRetornarErroAoInformarPesoMenorOuIgualAZero()
        {
            var dataDaConsulta = DateTime.Today.AddDays(1);
            var paciente = RetornarUmClienteValido(); //Poderia ser mockado, ou movido para uma classe especializada
            
            decimal pesoDoPaciente = -50;
            decimal porcentagemGordura = 15;
            var restricoes = "";
            var sensacaoFisica = "";

            var consulta = new ConsultaNutricional(paciente, dataDaConsulta,pesoDoPaciente,porcentagemGordura,restricoes,sensacaoFisica);
      }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void DeveRetornarErroAoInformarPorcentagemDeGorduraMenorQueZero()
        {
            DateTime dataDaConsulta = DateTime.Today.AddDays(1);
            var paciente = RetornarUmClienteValido(); //Poderia ser mockado, ou movido para uma classe especializada
            decimal pesoDoPaciente = 70;
            decimal porcentagemGordura = -10;
            var restricoes = "";
            var sensacaoFisica = "";

            var consulta = new ConsultaNutricional(paciente, dataDaConsulta, pesoDoPaciente, porcentagemGordura, restricoes, sensacaoFisica);
        }

        private Cliente RetornarUmClienteValido()
        {
            var cliente = new Cliente(
                nome: new Nome("Weberth", "Soares"),
                endereco: new Endereco(),
                dataDeNascimento: new DateTime(1990, 8, 15),
                email:new Email("teste@teste.com.br"),
                telefones:new List<Telefone>() { new Telefone(31988989898)}
                );

            return cliente;
        }
    }
}

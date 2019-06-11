using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalNutri.Dominio.Entidades;

namespace PersonalNutri.Dominio.Testes.Entidades
{
    [TestClass]
    public class ComoUmGrupoDeAlimentos
    {
        [TestMethod]
        public void DevePermitirAdicionarAlimentos()
        {
            var grupo = new GrupoDeAlimento("Grupo 01");
            var alimento1 = new Alimento(grupo, "Laranja", 100);
            var alimento2 = new Alimento(grupo, "Lasanha", 500);

            grupo.AdicionarAlimento(alimento1);
            grupo.AdicionarAlimento(alimento2);

            Assert.AreEqual(grupo.Alimentos.Count(),2);
            Assert.IsTrue(grupo.Alimentos.Any(x=>x.Id == alimento1.Id));
            Assert.IsTrue(grupo.Alimentos.Any(x => x.Id == alimento2.Id));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void DeveRetornarErroAoAdicionarUmProdutoJaExistente()
        {
            var grupo = new GrupoDeAlimento("Grupo 01");
            var alimento1 = new Alimento(grupo, "Laranja", 100);
            var alimento2 = new Alimento(grupo, "Lasanha", 500);

            grupo.AdicionarAlimento(alimento1);
            grupo.AdicionarAlimento(alimento2);

            //forçar o erro
            grupo.AdicionarAlimento(alimento1);
        }
    }
}

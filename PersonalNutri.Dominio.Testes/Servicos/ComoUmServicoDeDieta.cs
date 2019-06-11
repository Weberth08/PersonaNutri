using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.Repositorios;
using PersonalNutri.Dominio.Servicos;

namespace PersonalNutri.Dominio.Testes.Servicos
{
    [TestClass]
    public class ComoUmServicoDeDieta
    {
        [TestMethod]
        public void ACombinacaoDeProdutosNaoPodeUltrapassarAMetaCalorica()
        {
            IRepositorioDeGrupoDeAlimentos repositorioDeGrupos = new RepositorioDeGrupoDeAlimentos();//poderia ser Mockado
            IServicoDeDieta servicoDieta = new ServicoDeDieta(repositorioDeGrupos);

            decimal metaCalorica = 300;

            var combinacoes = servicoDieta.GerarCombinacoesDeAlimentosDeAcordoComAMetaCalorica(metaCalorica, 1);

            Assert.IsTrue(combinacoes.Any());

           foreach (var combinacaoDeAlimentosDeDieta in combinacoes)
           {
               var totalCalorico = combinacaoDeAlimentosDeDieta.Alimentos.Sum(x => x.ValorCalorico);

                Assert.IsTrue(totalCalorico <= metaCalorica);
           }

        }

        [TestMethod]
        public void OTotalDeProdutosDoMesmoGrupoNaoPodeUltrapassarODefinido()
        {
            IRepositorioDeGrupoDeAlimentos repositorioDeGrupos = new RepositorioDeGrupoDeAlimentos();//poderia ser Mockado
            IServicoDeDieta servicoDieta = new ServicoDeDieta(repositorioDeGrupos);

            decimal metaCalorica = 200;
            int totalProdutosMesmoGrupo = 1;

            var combinacoes = servicoDieta.GerarCombinacoesDeAlimentosDeAcordoComAMetaCalorica(metaCalorica, totalProdutosMesmoGrupo);

            Assert.IsTrue(combinacoes.Any());

            foreach (var combinacaoDeAlimentosDeDieta in combinacoes)
            {
                int totalDeElementos = combinacaoDeAlimentosDeDieta.Alimentos.Count();

                var totalDeGruposDistintos = combinacaoDeAlimentosDeDieta
                    .Alimentos
                    .GroupBy(x => x.GrupoDeAlimento.Id)
                    .Select(x => x.Key)
                    .Count();

                Assert.AreEqual(totalDeElementos,totalDeGruposDistintos);
            }

        }
    }
}

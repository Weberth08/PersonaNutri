using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Dominio.Servicos
{
    public class ServicoDeDieta : IServicoDeDieta
    {
        private readonly IRepositorioDeGrupoDeAlimentos _repositorioDeGruposAlimentares;

        public ServicoDeDieta(IRepositorioDeGrupoDeAlimentos repositorioDegrupos)
        {
            _repositorioDeGruposAlimentares = repositorioDegrupos;
        }

        public IEnumerable<CombinacaoDeAlimentosDeDieta> GerarCombinacoesDeAlimentosDeAcordoComAMetaCalorica(decimal metaCalorica, int maximoDeAlimentosPorGrupo)
        {
            //TODO: IMPLEMENTAR OUTRO ALGORITMO COM PERFORMANCE E ESTRUTURA MELHORES
            //TODO: ATUALMENTE ESTÁ LIMITADO A UM NÚMERO DE GRUPOS

            var grupos = _repositorioDeGruposAlimentares.RetornarGruposDeAlimentos().ToList();
            var combinacoes = new List<CombinacaoDeAlimentosDeDieta>();

            var alimentos1 = grupos[0].Alimentos;
            var alimentos2 = grupos[1].Alimentos;
            var alimentos3 = grupos[2].Alimentos;

            var produtoCartesiano = from a1 in alimentos1
                                    from a2 in alimentos2
                                    from a3 in alimentos3
                                    where ((a1.ValorCalorico + a2.ValorCalorico + a3.ValorCalorico) <= metaCalorica)
                                    select new CombinacaoDeAlimentosDeDieta(new List<Alimento>() { a1, a2, a3 });


            combinacoes.AddRange(produtoCartesiano);

            return combinacoes;
        }
    }
}


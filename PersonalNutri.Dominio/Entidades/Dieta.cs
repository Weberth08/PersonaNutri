using System.Collections.Generic;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Dominio.Entidades
{
    public class Dieta
    {
        private readonly IServicoDeDieta _servicoDeDeDieta;
        public decimal MetaDeConsumoCalorico { get; protected set; }
        public int MaximoDeAlimentosPermitidoPorGrupo { get; protected set; }

        public Dieta(IServicoDeDieta servicoDeDieta, decimal metaDeConsumoCalorico)
        {
            _servicoDeDeDieta = servicoDeDieta;
            MetaDeConsumoCalorico = metaDeConsumoCalorico;
        }

       public IEnumerable<CombinacaoDeAlimentosDeDieta> ObterCombinacaoDeAlimentos(int maximoDeAlimentosPorGrupo)
        {
            var combinacao = _servicoDeDeDieta.GerarCombinacoesDeAlimentosDeAcordoComAMetaCalorica(
                metaCalorica: MetaDeConsumoCalorico, maximoDeAlimentosPorGrupo: maximoDeAlimentosPorGrupo);
            return combinacao;
        }

    }
}

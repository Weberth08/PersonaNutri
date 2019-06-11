using System.Collections.Generic;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Dominio.Interfaces
{
    public interface IServicoDeDieta
    {
        IEnumerable<CombinacaoDeAlimentosDeDieta> GerarCombinacoesDeAlimentosDeAcordoComAMetaCalorica(decimal metaCalorica, int maximoDeAlimentosPorGrupo);
    } 
}

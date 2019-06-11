using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNutri.Dominio.Entidades;

namespace PersonalNutri.Dominio.VO
{
    public class CombinacaoDeAlimentosDeDieta
    {
        private readonly List<Alimento> _alimentos;
        public IEnumerable<Alimento> Alimentos => _alimentos;
        public decimal TotalCalorico => _alimentos.Sum(x => x.ValorCalorico);

        public CombinacaoDeAlimentosDeDieta()
        {
            _alimentos = new List<Alimento>();
        }

        public CombinacaoDeAlimentosDeDieta(IEnumerable<Alimento> alimentos)
        {
            _alimentos = new List<Alimento>();
            _alimentos.AddRange(alimentos);
        }

        public void AdicionarAlimento(Alimento alimento)
        {
            if(alimento is null)
                throw  new ArgumentNullException(nameof(alimento));

            _alimentos.Add(alimento);
        }
        
    }
}

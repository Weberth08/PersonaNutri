using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PersonalNutri.Dominio.Entidades
{
    public class GrupoDeAlimento
    {
        private readonly IList<Alimento> _alimentos;

        public GrupoDeAlimento(string nome)
        {
            Id = Guid.NewGuid();
            _alimentos = new List<Alimento>();

            Nome = nome;
        }

        public Guid Id { get; protected set; }
        public IEnumerable<Alimento> Alimentos => _alimentos;
        public string Nome { get; protected set; }

       public void AdicionarAlimento(Alimento alimento)
        {
            if (alimento is null)
                throw new ArgumentNullException(nameof(alimento));

            if(_alimentos.Any(x=>x.Id == alimento.Id))
                throw new ArgumentException("O Alimento informado já existe");

            _alimentos.Add(alimento);
        }
    }
}

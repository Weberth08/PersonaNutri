using System;

namespace PersonalNutri.Dominio.Entidades
{
    public class Alimento
    {
        public Alimento(GrupoDeAlimento grupo, string nome, decimal valorCalorico)
        {
            if (grupo is null)
                throw new ArgumentNullException(nameof(grupo));

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome do Alimento não pode ser nulo ou vazio");

            if (valorCalorico < 0)
                throw new ArgumentException("Valor calórico do Alimento não pode ser menor que zero");

            Id = Guid.NewGuid();
            GrupoDeAlimento = grupo;
            Nome = nome;
            ValorCalorico = valorCalorico;
        }

        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public decimal ValorCalorico { get; protected set; }
        public GrupoDeAlimento GrupoDeAlimento { get; protected set; }
    }
}

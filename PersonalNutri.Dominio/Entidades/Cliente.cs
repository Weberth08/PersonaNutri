using PersonalNutri.Dominio.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNutri.Dominio.Util;

namespace PersonalNutri.Dominio.Entidades
{
    public class Cliente
    {
        public Cliente(Nome nome, Endereco endereco,DateTime dataDeNascimento, Email email, IEnumerable<Telefone> telefones)
        {
            if(nome is null)
                throw new ArgumentNullException(nameof(nome));

            if (endereco is null)
                throw new ArgumentNullException(nameof(endereco));

            if (email is null)
                throw new ArgumentNullException(nameof(email));

            if (telefones is null)
                throw new ArgumentNullException(nameof(telefones));


            //removido o GUID para facilitar a busca no exemplo
            Id = GeradorDeId.ObterIdUnico(); //Guid.NewGuid();

            Nome = nome;
            Endereco = endereco;
            DataDeNascimento = dataDeNascimento;
            Email = email;
            _telefones = new List<Telefone>();
            _telefones.AddRange(telefones);

        }

        public long Id { get; protected set; }
        public Nome Nome { get; protected set; }
        public Endereco Endereco { get; protected set; }
        public DateTime DataDeNascimento { get; protected set; }
        public Email Email { get; protected set; }

        private readonly List<Telefone> _telefones;
        public IEnumerable<Telefone> Telefones => _telefones;

        public void AdicionarTelefone(long numero)
        {
            _telefones.Add(new Telefone(numero));
        }

        public void AlterarNome(Nome novoNome)
        {
            if (novoNome is null)
                throw new ArgumentException(nameof(novoNome));

            Nome = novoNome;
        }

        public void AlterarEndereco(Endereco novoEndereco)
        {
            if (novoEndereco is null)
                throw new ArgumentException(nameof(novoEndereco));

            Endereco = novoEndereco;
        }

        public void AlterarDataDeNascimento(DateTime novaDataDeNascimento)
        {
          DataDeNascimento = novaDataDeNascimento;
        }
    }
}

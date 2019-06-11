using System;
using System.Collections.Generic;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Aplicacao.Aplicacao
{
    public class ClienteApp
    {
        private readonly IRepositorioDeClientes _repositorioDeClientes;

        public ClienteApp(IRepositorioDeClientes repoClientes)
        {
            _repositorioDeClientes = repoClientes;
        }

        public Cliente CriarCliente(Nome nome, Endereco endereco, DateTime dataDeNascimento, Email email,IEnumerable<Telefone> telefones)
        {
            var cliente = new Cliente(nome, endereco, dataDeNascimento,email,telefones);
            //validacoes sobre a existencia de um mesmo cliente, outras regras de negocio

            cliente = _repositorioDeClientes.Gravar(cliente);

            return cliente;
        }

        public IEnumerable<Cliente> RetornarClientes()
        {
            return _repositorioDeClientes.RetornarClientes();
        }

        public Cliente ObterClientePeloId(long id)
        {
           var cliente = _repositorioDeClientes.ObterClientePeloId(id);

            return cliente;
        }
    }
}

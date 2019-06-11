using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.VO;

namespace PersonalNutri.Dominio.Repositorios
{
    public class RepositorioDeClientes : IRepositorioDeClientes
    {
        private readonly IList<Cliente> _baseDeClientes;

        public RepositorioDeClientes()
        {
            //poderia ser um banco, arquivo, etc
            _baseDeClientes = new List<Cliente>();
            CarregarBaseInicial();
        }

        public Cliente Gravar(Cliente cliente)
        {
            _baseDeClientes.Add(cliente);
            return cliente;
        }

        public IEnumerable<Cliente> RetornarClientes()
        {
            return _baseDeClientes;
        }

        public Cliente ObterClientePeloId(long idCliente)
        {
            var cliente = _baseDeClientes.FirstOrDefault(x => x.Id == idCliente);
            return cliente;
        }

        private void CarregarBaseInicial()
        {
            var telefones = new List<Telefone>(){ new Telefone(31987447474)};

            var cliente1 = new Cliente(
                nome: new Nome("JOÃO", "DA SILVA"),
               endereco: new Endereco() { Bairro = "CENTRO", Cep = 31787676, Cidade = "BELO HORIZONTE", Complemento = "", LinhaDeEndereco = "RUA A", Numero = 30 },
               dataDeNascimento: new DateTime(1990, 06, 28),
               email:new Email("cliente.teste@provedor.com.br"), 
               telefones: telefones
                );
            var cliente2 = new Cliente(
                nome: new Nome("WEBERTH", "SOARES"),
                endereco: new Endereco() { Bairro = "FLORAMAR", Cep = 31889989, Cidade = "BELO HORIZONTE", Complemento = "", LinhaDeEndereco = "RUA DE CIMA", Numero = 450 },
                dataDeNascimento: new DateTime(1990, 08, 16),
                email: new Email("cliente.teste@provedor.com.br"),
                telefones: telefones
            );
            var cliente3 = new Cliente(
                nome: new Nome("JOÃO", "DA SILVAA"),
                endereco: new Endereco() { Bairro = "CENTRO", Cep = 313313131, Cidade = "BETIM", Complemento = "", LinhaDeEndereco = "RUA 20", Numero = 80 },
                dataDeNascimento: new DateTime(1990, 06, 28),
                email: new Email("cliente.teste@provedor.com.br"),
                telefones: telefones
            );
            var cliente4 = new Cliente(
                nome: new Nome("JOÃO", "DA SILVAA"),
                endereco: new Endereco() { Bairro = "CENTRO", Cep = 313313131, Cidade = "BELO HORIZONTE", Complemento = "", LinhaDeEndereco = "RUA A", Numero = 30 },
                dataDeNascimento: new DateTime(1990, 06, 28),
                email: new Email("cliente.teste@provedor.com.br"),
                telefones: telefones
            );
            var cliente5 = new Cliente(
                nome: new Nome("JOÃO", "DA SILVAA"),
                endereco: new Endereco() { Bairro = "CENTRO", Cep = 313313131, Cidade = "BELO HORIZONTE", Complemento = "", LinhaDeEndereco = "RUA A", Numero = 30 },
                dataDeNascimento: new DateTime(1990, 06, 28),
                email: new Email("cliente.teste@provedor.com.br"),
                telefones: telefones
            );


            _baseDeClientes.Add(cliente1);
            _baseDeClientes.Add(cliente2);
            _baseDeClientes.Add(cliente3);
            _baseDeClientes.Add(cliente4);
            _baseDeClientes.Add(cliente5);
        }
    }
}

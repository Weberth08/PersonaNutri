using System.Collections.Generic;
using PersonalNutri.Dominio.Entidades;

namespace PersonalNutri.Dominio.Interfaces
{
   public interface IRepositorioDeClientes
    {
        Cliente Gravar(Cliente cliente);
        IEnumerable<Cliente> RetornarClientes();
        Cliente ObterClientePeloId(long cliente);
    }
}

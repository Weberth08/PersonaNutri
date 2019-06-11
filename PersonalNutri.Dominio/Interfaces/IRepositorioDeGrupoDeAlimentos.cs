using System.Collections.Generic;
using PersonalNutri.Dominio.Entidades;

namespace PersonalNutri.Dominio.Interfaces
{
   public interface IRepositorioDeGrupoDeAlimentos
    {
        IEnumerable<GrupoDeAlimento> RetornarGruposDeAlimentos();
    }
}

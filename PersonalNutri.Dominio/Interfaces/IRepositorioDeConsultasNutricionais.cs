using System.Collections.Generic;
using PersonalNutri.Dominio.Entidades;

namespace PersonalNutri.Dominio.Interfaces
{
    public interface IRepositorioDeConsultasNutricionais
    {
        ConsultaNutricional Gravar(ConsultaNutricional consulta);

        IEnumerable<ConsultaNutricional> RetornarConsultas();

        IEnumerable<ConsultaNutricional> RetornarConsultasDoPaciente(long codigoCliente);
    }
}

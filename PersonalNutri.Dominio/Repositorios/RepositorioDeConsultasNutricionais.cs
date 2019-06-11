using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;

namespace PersonalNutri.Dominio.Repositorios
{
    public class RepositorioDeConsultasNutricionais : IRepositorioDeConsultasNutricionais
    {
        private readonly List<ConsultaNutricional> _baseDeConsultaNutricionais;
        public RepositorioDeConsultasNutricionais()
        {
            _baseDeConsultaNutricionais = new List<ConsultaNutricional>();
        }

        public ConsultaNutricional Gravar(ConsultaNutricional consulta)
        {
            _baseDeConsultaNutricionais.Add(consulta);
            return consulta;
        }

        public IEnumerable<ConsultaNutricional> RetornarConsultas()
        {
            return _baseDeConsultaNutricionais;
        }

        public IEnumerable<ConsultaNutricional> RetornarConsultasDoPaciente(long codigoCliente)
        {
            return _baseDeConsultaNutricionais.Where(x => x.Paciente.Id == codigoCliente);
        }
    }
}

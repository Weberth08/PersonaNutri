using System;
using System.Collections.Generic;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;

namespace PersonalNutri.Aplicacao.Aplicacao
{
    public class ConsultaNutricionalApp
    {
        private readonly IServicoDeDieta _servicoDeDieta;
        private readonly IRepositorioDeConsultasNutricionais _repositorioDeConsultasNutricionais;
        public ConsultaNutricionalApp(IRepositorioDeConsultasNutricionais repoConsultas, IServicoDeDieta servicoDeDieta)
        {
            _servicoDeDieta = servicoDeDieta;
            _repositorioDeConsultasNutricionais = repoConsultas;
        }

        public ConsultaNutricional CriarConsultaNutricional(Cliente paciente, DateTime dataDaConsulta, decimal peso, decimal porcentagemDeGordura, string restricoes, string sensacoesFisicas)
        {
            var consulta = new ConsultaNutricional(paciente, dataDaConsulta, peso, porcentagemDeGordura, restricoes, sensacoesFisicas);
            consulta = _repositorioDeConsultasNutricionais.Gravar(consulta);

            return consulta;
        }

        public Dieta CriarDieta(ConsultaNutricional consulta, decimal metaDeConsumoCalorica)
        {
            var dieta = new Dieta(_servicoDeDieta,metaDeConsumoCalorica);
            consulta.EspecificarDieta(dieta);

            return dieta;
        }

        public IEnumerable<ConsultaNutricional> RetornarHistoricoDeConsultasDoPaciente(long idPaciente)
        {
           return _repositorioDeConsultasNutricionais.RetornarConsultasDoPaciente(idPaciente);
        }
    }
}

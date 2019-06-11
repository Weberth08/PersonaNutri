using System;

namespace PersonalNutri.Dominio.Entidades
{
    public class ConsultaNutricional
    {
        public Guid Id { get; protected set; }
        public DateTime DataDaConsuta { get; protected set; }
        public Cliente Paciente { get; protected set; }
        public Dieta DietaDaConsulta { get; protected set; }
        public decimal PesoDoPaciente { get; protected set; }
        public decimal PorcentagemDeGorduraDoPaciente { get; protected set; }
        public string RestricoesAlimentares { get; protected set; }
        public string SensacaoFisicaDoPaciente { get; protected set; }

        public ConsultaNutricional(Cliente paciente,DateTime dataDaConsulta, decimal pesoPaciente, decimal porcentagemDeGordura, string restricoes, string sensacaoFisica)
        {
            Id = Guid.NewGuid();

            if (paciente is null)
                throw new ArgumentNullException(nameof(paciente));

            if (pesoPaciente <= 0)
                throw new ArgumentException("O peso do paciente não pode ser menor ou igual a zero");

            if (porcentagemDeGordura < 0)
                throw new ArgumentException("A porcentagem de gordura do paciente não pode ser menor que zero");

            Paciente = paciente;
            DataDaConsuta = dataDaConsulta;
            PesoDoPaciente = pesoPaciente;
            RestricoesAlimentares = restricoes;
            SensacaoFisicaDoPaciente = sensacaoFisica;
            PorcentagemDeGorduraDoPaciente = porcentagemDeGordura;
        }


        public void EspecificarDieta(Dieta dieta)
        {
            if(dieta is null)
                throw new ArgumentNullException(nameof(dieta));

            DietaDaConsulta = dieta;
        }
    }
}

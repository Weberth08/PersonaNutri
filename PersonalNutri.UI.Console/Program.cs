using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.Repositorios;
using PersonalNutri.Dominio.Servicos;

namespace PersonalNutri.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //INICIALIZAÇÃO: PODERIA ESTAR EM UM DI CONTAINER 
                IRepositorioDeClientes repoClientes = new RepositorioDeClientes();
                IRepositorioDeGrupoDeAlimentos repoGrupos = new RepositorioDeGrupoDeAlimentos();
                IRepositorioDeConsultasNutricionais repoConsultas = new RepositorioDeConsultasNutricionais();
                IServicoDeDieta servicoDieta = new ServicoDeDieta(repoGrupos);

                var personalNutriConsole = new PersonalNutriConsole(repoClientes, repoConsultas, servicoDieta);
                personalNutriConsole.Executar();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Desculpe, ocorreu um erro inesperado.\n Erro: {e.Message} \n StackTrace: {e.StackTrace}");
                System.Console.ReadKey();
                throw;
            }

           

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using PersonalNutri.Aplicacao.Aplicacao;
using PersonalNutri.Dominio.Entidades;
using PersonalNutri.Dominio.Interfaces;
using PersonalNutri.Dominio.VO;
using PersonalNutri.UI.Console.Enums;
using PersonalNutri.UI.Console.Helpers;
using PersonalNutri.UI.Console.Util;

namespace PersonalNutri.UI.Console
{
    class PersonalNutriConsole
    {
        private ClienteApp _clienteApp;
        private DietaApp _dietaApp;
        private readonly ConsultaNutricionalApp _consultaNutricionalApp;

        public PersonalNutriConsole(IRepositorioDeClientes repoClientes,
            IRepositorioDeConsultasNutricionais repositorioDeConsultas,
            IServicoDeDieta servicoDeDieta)
        {
            //Poderia usar um DI Container
            _clienteApp = new ClienteApp(repoClientes);
            _dietaApp = new DietaApp(servicoDeDieta);
            _consultaNutricionalApp = new ConsultaNutricionalApp(repositorioDeConsultas, servicoDeDieta);
        }

        public void Executar()
        {
            string entrada = "";
            do
            {
                entrada = "N";
                ConsoleUtil.LimparConsole();
                ExibirMenuPrincipal();

                string texto = "\nDeseja Sair do sistema? [S/N]: ";
                ConsoleUtil.Escrever(texto);
                entrada = ConsoleUtil.LerEntradaDoUsuario();

            } while (entrada.ToUpper().Equals("S") == false);
            
        }

        private void IrParaProximaAcao()
        {
            string entrada = ObterEntradaDoUsuario();

            int valorEntrada = 0;
            if (int.TryParse(entrada, out valorEntrada))
            {
                OpcaoDeMenu opcaoDeMenu = (OpcaoDeMenu)valorEntrada;
                ConfigurarProximaAcao(opcaoDeMenu);
            }
        }

        private void ConfigurarProximaAcao(OpcaoDeMenu opcaoDeMenu)
        {
            switch (opcaoDeMenu)
            {
                case OpcaoDeMenu.MenuPrincipal:
                    {
                        ConsoleUtil.LimparConsole();
                        ExibirMenuPrincipal(); break;
                    }
                case OpcaoDeMenu.CadastroDeClientes:
                    {
                        ConsoleUtil.LimparConsole();
                        IrParaMenuDeCadastroDeClientes(); break;
                    }
                case OpcaoDeMenu.ConsultasNutricionais:
                    {
                        ConsoleUtil.LimparConsole();
                        IrParaMenuDeConsultasNutricionais(); break;
                    }
                case OpcaoDeMenu.NovoCliente:
                    {
                        ConsoleUtil.LimparConsole();
                        CadastrarNovoCliente(); break;
                    }
                case OpcaoDeMenu.ListarClientes:
                    {
                        ConsoleUtil.LimparConsole();
                        ExibirRelacaoDeClientes(); break;
                    }
                case OpcaoDeMenu.NovaConsulta:
                    {
                        ConsoleUtil.LimparConsole();
                        RealizarNovaConsulta(); break;
                    }
                case OpcaoDeMenu.HistoricoDeConsultas:
                    {
                        ConsoleUtil.LimparConsole();
                        ExibirHistoricoDeConsultas(); break;
                    }
                default: ExibirOpcaoInvalida(); break;

            }

        }


        #region Consultas Nutricionais
        private void IrParaMenuDeConsultasNutricionais()
        {
            string menu = "";

            menu += ObterCabecalhoDeMenu("Escolha uma das opções e pressione Enter:");
            menu += $"\n{(int)OpcaoDeMenu.MenuPrincipal} - Menu Principal";
            menu += $"\n{(int)OpcaoDeMenu.HistoricoDeConsultas} - Histórico de Consultas";
            menu += $"\n{(int)OpcaoDeMenu.NovaConsulta} - Nova Consulta";

            ConsoleUtil.Escrever(menu);
            IrParaProximaAcao();
        }

        private void RealizarNovaConsulta()
        {
            decimal peso = 0;
            decimal porcentagemDeGordura = 0;
            decimal metaCalorica = 0;
            string restricoes = "";
            string sensacoesFisicas = "";
            DateTime dataDaConsulta = DateTime.Now;
            string texto = ObterCabecalhoDeMenu("Nova Consulta Nutricional");
            ConsoleUtil.Escrever(texto);

            Cliente paciente = PesquisarClientePeloCodigo();
            if (paciente is null || paciente.Id <= 0)
            {
                ConsoleUtil.LimparConsole();
                IrParaMenuDeConsultasNutricionais();
                return;
            }

            peso = SolicitarPesoDoPaciente();
            porcentagemDeGordura = SolicitarPorcentagemDeGorduraDoPaciente();
            restricoes = SolicitarRestricoesAlimentaresDoPaciente();
            sensacoesFisicas = SolicitarSensacaoFisicaDoPaciente();

            ConsultaNutricional consulta = _consultaNutricionalApp.CriarConsultaNutricional(paciente, dataDaConsulta, peso, porcentagemDeGordura, restricoes, sensacoesFisicas);

            if (consulta != null)
            {
                ConsoleUtil.LimparConsole();
                texto = "\n==============Nova consulta criada com sucesso!===============";
                ConsoleUtil.Escrever(texto);

                ExibirDetalhesDaConsulta(consulta);

                CriarDietaDaConsulta(consulta);
                ConsoleUtil.LimparConsole();
                IrParaMenuDeConsultasNutricionais();
                return;
            }

        }

        private void ExibirHistoricoDeConsultas()
        {
            string texto = ObterCabecalhoDeMenu("Histórico de Consultas");
            ConsoleUtil.Escrever(texto);

            var cliente = PesquisarClientePeloCodigo();

            if (cliente != null)
            {
                var consultas = _consultaNutricionalApp.RetornarHistoricoDeConsultasDoPaciente(cliente.Id);

                foreach (var consulta in consultas)
                {
                    ExibirDetalhesDaConsulta(consulta);
                }

                if (!consultas.Any())
                {
                    texto = "\nNão existem consultas cadastradas para este Cliente.";
                    ConsoleUtil.Escrever(texto);
                }

            }
            else
            {
                texto = "\nCliente não encontrado.";
                ConsoleUtil.Escrever(texto);
            }

            System.Console.ReadKey();
            ConsoleUtil.LimparConsole();
            IrParaMenuDeConsultasNutricionais();

        }

        private void ExibirDetalhesDaConsulta(ConsultaNutricional consulta)
        {
            string texto = "\n===========================================================";
            texto += $"\n";
            texto += $"\n----- Cliente";
            texto += $"\nCodigo do Paciente: {consulta.Paciente.Id}";
            texto += $"\nNome do Paciente {consulta.Paciente.Nome}";
            texto += $"\n\n----- Consulta";
            texto += $"\nCodigo da Consulta: {consulta.Id}";
            texto += $"\nHorário: {consulta.DataDaConsuta:dd/MM/yyyy HH:mm}";
            texto += $"\nPeso do Paciente: {consulta.PesoDoPaciente}";
            texto += $"\n % de gordura do Paciente: {consulta.PorcentagemDeGorduraDoPaciente}";
            texto += $"\nRestrições alimentares: {consulta.RestricoesAlimentares}";
            texto += $"\nSensação física do Paciente: {consulta.SensacaoFisicaDoPaciente}";
            texto += "\n===========================================================";
            ConsoleUtil.Escrever(texto);

        }


        private void CriarDietaDaConsulta(ConsultaNutricional consulta)
        {
            string texto = "\n\nDeseja criar uma nova Dieta para esta consulta? [S/N]: ";
            ConsoleUtil.Escrever(texto);
            string entrada = ConsoleUtil.LerEntradaDoUsuario();
            IEnumerable<CombinacaoDeAlimentosDeDieta> combinacoes = new List<CombinacaoDeAlimentosDeDieta>();
            decimal metaCalorica = 0;
            if (entrada.ToUpper().Equals("S"))
            {
                string refazer = "";
                do
                {
                    refazer = "N";
                    metaCalorica = SolicitarMetaCaloricaParaOPaciente();

                    var dieta = _consultaNutricionalApp.CriarDieta(consulta, metaCalorica);
                    combinacoes = dieta.ObterCombinacaoDeAlimentos(maximoDeAlimentosPorGrupo: 1);

                    if (!combinacoes.Any())
                    {
                        texto = "\n\nNão foram encontrados combinações de alimentos para meta." +
                                "\nDeseja Refazer?[S/N]: ";
                        ConsoleUtil.Escrever(texto);
                        refazer = ConsoleUtil.LerEntradaDoUsuario();
                    }
                    else
                    {
                        ExibirCombinacoesDeAlimentos(combinacoes, metaCalorica);
                    }

                } while (refazer.ToUpper().Equals("S"));


                System.Console.ReadKey();
            }
        }

        private void ExibirCombinacoesDeAlimentos(IEnumerable<CombinacaoDeAlimentosDeDieta> combinacoes, decimal metaCalorica)
        {
            string texto = "\n\n============= Combinações de Alimentos";
            texto += $"\nForam localizadas [{combinacoes.Count()}] Combinações de alimentos para a meta de {metaCalorica} calorias ";
            ConsoleUtil.Escrever(texto);

            foreach (var combinacao in combinacoes)
            {
                texto = "\n\n=====Combinação";
                texto += $"\nTotal Calórico: {combinacao.TotalCalorico}";
                ConsoleUtil.Escrever(texto);

                foreach (var alimento in combinacao.Alimentos)
                {
                    texto = $"\n" +
                            $"\n|Grupo:             |{alimento.GrupoDeAlimento.Nome}" +
                            $"\n|Alimento:          |{alimento.Nome}" +
                            $"\n|Valor Calórico:    |{alimento.ValorCalorico}";
                    ConsoleUtil.Escrever(texto);
                }
            }
        }

        private decimal SolicitarPesoDoPaciente()
        {
            var texto = "";
            var entrada = "";
            decimal pesoDoPaciente = 0;
            do
            {
                texto = "\nDigite o Peso atual do Paciente: ";
                ConsoleUtil.Escrever(texto);
                entrada = ConsoleUtil.LerEntradaDoUsuario();

            } while (decimal.TryParse(entrada, out pesoDoPaciente) == false);

            return pesoDoPaciente;
        }

        private decimal SolicitarPorcentagemDeGorduraDoPaciente()
        {
            var texto = "";
            var entrada = "";
            decimal percentual = 0;
            do
            {
                texto = "Digite o % de gordura atual do Paciente: ";
                ConsoleUtil.Escrever(texto);
                entrada = ConsoleUtil.LerEntradaDoUsuario();

            } while (decimal.TryParse(entrada, out percentual) == false);

            return percentual;
        }

        private string SolicitarRestricoesAlimentaresDoPaciente()
        {
            var texto = "";
            var entrada = "";
            texto = "Digite as restrições alimentares do Paciente: ";
            ConsoleUtil.Escrever(texto);
            entrada = ConsoleUtil.LerEntradaDoUsuario();
            return entrada;
        }

        private string SolicitarSensacaoFisicaDoPaciente()
        {
            var texto = "";
            var entrada = "";
            texto = "Digite as sensações fisicas do Paciente: ";
            ConsoleUtil.Escrever(texto);
            entrada = ConsoleUtil.LerEntradaDoUsuario();
            return entrada;

        }

        private decimal SolicitarMetaCaloricaParaOPaciente()
        {
            var texto = "";
            var entrada = "";
            decimal metaCalorica = 0;
            do
            {
                texto = "\nDigite a Meta Calórica para Paciente: ";
                ConsoleUtil.Escrever(texto);
                entrada = ConsoleUtil.LerEntradaDoUsuario();

            } while (decimal.TryParse(entrada, out metaCalorica) == false && metaCalorica <= 0);

            return metaCalorica;
        }

        #endregion

        private Cliente PesquisarClientePeloCodigo()
        {
            var texto = "";
            var entrada = "";
            long codigoCliente = 0;

            do
            {
                texto = "\nDigite o Código do Cliente ou [S] para sair: ";
                ConsoleUtil.Escrever(texto);
                entrada = ConsoleUtil.LerEntradaDoUsuario();

            } while (entrada.ToUpper().Equals("S") == false && long.TryParse(entrada, out codigoCliente) == false);

            if (codigoCliente > 0)
            {
                return _clienteApp.ObterClientePeloId(codigoCliente);
            }

            return null;
        }

        private void IrParaMenuDeCadastroDeClientes()
        {
            string menu = "";

            menu += ObterCabecalhoDeMenu("Escolha uma das opções e pressione Enter:");
            menu += $"\n{(int)OpcaoDeMenu.MenuPrincipal} - Menu Principal";
            menu += $"\n{(int)OpcaoDeMenu.NovoCliente} - Novo Cliente";
            menu += $"\n{(int)OpcaoDeMenu.ListarClientes} - Exibir Clientes";

            ConsoleUtil.Escrever(menu);
            IrParaProximaAcao();
        }
        private void ExibirRelacaoDeClientes()
        {
            IEnumerable<Cliente> clientes = _clienteApp.RetornarClientes();
            foreach (var cliente in clientes)
            {
                ExibirDetalhesDoCliente(cliente);

            }
            System.Console.ReadKey();
            ConsoleUtil.LimparConsole();
            IrParaMenuDeCadastroDeClientes();
            return;
        }

        private void CadastrarNovoCliente()
        {
            var cadastroHelper = new CadastroDeClienteHelper();

            string texto = ObterCabecalhoDeMenu("Novo Cliente");
            texto += "\n";
            ConsoleUtil.Escrever(texto);

            Nome nome = cadastroHelper.ObterNome();
            Endereco endereco = cadastroHelper.ObterEndereco();
            DateTime dataNascimento = cadastroHelper.ObterDataDeNascimento();
            Email email = cadastroHelper.ObterEmail();
            IEnumerable<Telefone> telefones = cadastroHelper.ObterTelefones();

            Cliente cliente = _clienteApp.CriarCliente(nome, endereco, dataNascimento, email, telefones);

            if (cliente != null)
            {
                ConsoleUtil.LimparConsole();
                texto = "\n==============Novo Cliente criado com sucesso!===============";
                ConsoleUtil.Escrever(texto);

                ExibirDetalhesDoCliente(cliente);
                System.Console.ReadKey();
                ConsoleUtil.LimparConsole();
                IrParaMenuDeCadastroDeClientes();
                return;
            }

        }

        private void ExibirDetalhesDoCliente(Cliente cliente)
        {
            string texto = "\n===========================================================";
            texto += $"\n";
            texto += $"\nCodigo: {cliente.Id}";
            texto += $"\nNome: {cliente.Nome}";
            texto += $"\nData de Nascimento: {cliente.DataDeNascimento:dd/MM/yyyy}";
            texto += $"\nE-mail: {cliente.Email.Valor}";
            texto += $"\n";
            texto += $"\n ----Endereço:";
            texto += $"\nCEP: {cliente.Endereco.Cep}";
            texto += $"\nEndereço: {cliente.Endereco.LinhaDeEndereco}";
            texto += $"\nBairro: {cliente.Endereco.Bairro}";
            texto += $"\nCidade: {cliente.Endereco.Cidade}";
            texto += $"\nNúmero: {cliente.Endereco.Numero}";
            texto += $"\nUF: {cliente.Endereco.Uf}";
            texto += $"\nComplemento: {cliente.Endereco.Complemento}";
            texto += $"\n";
            texto += $"\n ----Telefones:";
            foreach (var telefone in cliente.Telefones)
            {
                texto += $" \nTelefone: {telefone.Numero}";
            }
            texto += "\n===========================================================";

            ConsoleUtil.Escrever(texto);
        }

        private void ExibirOpcaoInvalida()
        {
            string menu = "";
            menu += "\n";
            menu += "\nA opção informada não foi reconhecida";
            menu += "\nDigite uma das opões novamente.";
            menu += "\n";

            ConsoleUtil.Escrever(menu);
            IrParaProximaAcao();
        }

        private void ExibirMenuPrincipal()
        {
            string menu = "";

            menu += ObterCabecalhoDeMenu("Escolha uma das opções e pressione Enter:");
            menu += $"\n{(int)OpcaoDeMenu.CadastroDeClientes} - Cadastro de Clientes";
            menu += $"\n{(int)OpcaoDeMenu.ConsultasNutricionais} - Consultas Nutricionais";

            ConsoleUtil.LimparConsole();
            ConsoleUtil.Escrever(menu);
            IrParaProximaAcao();
        }

        private string ObterEntradaDoUsuario()
        {
            string texto = "\nSua Opção: ";
            ConsoleUtil.Escrever(texto);
            string entrada = System.Console.ReadLine();
            return entrada;
        }

        private string ObterCabecalhoDeMenu(string mensagem)
        {
            string menu = "";
            menu += "\n=======================================================";
            menu += "\n================ PERSONAL NUTRI =======================";
            menu += "\n=======================================================";
            menu += "\n";
            if (!string.IsNullOrEmpty(mensagem))
                menu += $"\n===={mensagem}";
            menu += "\n";

            return menu;
        }
    }
}

using System;

namespace Projeto1
{
    class Program
    {
        static RepositorioRestaurante repositorio = new RepositorioRestaurante();
        static void Main(string [] args)
        {
            string opcao = ObterEscolha();

                while (opcao.ToUpper() != "L")
                {
                    switch (opcao)
                    {
                        case "1":
                            ListarRestaurante();
                            break;
                        case "2":
                            InserirRestaurante();
                            break;
                        case "3":
                            AtualizarRestaurante();
                            break;
                        case "4":
                            ExcluirRestaurante();
                            break;
                        case "5":
                            VisualizarRestaurante();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                        
                    }
                    opcao = ObterEscolha();
                }
                Console.WriteLine("Agradecemos por utilizar nossa aplicação. Bom dia!");
			    Console.ReadLine();
        }
            private static void ListarRestaurante()
            {
                Console.WriteLine("Restaurantes presentes na aplicação: ");

                var lis = repositorio.Lista();

                if (lis.Count == 0)
                {
                    Console.WriteLine("Nenhum restaurante cadastrado.");
                    return;
                }

                foreach (var restaurante in lis)
                {
                    var excluido = restaurante.RetornaExcluido();
                    Console.WriteLine("ID {0}: {1} {2}", restaurante.RetornaId(), restaurante.RetornaNome(), (excluido ? "*Excluído*" : ""));
                }
            }

            private static void InserirRestaurante()
            {
                Console.WriteLine("Inserir novo restaurante: ");

                foreach (int i in Enum.GetValues(typeof(Tipo)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
                }

                Console.WriteLine();

                Console.Write("Digite o tipo de restaurante dentre as opções: ");
			    int entradaTipo = int.Parse(Console.ReadLine());

			    Console.Write("Digite o nome do restaurante: ");
			    string entradaNome = Console.ReadLine();

			    Console.Write("Digite o número de telefone do restaurante: ");
			    int entradaNumero = int.Parse(Console.ReadLine());

			    Console.Write("Digite a descrição do restaurante: ");
			    string entradaDescricao = Console.ReadLine();

                Console.Write("Digite a localização do restaurante: ");
			    string entradaLocalizacao = Console.ReadLine();

			Cadastro novoRestaurante = new Cadastro(id: repositorio.ProximoId(),
										tipo: (Tipo)entradaTipo,
										nome: entradaNome,
										numero: entradaNumero,
										descricao: entradaDescricao,
                                        local: entradaLocalizacao);

			repositorio.Insere(novoRestaurante);
            }

            private static void AtualizarRestaurante()
		{
			Console.Write("Digite o id do restaurante: ");
			int indiceRestaurante = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Tipo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tipo), i));
			}
			Console.Write("Digite o tipo de restaurante dentre as opções: ");
			int entradaTipo = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o nome do restaurante: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o número de telefone do restaurante ");
			int entradaNumero = int.Parse(Console.ReadLine());

			Console.Write("Digite a descrição do restaurante: ");
			string entradaDescricao = Console.ReadLine();

            Console.Write("Digite a localização do restaurante: ");
			string entradaLocalizacao = Console.ReadLine();

			Cadastro AtualizarRestaurante = new Cadastro(id: indiceRestaurante,
										tipo: (Tipo)entradaTipo,
										nome: entradaNome,
										numero: entradaNumero,
										descricao: entradaDescricao,
                                        local: entradaLocalizacao);

			repositorio.Atualiza(indiceRestaurante, AtualizarRestaurante);
		}
        private static void ExcluirRestaurante()
		{
			Console.Write("Digite o id do restaurante: ");
			int indiceRestaurante = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceRestaurante);
		}

         private static void VisualizarRestaurante()
		{
			Console.Write("Digite o id do restaurante: ");
			int indiceRestaurante = int.Parse(Console.ReadLine());

			var restaurante = repositorio.RetornaPorId(indiceRestaurante);

			Console.WriteLine(restaurante);
		}

            private static string ObterEscolha()
            {
            Console.WriteLine();
			Console.WriteLine("Bom dia, em que posso te ajudar?");
			Console.WriteLine("O que deseja fazer? Insira a opção desejada:");

			Console.WriteLine("(1) Listar restaurantes");
			Console.WriteLine("(2) Inserir novo restaurante");
			Console.WriteLine("(3) Atualizar restaurante");
			Console.WriteLine("(4) Excluir restaurante");
			Console.WriteLine("(5) Visualizar restaurante");
			Console.WriteLine("(C) Limpar Tela");
			Console.WriteLine("(L) Sair");
			Console.WriteLine();

			string opcao = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcao;
            }
        }
    }

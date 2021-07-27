using System;

namespace Super.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = OpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VisualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = OpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
    
        }

        private static void ListarSerie()
        {
            Console.Write("Listar Séries");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if(lista.Count ==0)
            {
                Console.WriteLine("Nenhuma série cadastra");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}",serie.retornaId(),serie.retornaTitulo(),(excluido ? "Excluído" : ""));
            }
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i  in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#{0}= - {1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o Gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series (id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie,atualizaSerie);

        }
        private static void InserirSerie()
        {
            Console.Write("Inserir Série");
            Console.WriteLine();

            foreach (int i  in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}= - {1}",i,Enum.GetName(typeof(Genero),i));
            }

            Console.Write("Digite o Gênero entre as opções acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();
             
            Series novaSerie = new Series (id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        public static string OpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Super Séries");
            Console.WriteLine();
            Console.WriteLine("Selecione uma opção: ");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}

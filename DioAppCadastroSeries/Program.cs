using System;

namespace DioAppCadastroSeries
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            //Serie novaSerie = new Serie();
            string userInput = "";
            while (userInput != "X")
            {
                userInput = GetUserInput();
                switch (userInput)
                {
                    case "1":
                        ListAllSeries();
                        break;
                    case "2":
                        InsertNewSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        GetSerieInfo();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Opção digitada é Inválida!");
                        break;
                }
                
			}
        }

        private static void GetSerieInfo()
        {
            int id;
            Console.WriteLine();
            id = int.Parse(Console.ReadLine());
            Serie serie = repository.GetSerieById(id);
        }

        private static void DeleteSerie()
        {
            int id;
            Console.WriteLine();
            id = int.Parse(Console.ReadLine());
            repository.DeleteById(id);
        }

        private static void UpdateSerie()
        {
            //int idP,string nomeP, string tituloP, Genero generoP, string descricaoP, int anoP
            Console.WriteLine("Digite o ID da série a ser atualizada: ");
            int newId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o novo título: ");
            string newTitle = Console.ReadLine();

            repository.PrintListAllGenres();
            Console.WriteLine("Digite uma opção de gênero:");
            Genero newGenre = (Genero)Enum.Parse(typeof(Genero), Console.ReadLine());

            Console.WriteLine("Digite nova descrição");
            string newDesc = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int newYear = int.Parse(Console.ReadLine());

            Serie serie = new Serie(newId,newTitle,newGenre,newDesc,newYear);
            repository.UpdateById(newId, serie);
        }

        private static void InsertNewSerie()
        {
            int newId = repository.GetNextID();

            Console.WriteLine("Digite o novo título: ");
            string newTitle = Console.ReadLine();

            repository.PrintListAllGenres();
            Console.WriteLine("Digite uma opção de gênero:");
            Genero newGenre = (Genero)Enum.Parse(typeof(Genero), Console.ReadLine());

            Console.WriteLine("Digite nova descrição");
            string newDesc = Console.ReadLine();

            Console.WriteLine("Digite o ano da série: ");
            int newYear = int.Parse(Console.ReadLine());

            Serie serie = new Serie(newId, newTitle, newGenre, newDesc, newYear);
            repository.Insert(serie);
        }

        private static void ListAllSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repository.GetSerieList();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1} ", serie.GetSerieId(), serie.Titulo/*, (excluido ? "*Excluído*" : "")*/);
            }
            
        }

        private static string GetUserInput()
        {
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userInput = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userInput;
		}
    }
}

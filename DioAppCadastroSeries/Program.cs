using System;

namespace DioAppCadastroSeries
{
    class Program
    {
        static CinemaRepository repository = new CinemaRepository();
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
                    case "6":
                        RestoreSerie();
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

        private static void RestoreSerie()
        {
            int newId;
            Console.WriteLine("Digite o ID da série que você deseja restaurar: ");
            if (int.TryParse(Console.ReadLine(), out newId))
            {
                if (repository.GetSerieList().Exists(x => x.GetCinemaContentId() == newId))
                {
                    repository.RestoreSerie(newId);
                }
                else
                {
                    Console.WriteLine("O ID da série que você digitou não existe!");
                }
            }
        }

        private static void GetSerieInfo()
        {
            int newId;
            Console.WriteLine("Digite o ID da série que você deseja mais Detalhes: ");
            if (int.TryParse(Console.ReadLine(), out newId))
            {
                if (repository.GetSerieList().Exists(x => x.GetCinemaContentId() == newId))
                {
                    Serie serie = repository.GetSerieById(newId);
                    if (serie.IsDeleted)
                    {
                        Console.WriteLine("ATENÇÃO a série que você tentou obter informação encontra-se com status de Excluída\n Digite S para exibir informações mesmo assim!");
                        string opcao = Console.ReadLine().ToLower();
                        if (opcao == "s")
                        {
                            Console.WriteLine("Série: {0} foi lançada em {1} e possui como gênero principal {2}.\nSinópse: {3}", serie.Titulo, serie.Ano, serie.Genero, serie.Descricao);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Série: {0} foi lançada em {1} e possui como gênero principal {2}.\nSinópse: {3}", serie.Titulo, serie.Ano, serie.Genero, serie.Descricao);
                    }
                    
                }
                else
                {
                    Console.WriteLine("O ID da série que você digitou não existe!");
                }
            }
        }

        private static void DeleteSerie()
        {
            int newId;
            Console.WriteLine("Digite o ID da série que você deseja deletar: ");
            if (int.TryParse(Console.ReadLine(), out newId))
            {
                if (repository.GetSerieList().Exists(x => x.GetCinemaContentId() == newId))
                {
                    repository.DeleteById(newId);
                }
                else
                {
                    Console.WriteLine("O ID da série que você digitou não existe!");
                } 
            }

        }

        private static void UpdateSerie()
        {
            //int idP,string nomeP, string tituloP, Genero generoP, string descricaoP, int anoP
            Console.WriteLine("Digite o ID da série a ser atualizada: ");
            int newId = int.Parse(Console.ReadLine());

            if (repository.GetSerieList().Exists(x => x.GetCinemaContentId() == newId))
            {
                try
                {
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
                    repository.UpdateById(newId, serie);
                    Console.WriteLine("Série Atualizada com Sucesso!");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
                catch (Exception exception)
                {
                    Console.Clear();
                    Console.WriteLine("Parece que ocorreu um erro ao tentar atualizar, verifique se você digitou corretamente os dados.");
                    Console.WriteLine("Messagem de Erro: {0}", exception.Message);
                    Console.WriteLine("Aperte Enter para voltar ao Menu Principal");
                    Console.ReadLine();
                    throw;
                }
            }
            else
            {
                Console.WriteLine("O ID da série que você digitou não existe");
            }
        }

        private static void InsertNewSerie()
        {
            try
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
                Console.WriteLine("Série Cadastrada com Sucesso!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine("Parece que ocorreu um erro ao tentar cadastrar, verifique se você digitou corretamente os dados.");
                Console.WriteLine("Messagem de Erro: {0}", exception.Message);
                Console.WriteLine("Aperte Enter para voltar ao Menu Principal");
                Console.ReadLine();
                throw;
            }

        }

        private static void ListAllSeries()
        {
            Console.WriteLine("Deseja exibir séries exluidas? Digite S para Sim ou Qualquer outra tecla para não");
            string opcao = Console.ReadLine();
            bool excluido = false;
            if (opcao.ToLower() == "s")
            {
                excluido = true;
            }
            Console.Clear();
            Console.WriteLine("Listar séries");

            var lista = repository.GetSerieList();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                if (excluido)
                {
                    Console.WriteLine("#ID {0}: - {1} - {2}", serie.GetCinemaContentId(), serie.Titulo, (excluido ? "*Excluído*" : ""));
                }
                else
                {
                    if (!serie.IsDeleted)
                    {
                        Console.WriteLine("#ID {0}: - {1}", serie.GetCinemaContentId(), serie.Titulo);
                    }
                }
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
            Console.WriteLine("6- Reativar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userInput;
        }
    }
}

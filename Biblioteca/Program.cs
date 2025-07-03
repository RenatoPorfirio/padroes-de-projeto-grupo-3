public class Program
{
    private static BibliotecaSingleton bs = BibliotecaSingleton.GetInstance();
    private static string[] types = Enum.GetNames(typeof(EstandeType));
    
    public static void Main(string[] args)
    {
        Menu();
    }

    private static void Menu()
    {
        int opc = 0;

        while (opc != -1)
        {
            Console.WriteLine(
                "1 - Gerenciar Biblioteca\n" +
                "2 - Adicionar livro\n" +
                "3 - Buscar Livro"
            );

            Console.Write("-> ");

            if (!int.TryParse(Console.ReadLine(), out opc))
            {
                Console.WriteLine("Entrada Invalida!");
            }

            Console.Clear();

            switch (opc)
            {
                case 1:
                    GerenciarBiblioteca();
                    break;
                case 2:
                    AdicionarLivros();
                    break;
                case 3:
                    BuscarLivros();
                    break;
                default:
                    Console.WriteLine("Programa encerrado!"); opc = -1;
                    break;
            }

            Console.ReadKey();
        }
    }

    private static void GerenciarBiblioteca()
    {
        int opcEstande;
        int capacity;

        Console.WriteLine(
            "1 - Adicionar Estande\n"
        );

        Console.Write("Opcao -> ");
        int opc;

        if (!int.TryParse(Console.ReadLine(), out opc) || opc > 2)
        {
            Console.WriteLine("Entrada Invalida!");
            return;
        }

        if (opc == 1)
        {
            Console.WriteLine("Informe a posicao do tipo desejado e sua capacidade:");
            Console.Write($"Tipos disponiveis: \"");

            PrintTypes();

            Console.WriteLine("\" e capacidade Maxima permitida para a estande: 10000");
            Console.Write("Tipo estande -> ");

            if (!int.TryParse(Console.ReadLine(), out opcEstande) || opcEstande < 0 && opcEstande >= types.Length)
            {
                Console.WriteLine("Entrada Invalida!");
                return;
            }

            Console.Write("Capacidade -> ");
            if (!int.TryParse(Console.ReadLine(), out capacity) || capacity > 10000)
            {
                Console.WriteLine("Entrada Invalida!");
                return;
            }

            bs.AddEstande((EstandeType)opcEstande, capacity);
        }
    }

    private static void AdicionarLivros()
    {
        int opcEstande;
        int indexEstande;
        int quantEstandes;
        string? bookName;

        Console.WriteLine("Informe a posicao do tipo do Livro para adiciona-lo a Estande!\n");
        Console.Write("Tipos de estandes disponíveis para incluir o livro: \"");

        PrintTypes();

        Console.WriteLine("\"");
        Console.Write("Tipo Estande -> ");

        if (!int.TryParse(Console.ReadLine(), out opcEstande) || opcEstande < 0 || opcEstande >= types.Length)
        {
            Console.WriteLine("Entrada Invalida!");
            return;
        }

        quantEstandes = bs.CountEstandesByType((EstandeType)opcEstande);

        if (quantEstandes == 0)
        {
            Console.WriteLine($"Estandes do tipo: {types[opcEstande]} estao indisponiveis!");
            return;
        }

        Console.WriteLine("Informe a posicao da estande:");
        Console.WriteLine($"Posicoes disponiveis: [0, {quantEstandes - 1}]");

        if (!int.TryParse(Console.ReadLine(), out indexEstande) || indexEstande < 0 || indexEstande >= quantEstandes)
        {
            Console.WriteLine("Entrada Invalida!");
            return;
        }

        Console.Write("Informe o nome do livro-> ");
        bookName = Console.ReadLine();

        if (bookName != null && bookName != "")
        {
            bs.AddBook((EstandeType)opcEstande, bookName, indexEstande);
        }
        else
        {
            Console.WriteLine("O livro nao pode ser nulo ou vazio.");
        }
    }

    private static void BuscarLivros()
    {
        int opc;
        int opcLivro;
        string? bookName;

        Console.WriteLine(
            "1- Buscar Livro pelo Nome e Tipo\n" +
            "2- Verificar a Quantidade de Livros Para o Nome Especificado\n"
        );

        Console.Write("Opc-> ");
        if (!int.TryParse(Console.ReadLine(), out opc) || opc > 2)
        {
            Console.WriteLine("Entrada Invalida!");
            return;
        }

        if (opc == 1)
        {
            Console.WriteLine("Informe o index do tipo do livro.");
            Console.Write("Tipos disponiveis: \"");

            PrintTypes();

            Console.WriteLine("\"");
            Console.Write("Tipo do livro-> ");

            if (!int.TryParse(Console.ReadLine(), out opcLivro) || opcLivro < 0 || opcLivro >= types.Length)
            {
                Console.WriteLine("Entrada Invalida!");
                return;
            }

            Console.Write("Informe o nome do livro-> ");
            bookName = Console.ReadLine();

            if (bookName != null && bookName != "")
            {
                bs.GetBook((EstandeType)opcLivro, bookName);
            }
            else
            {
                Console.WriteLine("O livro nao pode ser nulo ou vazio.");
            }
        }
        else if (opc == 2)
        {
            Console.Write("Informe o nome do livro-> ");
            bookName = Console.ReadLine();

            if (bookName != null && bookName != "")
            {
                bs.CountBooksByName(bookName);
            }
            else
            {
                Console.WriteLine("O livro nao pode ser nulo ou vazio.");
            }
        }
        else
        {
            Console.WriteLine("Opcao Invalida!");
        }
    }

    private static void PrintTypes()
    {
        foreach (string s in types)
        {
            Console.Write(s + " ");
        }
    }
}

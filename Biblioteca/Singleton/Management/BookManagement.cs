using System.Diagnostics.CodeAnalysis;
using System.Net;

public class BookManagement
{
    private Dictionary<EstandeType, List<Estande>> biblioteca;
    private readonly object objLock;
    
    public BookManagement(Dictionary<EstandeType, List<Estande>> biblioteca)
    {
        this.biblioteca = biblioteca;
        this.objLock = new object();
    }

    public void AddBook(EstandeType type, string bookName, int estandeIndex)
    {
        List<Estande> estandes = getEstandes(type);

        if (estandeIndex >= estandes.Count)
        {
            throw new IndexOutOfRangeException(
                $"Index informado excede a quantidade de estandes do tipo: \"{type.ToString()}\" disponiveis no momento!"
            );
        }
        else
        {
            lock (objLock)
            {
                estandes[estandeIndex].AddBook(bookName);
            }
        }
    }

    public void CountBooksByName(string bookName, EstandeType? type = null)
    {
        if (biblioteca.Count == 0)
        {
            Console.WriteLine("A biblioteca nao possue estandes de nenhum tipo no momento.");
            return;
        }

        foreach (KeyValuePair<EstandeType, List<Estande>> estandesPair in biblioteca)
        {
            Dictionary<int, int> keyEstandePairs = new Dictionary<int, int>();
            List<Estande> estandes = estandesPair.Value;
            int acc;

            for (int i = 0; i < estandes.Count; i++)
            {
                if ((acc = estandes[i].CountBooksByName(bookName)) != 0)
                    keyEstandePairs.Add(i, acc);
            }

            if (keyEstandePairs.Count == 0)
            {
                Console.WriteLine(
                    "-------------------------------////----------------------------------\n" +
                    $"Nao foi encontrado nenhum registro do livro: \"{bookName}\" em nenhuma estande do tipo: \"{estandesPair.Key.ToString()}\""
                );
            }
            else
            {
                Console.WriteLine(
                    "-------------------------------////----------------------------------\n" +
                    $"O livro: \"{bookName}\" da sessao: \"{estandesPair.Key.ToString()}\" foi encontrado nas seguintes estandes:"
                );

                foreach (KeyValuePair<int, int> pair in keyEstandePairs)
                {
                    Console.WriteLine($"Estande: {pair.Key}, quantidade = {pair.Value}");
                }
            }
        }
    }

    public void GetBook(EstandeType type, string bookName)
    {
        int estandeIndex = -1;
        List<Estande> estandes = getEstandes(type);

        if (estandes.Count >= 0)
        {
            for (int i = 0; i < estandes.Count; i++)
            {
                if (estandes[i].GetBook(bookName) != "")
                {
                    estandeIndex = i; break;
                }
            }
        }

        if (estandeIndex == -1)
        {
            Console.WriteLine($"O livro: \"{bookName}\" nao foi em nenhuma estande do tipo: {type.ToString()}");
        }
        else
        {
            Console.WriteLine(
                $"O livro: \"{bookName}\" do tipo: \"{type.ToString()}\" foi encontrado na estande de indice: {estandeIndex}"
            );
        }
    }

    public int CountEstandesByType(EstandeType type)
    {
        return getEstandes(type).Count;
    }

    private List<Estande> getEstandes(EstandeType type) => this.biblioteca[key: type];
}

public class LiteratureEstande : Estande
{
    private string[,]? literatureEstande;

    public LiteratureEstande()
    {
        this.estandeType = EstandeType.LITERATURE_ESTANDE.ToString();
    }

    public override void MakeEstande(int capacity)
    {
        this.capacity = capacity;
        this.literatureEstande = new string[capacity, capacity];
    }
    
    public override void AddBook(string bookName)
    {
        if (literatureEstande != null)
        {
            for (int i = 0; i < capacity; i++)
                for (int j = 0; j < capacity; j++)
                    if (literatureEstande[i, j] == null)
                    {
                        literatureEstande[i, j] = bookName;
                        Console.WriteLine($"O livro {bookName} foi adicionado a estande \"{estandeType}\"");
                        return;
                    }

            Console.WriteLine($"Nao foi encontrada nenhuma posicao vazia na estande do tipo \"{estandeType}\"");
        }
    }

    public override string GetBook(string bookName)
    {
        if (literatureEstande != null)
        {
            string? book = null;
            for (int i = 0; i < capacity; i++)
                for (int j = 0; j < capacity; j++)
                {
                    book = literatureEstande[i, j];
                    if (book != null && book == bookName)
                    {
                        return book;
                    }
                }
        }
        return "";
    }
}
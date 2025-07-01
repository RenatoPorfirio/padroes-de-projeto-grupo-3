public class BookManagement
{
    private EstandeFactory factory;
    private Dictionary<EstandeType, List<Estande>> biblioteca;
    private readonly object objLock;
    
    public BookManagement(EstandeFactory factory, Dictionary<EstandeType, List<Estande>> biblioteca)
    {
        this.factory = factory;
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

    public string? GetBook(EstandeType type, string bookName)
    {
        string book = "";
        List<Estande> estandes = getEstandes(type);
        if (estandes.Count >= 0)
        {
            foreach (Estande estande in estandes)
            {
                book = estande.GetBook(bookName);
                if (book != "")
                    return book;
            }
        }
        return null;
    }
    
    private List<Estande> getEstandes(EstandeType type) => this.biblioteca[key: type];
}
public class BibliotecaSingleton
{
    private static BibliotecaSingleton? instance;
    private static object objLock = new object();
    private readonly Dictionary<EstandeType, List<Estande>> biblioteca;
    private readonly EstandeFactory factory;
    private readonly EstandeManagement estandeManagement;
    private readonly BookManagement bookManagement;

    private BibliotecaSingleton()
    {
        this.factory = new EstandeFactory();
        this.biblioteca = new Dictionary<EstandeType, List<Estande>>();
        this.estandeManagement = new EstandeManagement(factory, biblioteca);
        this.bookManagement = new BookManagement(factory, biblioteca);
        //Estandes do tipo SCIENCE_ESTANDE;
        this.biblioteca.Add(EstandeType.SCIENCE_ESTANDE, new List<Estande>());
        //Estandes do tipo LITERATURE_ESTANDE;
        this.biblioteca.Add(EstandeType.LITERATURE_ESTANDE, new List<Estande>());
        Console.WriteLine("BibilotecaSingleton criada!");
    }

    public static BibliotecaSingleton GetInstance()
    {
        if (instance == null)
        {
            lock (objLock)
                instance ??= new BibliotecaSingleton();
        }
        return instance;
    }

    public void AddEstande(EstandeType type, int capacity)
    {
        estandeManagement.CreateEstande(type, capacity);
    }

    public void AddBook(EstandeType type, string bookName, int estandeIndex)
    {
        bookManagement.AddBook(type, bookName, estandeIndex);
    }

    public string? GetBook(EstandeType type, string bookName)
    {
        return bookManagement.GetBook(type, bookName);
    }
}
public class ScienceEstande : Estande
{
    private List<string>? scienceBooksLisk;

    public ScienceEstande()
    {
        this.estandeType = EstandeType.SCIENCE_ESTANDE.ToString();
    }

    public override void MakeEstande(int capacity)
    {
        this.capacity = capacity;
        this.scienceBooksLisk = new List<string>(capacity);
    }
    
    public override void AddBook(string bookName)
    {
        if (this.scienceBooksLisk != null)
        {
            this.scienceBooksLisk.Add(bookName);
            Console.WriteLine($"Book: {bookName} -> Adicionado a estande \"{estandeType}\"");
        }
    }

    public override int CountBooksByName(string bookName)
    {
        if (this.scienceBooksLisk != null)
        {
            int count = 0;
            foreach (string book in scienceBooksLisk)
            {
                if (book == bookName)
                    count++;
            }
            return count;
        }
        return -1;
    }

    public override string GetBook(string bookName)
    {
        if (this.scienceBooksLisk != null)
        {
            foreach (string book in scienceBooksLisk)
            {
                if (book == bookName)
                    return book;
            }
        }
        return "";
    }
}

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

    public override string GetBook(string bookName)
    {
        if (this.scienceBooksLisk != null)
        {
            int quant = this.scienceBooksLisk.Count;
            for (int i = 0; i < quant; i++)
            {
                if (this.scienceBooksLisk[i] == bookName)
                {
                    return bookName;
                }
            }
        }
        return "";
    }
}
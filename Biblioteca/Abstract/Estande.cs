public abstract class Estande
{
    protected int capacity;
    protected string? estandeType;
    public abstract void MakeEstande(int capacity);
    public abstract void AddBook(string bookName);
    public abstract int CountBooksByName(string bookName);
    public abstract string GetBook(string bookName);
    public string GetEstandeType() => estandeType ?? "";
}

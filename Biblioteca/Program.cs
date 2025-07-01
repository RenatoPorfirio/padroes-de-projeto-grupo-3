public class Program
{
    public static void Main(string[] args)
    {
        //Teste;
        //Resgatando a instancia BibliotecaSingleton;
        BibliotecaSingleton bs = BibliotecaSingleton.GetInstance();
        //Adicionando uma estande do tipo SCIENCE_ESTANDE com capacidade para 10 livros;
        bs.AddEstande(EstandeType.SCIENCE_ESTANDE, 10);
        //Add um livro na estande criada;
        bs.AddBook(EstandeType.SCIENCE_ESTANDE, "Digital Signal Processing", 0);
        //Exibicao do livro adicionado;
        Console.WriteLine(bs.GetBook(EstandeType.SCIENCE_ESTANDE, "Digital Signal Processing"));
    }
}
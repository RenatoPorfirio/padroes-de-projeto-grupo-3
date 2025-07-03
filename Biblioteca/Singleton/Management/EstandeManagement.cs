public class EstandeManagement
{
    private EstandeFactory factory;
    private Dictionary<EstandeType, List<Estande>> biblioteca;
    private readonly object objLock;
    
    public EstandeManagement(EstandeFactory factory, Dictionary<EstandeType, List<Estande>> biblioteca)
    {
        this.factory = factory;
        this.biblioteca = biblioteca;
        this.objLock = new object();
    }

    public void CreateEstande(EstandeType type, int capacity)
    {
        List<Estande> estandes = getEstandes(type);
        Estande? estande = factory.CreateEstande(type, capacity);
        lock (objLock)
        {
            if (estande != null)
            {
                estandes.Add(estande);
                Console.WriteLine(
                    $"Estande do tipo: \"{type.ToString()}\" e capacidade: {capacity} foi adicionada com sucesso!"
                );
            }
        }
    }

    public void DeleteEstande(EstandeType type, int posEstande)
    {
        if (posEstande < 0)
        {
            throw new IndexOutOfRangeException($"Posicao {posEstande} invalida.");
        }
        List<Estande> estandes = getEstandes(type);
        lock (objLock)
        {
            estandes.RemoveAt(posEstande);
            Console.WriteLine(
                $"Estande do tipo: \"{type.ToString()}\" na posicao {posEstande} foi removida com sucesso!"
            );
        }
    }
    private List<Estande> getEstandes(EstandeType type) => this.biblioteca[key: type];
}

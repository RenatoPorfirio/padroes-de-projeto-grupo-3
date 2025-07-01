using System.Reflection;

public class EstandeFactory
{
    private static EstandeFactory?[] estandeFactory = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(t => t.IsSubclassOf(typeof(EstandeFactory)) && !t.IsAbstract)
                            .Select(t => (EstandeFactory)Activator.CreateInstance(t))
                            .ToArray();

    protected Estande? estande;

    public Estande? CreateEstande(EstandeType type, int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "A capacidade da estande dever ver maior que 0!");
        }

        if (capacity >= 10000)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "A capacidade da estande nao pode ser maior que 10000.");
        }

        for (int i = 0; i < estandeFactory.Length; i++)
        {
            EstandeFactory? ef = estandeFactory[i];

            if (ef != null && ef.estande != null)
            {
                if (ef.estande.GetEstandeType() == type.ToString())
                {
                    ef.estande.MakeEstande(capacity);
                    return ef.estande;
                }
            }
        }

        return null;
    }
}
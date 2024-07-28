#if false
Console.WriteLine();

public class A
{
    public int? Number { get; set; }
}

public static class AExtensions
{
    public static void Do(this A a)
    {
        var b = a.Number.Value;
        var c = (0, a.Number.Value);
    }
}
#endif
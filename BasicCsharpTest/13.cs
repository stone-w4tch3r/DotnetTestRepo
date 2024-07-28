#if false
Console.WriteLine("Hello World");

Console.WriteLine(Helper.ReturnPropertyValueAndName(nameof(Class1.Id1)));

public static class Helper
{
    public static (int?, string) ReturnPropertyValueAndName(string name)
    {
        return (typeof(Class1).GetField(name)?.GetValue(null) as int?, name);
    }
}

public class Class1
{
    public const int Id1 = 10;
    public const int Id2 = 20;
}
#endif
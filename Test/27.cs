#if false
using System.Text;

Console.WriteLine("Hello!");

while (true)
{
    var str = Console.ReadLine() ?? string.Empty;

    try
    {
        var encoding = Encoding.GetEncoding(str);
        Console.WriteLine(encoding.EncodingName);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}


#endif
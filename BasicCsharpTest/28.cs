# if false
Console.WriteLine("hello");

var myClass = new MyClass { Text = "world" };

public class MyClass
{
    public required string Text { get; init; }

    public MyClass()
    {
        Console.WriteLine(Text);
    }
}
# endif
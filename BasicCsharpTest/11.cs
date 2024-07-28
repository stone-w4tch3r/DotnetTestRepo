#if false
Console.WriteLine("Hello World!");

var bar = new Bar() { Foos = new[] { new Foo("foo1"), new Foo("foo2"), new Foo("foo3") } };

foreach(var foo in bar.Foos)
    Console.WriteLine(foo);

foreach(var foo in bar.Foos)
    Do(foo);

foreach(var foo in bar.Foos)
    Console.WriteLine(foo);

var x = default(Bar1);
var y = x as Bar;
Console.WriteLine(y == null);

x = new Bar1();
y = x as Bar;
Console.WriteLine(y == null);


static void Do(Foo foo)
{
    Console.WriteLine($"Doing {foo}");
    foo.Name = "foo x";
    foo = new ("foo");
}

public class Foo
{
    public Foo(string name)
    {
        Name = name;
    }
    
    public string Name { get; set; }
    
    public override string ToString() => Name;
}

public class Bar
{
    public IEnumerable<Foo> Foos { get; set; }
}

public class Bar1 : Bar
{
}
#endif
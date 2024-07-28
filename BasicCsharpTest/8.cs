#if false
using System.Diagnostics.CodeAnalysis;

namespace BasicCsharpTest;

public record Foo(float? A);

public static class Extensions
{
    public static void Extension(this Foo foo)
    {
        // var a = new Foo(foo.A.Value); //error 
        // var b = new List<Foo>() { new(null) }.Select(x => new Foo(x.A.Value)); //error 
        var c =
        (
            first: new List<Foo>() { new(null) }.Select(x => new Foo(x.A.Value)), //error in UI but not in build
            second: 1
        );
    }
}

public interface IBar
{
    void DoBar();

    void DoBar2()
    {
        Console.WriteLine("IBar doing DoBar2 default implementation");
    }
}

public class Bar : IBar
{
    void IBar.DoBar()
    {
        Console.WriteLine("Bar as IBar doing DoBar");
    }
    
    public void DoBar()
    {
        Console.WriteLine("Bar doing DoBar");
    }
}

public class Bar2 : IBar
{
    public void DoBar2()
    {
        Console.WriteLine("Bar2 doing DoBar2");
    }
    
    public void DoBar()
    {
        Console.WriteLine("Bar2 doing DoBar");
    }
}

public class SomeClass
{
    public void DoSomething()
    {
        var bar = new Bar(); 
        
        bar.DoBar(); //Bar doing DoBar
        ((IBar)bar).DoBar(); //Bar as IBar doing DoBar
        // bar.DoBar2(); //does not compile
        ((IBar)bar).DoBar2(); //IBar doing DoBar2 default implementation
        
        var bar2 = new Bar2();
        
        bar2.DoBar(); //Bar2 doing DoBar
        ((IBar)bar2).DoBar(); //Bar2 doing DoBar
        bar2.DoBar2(); //Bar2 doing DoBar2
        ((IBar)bar2).DoBar2(); //Bar2 doing DoBar2
    }
}
#endif
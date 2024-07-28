#if false
Console.WriteLine("Hello World");

var a = new A();
// a.DoSomething();
var b = new B();
// b.DoSomething();
var c = new C();
//c.DoSomething();

// var bAsA = (A)b;
// bAsA.DoSomething();
// var cAsA = (A)c;
// cAsA.DoSomething();

public class A
{
    public A()
    {
        ((A)this).DoSomething();
    }
    
    public virtual void DoSomething()
    {
        Console.WriteLine("A");
    }
}

public class B : A
{
    public B()
    {
        
    }
    
    public override void DoSomething()
    {
        Console.WriteLine("B");
    }
}

public class C : B
{
    public C()
    {
        
    }
    
    public override void DoSomething()
    {
        Console.WriteLine("C");
    }
}
#endif
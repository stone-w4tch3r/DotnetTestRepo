#if false
using BasicCsharpTest;

Console.WriteLine("Hello World");

var a = 0.0000000000000000000000000000000000000000000000001d;
var m = 10000000000000000000000000000000000000000000000000d;
var b = a * m;
Console.WriteLine(b);
Console.WriteLine(b == 1);

Console.WriteLine(nameof(SomeClass));
Console.WriteLine(typeof(SomeClass));
Console.WriteLine(typeof(SomeClass).FullName);
Console.WriteLine(typeof(SomeClass).AssemblyQualifiedName);
#endif
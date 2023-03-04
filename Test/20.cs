Console.WriteLine();

await DoWrapped();

Console.WriteLine("Hello World4!");

static async Task DoWrapped()
{
    async Task Act() => await DoSomethingAsync();

    Console.WriteLine("Hello World1!");
    // await ExecuteAsyncLambda(Act);
    await ExecuteAsyncLambda(async () => await DoSomethingAsync());
    Console.WriteLine("Hello World3!");
    
    static async Task ExecuteAsyncLambda(Func<Task> act)
    {
        await act();
    }
}

static async Task DoSomethingAsync()
{
    await Task.Run(DoSomething);
}

static void DoSomething()
{
    var person = new Person();
    var myClass = new MyClass(person);
}

public class Person
{
    public string Name { get; set; }
}

public class MyClass
{
    public MyClass(Person person)
    {
        Console.WriteLine("Hello World2!");
        var l = person.Name.Length;
    }
}
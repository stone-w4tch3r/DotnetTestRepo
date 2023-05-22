// See https://aka.ms/new-console-template for more information

using DryIoc;
using DryIocTest;

Console.WriteLine("Hello, World!");

var resolver = ContainerRegistry.CreateResolver();

var test1 = resolver.Resolve<Test1ViewModel>();
Console.WriteLine(test1.ChildViewModel.Dependency1.Guid);
Console.WriteLine(test1.Dependency1.Guid);
var test12 = resolver.Resolve<Test1ViewModel>();
Console.WriteLine(test12.ChildViewModel.Dependency1.Guid);
Console.WriteLine(test12.Dependency1.Guid);

var test2 = resolver.Resolve<Test2ViewModel>();
Console.WriteLine(test2.ChildViewModel.Dependency2.Guid);
Console.WriteLine(test2.Dependency2.Guid);
var test22 = resolver.Resolve<Test2ViewModel>();
Console.WriteLine(test22.ChildViewModel.Dependency2.Guid);
Console.WriteLine(test22.Dependency2.Guid);


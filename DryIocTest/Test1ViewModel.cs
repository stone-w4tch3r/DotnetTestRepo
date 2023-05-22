namespace DryIocTest;

public class Test1ViewModel : IDisposable
{
    public Dependency1 Dependency1 { get; }
    
    public Child1ViewModel ChildViewModel { get; }
    
    public Test1ViewModel(Dependency1 dependency1, Child1ViewModel childViewModel)
    {
        Dependency1 = dependency1;
        ChildViewModel = childViewModel;
    }
    public void Dispose()
    {
        Console.WriteLine("Test1ViewModel.Dispose()");
    }
}
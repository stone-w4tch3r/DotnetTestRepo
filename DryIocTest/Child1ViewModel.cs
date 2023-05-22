namespace DryIocTest;

public class Child1ViewModel
{
    public Dependency1 Dependency1 { get; }
    
    public Child1ViewModel(Dependency1 dependency1)
    {
        Dependency1 = dependency1;
    }
}
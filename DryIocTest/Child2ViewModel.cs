namespace DryIocTest;

public class Child2ViewModel
{
    public Dependency2 Dependency2 { get; }
    
    public Child2ViewModel(Dependency2 dependency2)
    {
        Dependency2 = dependency2;
    }
}
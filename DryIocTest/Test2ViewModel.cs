namespace DryIocTest;

public class Test2ViewModel
{
    public Dependency2 Dependency2 { get; }
    
    public Child2ViewModel ChildViewModel { get; }
    
    public Test2ViewModel(Dependency2 dependency2, Child2ViewModel childViewModel)
    {
        Dependency2 = dependency2;
        ChildViewModel = childViewModel;
    }
}
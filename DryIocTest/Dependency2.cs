namespace DryIocTest;

public class Dependency2
{
    public Guid Guid { get; }
    
    public Dependency2()
    {
        Guid = Guid.NewGuid();
    }
}
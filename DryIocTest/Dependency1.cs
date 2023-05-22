namespace DryIocTest;

public class Dependency1
{
    public Guid Guid { get; }
    
    public Dependency1()
    {
        Guid = Guid.NewGuid();
    }
}
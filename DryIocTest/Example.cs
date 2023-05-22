using DryIoc;

namespace DryIocTest;

public class Example
{
    public static void Run()
    {
        var container = new Container(rules => rules
                .WithTrackingDisposableTransients() // we need this to allow disposable transient Foo
        );

        container.Register<Foo>(setup: Setup.With(openResolutionScope: true));

        container.Register<Dependency>(Reuse.ScopedToService<Foo>());

        var foo = container.Resolve<Foo>();
        
        // Disposing the foo will dispose its scope and its scoped dependencies down the tree
        foo.Dispose(); 

        Console.WriteLine(foo.Dep.IsDisposed);
    }
    
    class Foo : IDisposable
    {
        public Dependency Dep { get; }
        private readonly IResolverContext _scope;
        public Foo(Dependency dep, IResolverContext scope) 
        { 
            Dep = dep;
            _scope = scope;
        }

        public void Dispose() => _scope.Dispose();
    }

    class Dependency : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public void Dispose() => IsDisposed = true;
    }
}
using DryIoc;

namespace DryIocTest;

public class ContainerRegistry
{
    public static IResolver CreateResolver()
    {
        var container = new Container(rules => rules.WithTrackingDisposableTransients());
        
        container.Register<Test1ViewModel>(setup: Setup.With(openResolutionScope: true));
        container.Register<Dependency1>(Reuse.ScopedToService<Test1ViewModel>());
        container.Register<Child1ViewModel>();
        
        container.Register<Test2ViewModel>(setup: Setup.With(openResolutionScope: true));
        container.Register<Dependency2>(Reuse.ScopedToService<Test2ViewModel>());
        container.Register<Child2ViewModel>();
        
        return container;
    }
}
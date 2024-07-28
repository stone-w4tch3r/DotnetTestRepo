#if false
Console.WriteLine("Hello World!");

var vm = new MainViewModel();
Console.WriteLine(vm.MyViewModel.MyCollection!.List.Count);
var fragment = new Fragment(vm);
Console.WriteLine(fragment.SavedCollection.List.Count);
vm.Add2Elements();
Console.WriteLine(vm.MyViewModel.MyCollection.List.Count);
Console.WriteLine(fragment.SavedCollection.List.Count);

public class SomeObject
{
}

public class MyCollection
{
    public List<SomeObject> List { get; } = new();
}

public class MyViewModel
{
    public MyCollection? MyCollection { get; set; }
}

public class MainViewModel
{
    public MyCollection MyCollectionAlias => MyViewModel.MyCollection!;
    public MyViewModel MyViewModel { get; set; } = new() { MyCollection = new() };
    public MyCollection GetMyCollection() => MyViewModel.MyCollection!;
    public void Add2Elements()
    {
        MyViewModel = new() { MyCollection = new() { List = { new(), new() } } };
    }
}

public class Fragment
{
    public MyCollection SavedCollection => ViewModel.GetMyCollection();
    public MainViewModel ViewModel { get; set; }
    public Fragment(MainViewModel viewModel)
    {
        ViewModel = viewModel;
        //SavedCollection = ViewModel.MyCollectionAlias;
    }
}
#endif
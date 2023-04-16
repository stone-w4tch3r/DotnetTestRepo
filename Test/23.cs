#if false
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EBind;

Console.WriteLine();

var car = new Car();
var carPresenter = new CarPresenter(car);
car.PropertyChanged += (sender, eventArgs) => Console.WriteLine(eventArgs.PropertyName + " changed");
Console.WriteLine(carPresenter.DriverName);
car.Driver.Name = "Ann2";
Console.WriteLine(carPresenter.DriverName);
car.LoadData();
Console.WriteLine(carPresenter.DriverName);
car.Driver = new() { Name = "John2" };
Console.WriteLine(carPresenter.DriverName);

internal class CarPresenter
{
    private readonly Car _car;
    private EBinding _binding;

    public string DriverName { get; set; }

    public CarPresenter(Car car)
    {
        _car = car;

        _binding = new()
        {
            () => DriverName == "driver name: " + _car.Driver.Name
        };
    }
}

internal class Car : NotifyPropertyChangedBase
{
    private Person _driver = new() { Name = "Ann" };
    public Person Driver
    {
        get => _driver;
        set => SetProperty(ref _driver, value);
    }

    public void LoadData()
    {
        Console.WriteLine("Loading data...");
        Driver = new() { Name = "John" };
    }
}

internal class Person : NotifyPropertyChangedBase
{
    private string? _name;
    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }
}

internal class NotifyPropertyChangedBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }

    protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value))
            return;
        field = value;
        OnPropertyChanged(propertyName);
    }
}
#endif
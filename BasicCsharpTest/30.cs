Console.WriteLine("start");

var x = 0;
object locker = new(); // объект-заглушка
// запускаем пять потоков
for (var i = 1; i < 6; i++)
{
    var myThread = new Thread(Print) { Name = $"Поток {i}" };
    myThread.Start();
}

return;


void Print()
{
    x = 1;
    lock (locker)
    {
        for (var i = 1; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
        }
    }
}
// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;

Console.WriteLine("start");

// BasicLockShowcase.Run();
LockMonitorImplementation.Run();
// LockMonitorImplementation.DeadlockIfNotExitDueToException();

//.NET 9 has special System.Threading.Lock with non-monitor implementation

internal static class BasicLockShowcase
{
    private static int x = 0;
    private static readonly object locker = new(); // объект-заглушка

    public static void Run()
    {
        for (var i = 1; i < 6; i++) // запускаем пять потоков
        {
            var t = new Thread(() =>
                {
                    x = 1;
                    // lock (locker)
                    {
                        for (var i1 = 1; i1 < 6; i1++)
                        {
                            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                            x++;
                            Thread.Sleep(100);
                        }
                    }
                })
                { Name = $"Поток {i}" };
            t.Start();
        }
    }
}

// lock (locker) - это синтаксический сахар для Monitor.Enter и Monitor.Exit
internal static class LockMonitorImplementation
{
    private static int x = 0;
    private static readonly object locker = new(); // объект-заглушка

    public static void Run()
    {
        for (var i = 1; i < 6; i++) // запускаем пять потоков
        {
            var t = new Thread(() =>
                {
                    x = 1;
                    Monitor.Enter(locker);
                    for (var i1 = 1; i1 < 6; i1++)
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                        x++;
                        Thread.Sleep(100);
                    }

                    Monitor.Exit(locker);
                })
                { Name = $"Поток {i}" };
            t.Start();
        }
    }
    
    public static void DeadlockIfNotExitDueToException()
    {
        var t = new Thread(() =>
        {
            Monitor.Enter(locker);
            throw new ("Exception in thread");
            Monitor.Exit(locker);
        });
        t.Start();
        var t2 = new Thread(() =>
        {
            Monitor.Enter(locker);
            Console.WriteLine("This will never be printed");
            Monitor.Exit(locker);
        });
        t2.Start();
    }
}
#if false
Console.WriteLine();

var result = await GetIntAsync()
    .DoAsync(async x => await Log($"Result: {x}"))
    .ToAsync(async _ => $"int {await GetIntAsync()}");

static async Task<int> GetIntAsync()
{
    await Task.Delay(1000);
    return 42;
}

static async Task Log(string message)
{
    await Task.Delay(1000);
    Console.WriteLine(message);
}

public static class FunctionalExtensions
{
    public static async Task<TResult> ToAsync<TSource, TResult>(
        this Task<TSource> task,
        Func<TSource, Task<TResult>> func) 
        =>
            await func(await task);
    
    public static async Task<TSource> DoAsync<TSource>(
        this Task<TSource> task,
        Func<TSource, Task> func)
    {
        await func(await task);
        return await task;
    }
}
#endif
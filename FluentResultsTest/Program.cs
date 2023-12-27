// See https://aka.ms/new-console-template for more information

using FluentResults;

var action = new Action(() => throw new Exception("test"));
var result = Result.Try(action);

var worker = new Worker();
var result2 = Result.Try(worker.DoWork);

result.WithErrors(result2.Errors)
    .WithError($"error {new List<int> {1, 2, 3}}");

Console.WriteLine(result);

public class Worker
{
    public void DoWork()
    {
        throw new NotImplementedException();
    }
}
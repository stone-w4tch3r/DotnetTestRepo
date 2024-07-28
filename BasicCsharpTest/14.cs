#if false
Console.WriteLine("Hello World");

IEnumerable<int> ids = new[] { 10, 20 };
var ids2 = ids.Append(1);

Console.WriteLine(ids.Count());
Console.WriteLine(ids2.Count());
Console.WriteLine(ReferenceEquals(ids, ids2));
Console.WriteLine(ids.GetType());
Console.WriteLine(ids2.GetType());
#endif
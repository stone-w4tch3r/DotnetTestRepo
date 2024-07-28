#if false
var input = Console.ReadLine();
int? i = int.Parse(input ?? string.Empty) == 0 ? null : int.Parse(input ?? string.Empty);
Console.WriteLine(i);
Console.WriteLine(i.HasValue);
Console.WriteLine(i.Value);

#endif
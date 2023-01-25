#if false
using System.Globalization;

Console.WriteLine("Hello World");

var a = "-64.678703";
var b = double.TryParse(a, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : 0;
Console.WriteLine(b);
#endif
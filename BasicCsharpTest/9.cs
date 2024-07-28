#if false
//Hello world
Console.WriteLine("Hello, world!");

string[] words = new string[]
{
    // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumps",    // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};              // 9 (or words.Length) ^0

Console.WriteLine($"The last word is {words[^1]}");
Console.WriteLine($"The last word is {words[words.Length - 1]}");
Console.WriteLine($"The first word is {words[^words.Length]}");

var seq = words[1..^1];
foreach (var word in seq)
    Console.Write($"< {word} >");
Console.WriteLine();

//numbers

var numbers = Enumerable.Range(0, 100).ToArray();
Console.WriteLine(numbers[^1]);
Console.WriteLine(numbers[..]);
Console.WriteLine(numbers[1..]);
Console.WriteLine(numbers[1..]);

// You can also use it with multidimensional arrays

int[,] matrix =
{
    { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
    { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 },
    { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 },
    { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 },
    { 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 },
    { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 },
    { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 },
    { 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 },
    { 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 },
    { 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 }
};

// Console.WriteLine(matrix[^1, ^1]);

// You can also use it with ranges

Range phrase = 1..4;
Range lastWords = ^2..^0;
Range everything = ..;
Range firstColumn = 1..^1;

Console.WriteLine(string.Join(" ", words[phrase]));
Console.WriteLine(string.Join(" ", words[lastWords]));
Console.WriteLine(string.Join(" ", words[everything]));
Console.WriteLine(string.Join(" ", words[firstColumn]));
#endif
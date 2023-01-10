#if false

using System.Text;
using System.Text.RegularExpressions;

var test = @"It\u00e2\u0080\u0099s working";
var unescaped = Regex.Unescape(test);
var bytes = Encoding.GetEncoding(28591).GetBytes(unescaped);
var converted = Encoding.UTF8.GetString(bytes);

Console.WriteLine(converted);
#endif
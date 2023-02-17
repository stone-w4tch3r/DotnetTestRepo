using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("dick");

var color = Color.Aqua;

//serialize color to json
var colorJson = JsonSerializer.Serialize(color);
//serialize color to string
var colorString = color.ToString();

//write color to console
Console.WriteLine(colorJson);
Console.WriteLine(colorString);

//deserialize json to color
var colorFromJson = JsonSerializer.Deserialize<Color>(colorJson);
//deserialize string to color
var colorFromString = Color.FromName(colorString);

//
//
//

var myClass = new MyClass { Color = Color.Aqua };
var myClassJson = JsonSerializer.Serialize(myClass);
Console.WriteLine(myClassJson);
var myClassFromJson = JsonSerializer.Deserialize<MyClass>(myClassJson);

var myClass2FromJson = JsonSerializer.Deserialize<MyClass>(
    """
    {"Color":"#00FFFF"}
    """
);
Console.WriteLine(myClass2FromJson);
var myClass2Json = JsonSerializer.Serialize(myClass2FromJson);
Console.WriteLine(myClass2Json);

public class MyClass
{
    [JsonConverter(typeof(JsonHexadecimalColorConverter))]
    public Color Color { get; set; }
}

public class JsonHexadecimalColorConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var colorString = reader.GetString();
        return ColorTranslator.FromHtml(colorString ?? "");
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        var colorString = ColorTranslator.ToHtml(value);
        writer.WriteStringValue(colorString);
    }
}
// See https://aka.ms/new-console-template for more information

using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

Console.WriteLine("Hello, World!");

var options =  new QrCodeEncodingOptions
{
    DisableECI = true,
    CharacterSet = "UTF-8",
    Width = 250,
    Height = 250,
};
// var writer = new BarcodeWriter();
// writer.Format = BarcodeFormat.QR_CODE;
// writer.Options = options; 
// var matrix = writer.Encode(str);
// var svgImage = ConvertToSvgImage(matrix);


SvgRenderer.SvgImage ConvertToSvgImage(BitMatrix matrix)
{
    var renderer = new SvgRenderer();
    var svgImage = renderer.Render(matrix, BarcodeFormat.QR_CODE, "hello");
    return svgImage;
}
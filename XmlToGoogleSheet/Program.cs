// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Hello, World!");

XmlDocument doc = new XmlDocument();
doc.PreserveWhitespace = true;
try { doc.Load("example.xml"); }
catch (System.IO.FileNotFoundException ex)
{
    Console.WriteLine("File Not Found!");
    Console.WriteLine(ex.Message);
}

if(doc.DocumentElement != null)
{
    Console.Write(doc.DocumentElement.OuterXml);
}

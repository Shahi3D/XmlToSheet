// See https://aka.ms/new-console-template for more information
using System.Xml;

Console.WriteLine("Hello, World!");

XmlDocument doc = new XmlDocument();
doc.PreserveWhitespace = true;

var docsName = "example.xml";

if(args.Length > 0)
{
    docsName = args[0];
}

try { doc.Load(docsName); }
catch (System.IO.FileNotFoundException ex)
{
    Console.WriteLine("File Not Found!");
    Console.WriteLine(ex.Message);
}

if(doc.DocumentElement != null)
{
    Console.Write(doc.DocumentElement.OuterXml);

    Console.WriteLine();

    if (doc.HasChildNodes)
    {
        for (int i = 0; i < doc.ChildNodes.Count; i++)
        {
            XmlNode child = doc.ChildNodes[i];
            if(child !=null && child.HasChildNodes)
            {
                for (int j = 0; j < child.ChildNodes.Count; j++)
                {
                    var childNode = child.ChildNodes[j];
                    var outer = childNode.OuterXml.Replace("\r", "").Replace("\n", "").ToString();
                    if (!string.IsNullOrWhiteSpace(outer))
                    {
                        Console.WriteLine(outer);
                    }

                    var text = childNode.InnerText.Replace("\r", "").Replace("\n", "").ToString();
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        Console.WriteLine($"Node Name: {childNode.Name}");
                        Console.WriteLine(text);
                    }
                }
            }
        }
    } 
}


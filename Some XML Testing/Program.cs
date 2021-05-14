using System;
using System.Xml.Linq;

namespace Some_XML_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the xml file to read, looking for HEAD, BODY tags. Include extension");
            string filename = Console.ReadLine();

            /* https://docs.microsoft.com/en-us/dotnet/standard/linq/query-xdocument-vs-query-xelement */
            //var xml = XDocument.Load($"{System.Environment.CurrentDirectory}\\{filename}");
            var xml = XDocument.Load($"C:\\users\\emurphy\\git\\H0rologium\\Some XML Testing\\{filename}");
            int i = 0;
            foreach (XElement q in xml.Root.Elements())
            {
                //Will print out each single tag element. For categorial elements (that have descendents) their values will all be bunched together
                if (q.HasElements && !q.HasAttributes)
                {
                    foreach (XElement e in q.Elements())
                    {
                        Console.WriteLine($"{e.Value.ToString()} child of {e.Parent}");
                    }    
                    //Attributes are the actual values, elements are children tags
                } else if (q.HasAttributes && !q.HasElements && !q.Parent.)
                {
                    Console.WriteLine(q.Value.ToString());
                    i += 1;
                }
                
            }
            
        }
    }
}

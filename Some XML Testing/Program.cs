using System;
using System.Xml.Linq;
using System.Collections;

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
                if (q.HasElements)
                {
                    foreach (XElement z in q.Elements())
                    {
                        Console.WriteLine($"{z.Value} \n which is a child of {z.Parent.Name}\n");
                    }

                } else {
                    Console.WriteLine(q.Value);
                    i += 1;
                }
                
            }
            
        }


        //Helps us grab an inclusive substring between two indexes provided as strings of desired locations at method call
        public static string TextBetween(string text, string startS, string endS, int padding = 0)
        {
            if (text.IndexOf(startS) < text.IndexOf(endS, padding)) { return text[(text.IndexOf(startS) + 1)..text.IndexOf(endS)]; }
            else return "ERROR! ENDING INDEX INVALID (<= STARTINDEX)";
        }

    }
}

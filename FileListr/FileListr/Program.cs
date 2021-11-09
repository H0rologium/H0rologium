using System;
using System.IO;
using System.Collections;
using System.Linq;

namespace FileListr
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Enter all hyphenated arguments now. only enter \"help\" to view help");
            args = Console.ReadLine().ToString().Split('-');
            if (args[0].ToLower().Contains("path") && args.Length > 1) p.RunEval(args);
            else if (args[0].ToLower().Contains("help")){
                Console.WriteLine("Example usage of this program (lists all arguments):\npath FOLDERPATH -FILETYPE(string, ex. png) \nExample: path C:\\Windows\\System32 -dll\n\n\n");
                Main(args);
            }else Console.WriteLine("No folder path provided!");  
        }

        void RunEval(string[] arguments)
        {
            string[] files = System.IO.Directory.GetFiles(arguments[0].Substring(arguments[0].IndexOf(' ') + 1), $"*.{arguments[1]}");
            ArrayList output = new ArrayList();
            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                filename = filename.Substring(0, filename.Length - 4);//cannot use 'file' in a substring operation, im guessing its because its an enumerable?
                Console.WriteLine(filename);
                output.Add(filename);
            }
            //Fout
            //FileStream f = new FileStream("PATH", FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read);
            File.Create($"{arguments[0].Substring(arguments[0].IndexOf(' ') + 1).TrimEnd()}\\results.txt").Close();
            using (StreamWriter sw  = new StreamWriter($"{arguments[0].Substring(arguments[0].IndexOf(' ') + 1).TrimEnd()}\\results.txt"))
            {
                foreach (string line in output)
                {
                    sw.WriteLine(line);
                }
            }        
        
        }
    }
}

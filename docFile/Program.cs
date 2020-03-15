using System;
using System.IO;
using System.Text;

namespace docFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string writeText = "Hello World!";  // Create a text string
            File.WriteAllText("C:\\Users\\Admin\\OneDrive\\Desktop\\tho.txt", writeText);
            Console.ReadKey();

        }
    }
}

using System;
using System.IO;
namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3) // remember to give three file names.. 
            {
                Console.WriteLine("Document Merger");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Give some text files to be MERGED. Make sure to include the name of the file that will include the merged files.");
                Console.WriteLine("No less than two files can be provided");
            }

            string[] userFiles = new string[args.Length-1];
            Array.Copy(args, 0, userFiles, 0, args.Length - 1);

            var newFile = args[args.Length - 1];
            StreamWriter write = null;
            try 
            {
                write = new StreamWriter(newFile);
            }
            catch (Exception error)
            {
                Console.WriteLine("Error opening to write to {0}: {1}", newFile, error.Message);

            }

            ulong characterCount = 0;
            StreamReader read = null;
            string currentFile = null;

            try
            {
                foreach (string inputFile in userFiles)
                {
                    currentFile = inputFile;
                    read = new StreamReader(currentFile);
                    string line = null;
                    while ((line = read.ReadLine()) != null)
                    {
                        write.WriteLine(line);
                        characterCount = characterCount + (ulong)line.Length;
                    }
                    read.Close();
                }
            }
            catch (Exception error) 
            {
                Console.WriteLine("Something went wrong here..{0}: {1}", currentFile, error.Message);
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                    //if read is not null work it closes..
                }
                if (write != null)
                {
                    write.Close();
                    //if write is not null """"  .. 
                }
            }

            Console.WriteLine("{0} was saved. {0} contains {1} characters total", currentFile, characterCount);
        }
    }
}

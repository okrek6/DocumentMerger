using System;
using System.IO;
namespace DocumentMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> <input_file_n> <output_file>");
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
                Console.WriteLine("Error while processing {0}: {1}", currentFile, error.Message);
                System.Environment.Exit(2);
            }
            finally
            {
                if (read != null)
                {
                    read.Close();
                }
                if (write != null)
                {
                    write.Close();
                }
            }

            Console.WriteLine("{0} was successfully saved. The document contains {1} characters", currentFile, characterCount);
        }
    }
}

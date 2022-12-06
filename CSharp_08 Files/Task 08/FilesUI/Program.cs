using System;
using Files;
using System.Text;
using System.IO;

namespace FilesUI
{
    class Program
    {
        public static void Write(string filePath, string content)
        {
            char[] contentArray = content.ToCharArray();
            FileManager newFile = FileManager.Create(filePath, contentArray.Length);
            newFile.fstream = new FileStream(filePath, FileMode.Open);
            newFile.writer = new StreamWriter(newFile.fstream);
            try
            {
                newFile.writer.Write(contentArray);
                newFile.writer.Close();
                newFile.fstream.Close();
            }
            finally
            {
                newFile.Dispose();
            }
        }

        public static string Read(string filePath)
        {
            using var reader = new StreamReader(filePath);
            FileManager fileToRead = FileManager.Read(filePath);
            fileToRead.reader = reader;
            fileToRead.reader.Close();
            return new string(fileToRead.fileContent);
        }

        public static void Edit(string filePath, char charToReplaceWith)
        {
            using var writer = new StreamWriter(filePath);
            FileManager fileToEdit = FileManager.Read(filePath);
            fileToEdit.writer = writer;
            fileToEdit.writer.Close();
            fileToEdit[2] = charToReplaceWith;
        }

        static void Main(string[] args)
        {
            Write(@"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_08\Task 08\NewFile.txt", "[01] Привет мир!");
            Console.WriteLine(Read(@"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_08\Task 08\NewFile.txt"));
            Edit(@"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_08\Task 08\NewFile.txt", '2');
        }
    }
}

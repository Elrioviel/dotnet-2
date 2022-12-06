using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Files
{
    public class FileManager : IDisposable
    {
        public FileStream fstream;
        public StreamReader reader;
        public StreamWriter writer;
        private bool disposedValue = false;
        private readonly string filePath;
        public char[] fileContent;
        private FileManager(string FilePath, int FileArrayLength)
        {
            filePath = FilePath;
            fileContent = new char[FileArrayLength];
            fstream = new FileStream(FilePath, FileMode.CreateNew);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            writer = new StreamWriter(fstream, Encoding.GetEncoding(1252), FileArrayLength);
            for (int i = 0; i < FileArrayLength; i++)
            {
                writer.Write(" ");
            }
            writer.Close();
            fstream.Dispose();
        }

        private FileManager(string FilePath)
        {
            filePath = FilePath;
            if (File.Exists(filePath))
            {
                string fileContentStr;
                fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fstream);
                fileContentStr = reader.ReadToEnd();
                fileContent = fileContentStr.ToCharArray();
                reader.Close();
                fstream.Dispose();
            }
        }

        public static FileManager Create(string filePath, int fileArrayLength)
        {
            if (filePath != null)
            {
                FileManager file = new FileManager(filePath, fileArrayLength);
                return file;
            }
            else
            {
                throw new ArgumentNullException(nameof(filePath));
            }
        }

        public static FileManager Read(string filePath)
        {
            if (filePath != null)
            {
                FileManager file = new FileManager(filePath);
                return file;
            }
            else
            {
                throw new ArgumentNullException(nameof(filePath));
            }
        }

        public char this[int index]
        {
            get
            {
                char[] buffer = new char[1];
                return (char)reader.Read(buffer, index, 1);
            }
            set => writer.Write(value);
        }

        public int Length
        {
            get
            {
                return fileContent.Length;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    fstream = null;
                    reader = null;
                    writer = null;
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~FileManager()
        {
            Dispose(false);
        }
    }
}

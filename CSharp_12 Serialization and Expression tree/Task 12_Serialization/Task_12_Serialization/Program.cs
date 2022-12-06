using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using BinaryTree;
using Students;
using System.Xml.Serialization;

namespace Task_12_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> bstStudent = new();
            BinarySearchTree<int> bstInt = new();
            Student student1 = new() { Name = "Mike", Surname = "Myke", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 4 };
            Student student2 = new() { Name = "Catherine", Surname = "Colley", Test = "Geography", Date = new DateTime(2021, 06, 01), Score = 5 };
            Student student3 = new() { Name = "Rachel", Surname = "Pennington", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 1 };
            Student student4 = new() { Name = "Nathanial", Surname = "Hutchinson", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 4 };
            Student student5 = new() { Name = "John-Paul", Surname = "Kumar", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 4 };
            bstInt.AddRange(new List<int>() { 75, 57, 90, 32, 7, 44, 60, 86, 93, 99 });
            bstStudent.AddRange(new List<string>() { student1.ToString(), student2.ToString(), student3.ToString(), student4.ToString(), student5.ToString() });
            BinarySerialize(bstInt, @"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_12\Task 12_Serialization\IntBinarySerialization.dat");
            BinaryDeserialize(bstInt, @"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_12\Task 12_Serialization\IntBinarySerialization.dat");
            BinarySerialize(bstStudent, @"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_12\Task 12_Serialization\StudentBinarySerialization.dat");
            BinaryDeserialize(bstStudent, @"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_12\Task 12_Serialization\StudentBinarySerialization.dat");
            XMLSerialize(typeof(BinarySearchTree<int>), bstInt, @"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_12\Task 12_Serialization\IntXMLSerialization.dat");
            XMLDeserialize(typeof(BinarySearchTree<int>), bstInt, @"C:\Netlab_GhaliaDahech\Git\CSharp\CSharp_12\Task 12_Serialization\IntXMLSerialization.dat");
        }

        public static void BinarySerialize(object tree, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            try
            {
                bf.Serialize(fileStream, tree);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static void BinaryDeserialize(object tree, string filePath)
        {
            FileStream fileStream = new(filePath, FileMode.Open);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                tree = bf.Deserialize(fileStream);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

        public static void XMLSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new(dataType);
            if (File.Exists(filePath)) File.Delete(filePath);
            TextWriter writer = new StreamWriter(filePath);
            xmlSerializer.Serialize(writer, data);
            writer.Close();
        }

        public static object XMLDeserialize(Type dataType, object data, string filePath)
        {
            object obj = null;
            XmlSerializer xmlSerializer = new(dataType);
            if(File.Exists(filePath))
            {
                TextReader txtReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(txtReader);
            }
            return obj;
        }
    }
}

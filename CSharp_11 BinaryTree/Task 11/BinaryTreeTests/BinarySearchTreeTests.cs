using NUnit.Framework;
using BinaryTree;
using Students;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BinaryTreeTests
{
    [TestFixture]
    public class Tests
    {
        private Student student1, student2, student3, student4, student5;
        [Test]
        public void TestInOrderTraversal_BinaryTreeOfIntegers_ReturnsExpectedString()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.AddRange(new List<int>() { 75, 57, 90, 32, 7, 44, 60, 86, 93, 99 });

            List<int> expected = new List<int> { 7, 32, 44, 57, 60, 75, 86, 90, 93, 99 };
            IEnumerable<int> actual = bst.InOrderTraversal(bst.GetRoot());
            Assert.That(actual.SequenceEqual(expected));
        }

        [Test]
        [TestCase(99, 99)]
        [TestCase(75, 75)]
        [TestCase(7, 7)]
        [TestCase(44, 44)]
        [TestCase(86, 86)]
        public void TestFind_BinaryTreeWithIntegers_ReturnsExpectedDataOfNode(int value, int expectedData)
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.AddRange(new List<int>() { 75, 57, 90, 32, 7, 44, 60, 86, 93, 99 });
            var foundNode = bst.Find(value, bst.GetRoot());

            Assert.AreEqual(expectedData, foundNode.Data);
        }

        [Test]
        public void TestInOrderTraversal_BinaryTreeOfStrings_ReturnsExpectedString()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            bst.AddRange(new List<string>() { "e", "d", "f", "b", "g", "a", "h", "c", "i", "j" });

            List<string> expected = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            IEnumerable<string> actual = bst.InOrderTraversal(bst.GetRoot());
            Assert.That(actual.SequenceEqual(expected));
        }

        [Test]
        [TestCase("b", "b")]
        [TestCase("f", "f")]
        [TestCase("e", "e")]
        [TestCase("i", "i")]
        [TestCase("c", "c")]
        public void TestFind_BinaryTreeOfStrings_ReturnsExpectedDataOfNode(string stringToFind, string expectedData)
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            bst.AddRange(new List<string>() { "e", "d", "f", "b", "g", "a", "h", "c", "i", "j" });
            var foundNode = bst.Find(stringToFind, bst.GetRoot());

            Assert.AreEqual(expectedData, foundNode.Data);
        }

        [SetUp]
        public void SetUp()
        {
            student1 = new Student { Name = "Mike", Surname = "Myke", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 4 };
            student2 = new Student { Name = "Catherine", Surname = "Colley", Test = "Geography", Date = new DateTime(2021, 06, 01), Score = 5 };
            student3 = new Student { Name = "Rachel", Surname = "Pennington", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 1 };
            student4 = new Student { Name = "Nathanial", Surname = "Hutchinson", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 4 };
            student5 = new Student { Name = "John-Paul", Surname = "Kumar", Test = "Biography", Date = new DateTime(2021, 11, 05), Score = 4 };
        }

        [Test]
        public void TestInOrderTraversal_BinaryTreeOfStudents_ReturnsExpected()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            bst.AddRange(new List<string>() { student1.ToString(), student2.ToString(), student3.ToString(), student4.ToString(), student5.ToString() });

            List<string> expected = new List<string>() { student2.ToString(), student5.ToString(), student1.ToString(), student4.ToString(), student3.ToString() };
            var actual = bst.InOrderTraversal(bst.GetRoot());

            Assert.That(actual.SequenceEqual(expected));
        }

        [Test]
        public void TestFind_BinaryTreeOfStudents_ReturnsExpectedDataOfStudentCatherine()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            bst.AddRange(new List<string>() { student1.ToString(), student2.ToString(), student3.ToString(), student4.ToString(), student5.ToString() });
            var foundNode = bst.Find("Name: Catherine, Surname: Colley, Test: Geography, Date: 01.06.2021 0:00:00, Score: 5", bst.GetRoot());

            Assert.AreEqual(student2.ToString(), foundNode.Data);
        }
    }
}
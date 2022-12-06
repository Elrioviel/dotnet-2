using NUnit.Framework;
using Students;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MoreLinq;

namespace StudentsTests
{
    [TestFixture]
    public class Tests
    {
        private static Student student1 = new Student { Name = "Mike", Surname = "Myke", Test = "Biography-100", Date = new DateTime(2021, 11, 05), Score = 4 };
        private static Student student2 = new Student { Name = "Catherine", Surname = "Colley", Test = "Geography-150", Date = new DateTime(2021, 06, 01), Score = 5 };
        private static Student student3 = new Student { Name = "Rachel", Surname = "Pennington", Test = "Biography-200", Date = new DateTime(2021, 11, 05), Score = 2 };
        private static Student student4 = new Student { Name = "Nathanial", Surname = "Hutchinson", Test = "Biography-150", Date = new DateTime(2021, 11, 05), Score = 3 };
        private static Student student5 = new Student { Name = "John-Paul", Surname = "Kumar", Test = "Biography-350", Date = new DateTime(2021, 11, 05), Score = 2 };
        private static Student student6 = new Student { Name = "John-Paul", Surname = "Kumar", Test = "Biography-350", Date = new DateTime(2022, 05, 01), Score = 4 };
        private static Student student7 = new Student { Name = "Mike", Surname = "Myke", Test = "Mathematics-250", Date = new DateTime(2022, 01, 01), Score = 4 };
        private static Student student8 = new Student { Name = "Catherine", Surname = "Colley", Test = "Graphics-100", Date = new DateTime(2022, 05, 01), Score = 5 };
        private static Student student9 = new Student { Name = "Rachel", Surname = "Pennington", Test = "Biography-200", Date = new DateTime(2022, 11, 02), Score = 3 };
        private static Student student10 = new Student { Name = "Nathanial", Surname = "Hutchinson", Test = "Graphics-100", Date = new DateTime(2022, 05, 01), Score = 4 };

        [TestCaseSource("FirstExamTestCase")]
        public DateTime TestStudents_FirstExamsDate_ReturnsExpected(List<Student> studentsList) => studentsList.Min(item => item.Date);

        public static IEnumerable<TestCaseData> FirstExamTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4 }).Returns(new DateTime(2021, 06, 01));
            yield return new TestCaseData(new List<Student>() { student3, student4, student5, student6 }).Returns(new DateTime(2021, 11, 05));
            yield return new TestCaseData(new List<Student>() { student7, student8, student9, student10 }).Returns(new DateTime(2022, 01, 01));
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 }).Returns(new DateTime(2021, 06, 01));
        }

        [TestCaseSource("TestsOfThisYear")]
        public int TestStudents_CountTests_ReturnsExpected(List<Student> studentsList) => studentsList.Where(student => student.Date.Year.Equals(DateTime.Today.Year)).Count();

        public static IEnumerable<TestCaseData> TestsOfThisYear()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 }).Returns(5);
        }

        [TestCaseSource("TestScoresTestCase")]
        public List<int> TestStudent_TopThreeScores_ReturnsExpected(List<int> studentsScores)
        {
            IEnumerable<int> distinct = studentsScores.Distinct();
            IOrderedEnumerable<int> distinctSorted = distinct.OrderByDescending(score => score);
            return distinctSorted.Take(3).ToList();
        }

        public static IEnumerable<TestCaseData> TestScoresTestCase()
        {
            yield return new TestCaseData(new List<int>() { student1.Score, student2.Score, student3.Score, student4.Score, student5.Score }).Returns(new List<int>() { 5, 4, 3 });
            yield return new TestCaseData(new List<int>() { student5.Score, student6.Score, student7.Score, student8.Score }).Returns(new List<int> { 5, 4, 2 });
            yield return new TestCaseData(new List<int>() { student2.Score, student8.Score, student3.Score, student10.Score, student1.Score }).Returns(new List<int>() { 5, 4, 2 });
        }

        [TestCaseSource("StudentsFullNamesTestCase")]
        public string TestStudents_StudentsFullNames_ReturnsExpected(List<Student> students)
        {
            List<string> fullNamesDistinct = GetAllStudentsFullNames(students);
            fullNamesDistinct.Sort();
            return String.Join(" | ", fullNamesDistinct.ToArray());
        }

        public string GetStudentsFullName(Student someStudent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(someStudent.Name + " " + someStudent.Surname);
            return sb.ToString();
        }

        public List<string> GetAllStudentsFullNames(List<Student> students)
        {
            List<string> studentsFullNames = new List<string>() { };
            foreach (var student in students)
            {
                studentsFullNames.Add(GetStudentsFullName(student));
            }
            return studentsFullNames.ToArray().Distinct().ToList();
        }

        public static IEnumerable<TestCaseData> StudentsFullNamesTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5 }).Returns("Catherine Colley | John-Paul Kumar | Mike Myke | Nathanial Hutchinson | Rachel Pennington");
            yield return new TestCaseData(new List<Student>() { student5, student6, student7, student8, student9 }).Returns("Catherine Colley | John-Paul Kumar | Mike Myke | Rachel Pennington");
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 }).Returns("Catherine Colley | John-Paul Kumar | Mike Myke | Nathanial Hutchinson | Rachel Pennington"); ;
        }

        [TestCaseSource("BestStudentsTestCase")]
        public List<Student> TestStudents_BestStudents_ReturnsExpected(List<Student> students)
        {
            IEnumerable<Student> worstStudents = students.Where(x => x.Score.Equals(2) || x.Score.Equals(3));
            IEnumerable<Student> distinct = students.DistinctBy(stud => new { stud.Name, stud.Surname });
            return distinct.Except(worstStudents).ToList();
        }

        public static IEnumerable<TestCaseData> BestStudentsTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5 }).Returns(new List<Student>() { student1, student2 });
            yield return new TestCaseData(new List<Student>() { student5, student6, student7, student8, student9 }).Returns(new List<Student>() { student7, student8 });
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student10 }).Returns(new List<Student>() { student1, student2 }); ;
        }

        [TestCaseSource("FailedTestsTestCase")]
        public string TestStudents_FailedTests_ReturnsExpected(List<Student> studentsList)
        {
            IEnumerable<Student> failedTests = studentsList.Where(x => x.Score.Equals(2));
            return string.Join(" | ", failedTests.Select(x => x.Test.ToString()));
        }

        public static IEnumerable<TestCaseData> FailedTestsTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 }).Returns("Biography-200 | Biography-350");
        }

        [TestCaseSource("AverageScoreTestCase")]
        public string TestStudents_AverageScore_ReturnsExpected(List<Student> studentsList)
        {
            List<string> studentsNames = GetAllStudentsFullNames(studentsList);
            List<string> allStudentsWithGrades = new List<string>();
            foreach (var name in studentsNames)
            {
                StringBuilder sb = new();
                IEnumerable<Student> currentStudent = studentsList.Where(student => student.Name.Equals(name.Split(' ')[0]) && student.Surname.Equals(name.Split(' ')[1]));
                int averageScore = currentStudent.Sum(i => i.Score) / currentStudent.Count();
                sb.Append(name + ": " + averageScore);
                allStudentsWithGrades.Add(sb.ToString());
            }
            return string.Join(" | ", allStudentsWithGrades.ToArray());
        }

        public static IEnumerable<TestCaseData> AverageScoreTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student10 }).Returns("Mike Myke: 4 | Catherine Colley: 5 | Rachel Pennington: 2 | Nathanial Hutchinson: 3 | John-Paul Kumar: 3");
        }

        [TestCaseSource("TestsOfGivenYearAndMonthTestCase")]
        public string TestStudents_TestsOfGivenYearAndMonth_ReturnsExpected(List<Student> passedTests, int year, int month)
        {
            IEnumerable<Student> testsAtGivenMonthAndYear = passedTests.Where(tests => tests.Date.Year.Equals(year) && tests.Date.Month.Equals(month));
            StringBuilder sb = new();
            foreach (var test in testsAtGivenMonthAndYear)
            {
                sb.Append(test.Test + ", ");
            }
            return sb.ToString();
        }

        public static IEnumerable<TestCaseData> TestsOfGivenYearAndMonthTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 }, 2022, 05).Returns("Biography-350, Graphics-100, Graphics-100, ");
            yield return new TestCaseData(new List<Student>() { student1, student2, student3, student4, student5, student6, student7, student8, student9, student10 }, 2021, 11).Returns("Biography-100, Biography-200, Biography-150, Biography-350, ");
        }

        [TestCaseSource("TestNamesMatchingPatternTestCase")]
        public bool TestStudents_TestsMatchRegexPatterns_ReturnsExpected(List<string> testName)
        {
            Regex rgx = new Regex(@"^[a-z A-Z]+-(\d*)");
            return testName.All(tests => rgx.IsMatch(tests));
        }

        public static IEnumerable<TestCaseData> TestNamesMatchingPatternTestCase()
        {
            yield return new TestCaseData(new List<string>() { student1.Test, student2.Test, student3.Test, student4.Test, student5.Test, student6.Test, student7.Test, student8.Test, student9.Test, student10.Test }).Returns(true);
            yield return new TestCaseData(new List<string>() { "Computer Science -", "-235", "5268-6545" }).Returns(false);
        }

        [TestCaseSource("AllTestsTakenByStudentTestCase")]
        public Dictionary<string, string[]> TestStudents_AllTestsTakenBySingleStudent_ReturnsExpected(List<Student> studentsTakingTests)
        {
            Dictionary<string, string[]> studentAndTests = new Dictionary<string, string[]>();
            List<string> allStudentsNames = GetAllStudentsFullNames(studentsTakingTests);
            foreach (var name in allStudentsNames)
            {
                IEnumerable<Student> currentStudent = studentsTakingTests.Where(student => student.Name.Equals(name.Split(' ')[0]) && student.Surname.Equals(name.Split(' ')[1]));
                IEnumerable<string> studentExams = currentStudent.Select(i => i.Test);
                studentAndTests.Add(name, studentExams.ToArray());
            }
            return studentAndTests;
        }

        public static IEnumerable<TestCaseData> AllTestsTakenByStudentTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student1, student2, student8, student7 }).Returns(new Dictionary<string, string[]>() { { "Mike Myke", new string[] { "Biography-100", "Mathematics-250" } }, { "Catherine Colley", new string[] { "Geography-150", "Graphics-100" } } });
            yield return new TestCaseData(new List<Student>() { student3, student9, student5, student6 }).Returns(new Dictionary<string, string[]>() { { "Rachel Pennington", new string[] { "Biography-200", "Biography-200" } }, { "John-Paul Kumar", new string[] { "Biography-350", "Biography-350" } } });
        }

        [TestCaseSource("TestsRetakenTestCase")]
        public List<string> TestStudent_RetakenTestsByStudent_ReturnsExpected(List<Student> studentsList)
        {
            List<string> retakenTestsByStudent = new();
            List<string> fullNames = GetAllStudentsFullNames(studentsList);
            foreach(var name in fullNames)
            {
                StringBuilder sb = new();
                IEnumerable<Student> currentStudent = studentsList.Where(student => student.Name.Equals(name.Split(' ')[0]) && student.Surname.Equals(name.Split(' ')[1]));
                IEnumerable<string> retakenTests = currentStudent.GroupBy(x => x.Test).Where(g => g.Count() > 1).Select(x => x.Key);
                sb.Append(name + ": " + string.Join(", ", retakenTests));
                retakenTestsByStudent.Add(sb.ToString());
            }
            return retakenTestsByStudent;
        }

        public static IEnumerable<TestCaseData> TestsRetakenTestCase()
        {
            yield return new TestCaseData(new List<Student>() { student3, student9, student5, student6 }).Returns(new List<string>() { "Rachel Pennington: Biography-200","John-Paul Kumar: Biography-350"});
        }

        [TestCaseSource("TestsNotTakenThisYear")]
        public List<string> TestStudent_TestsNotTakenThisYear_ReturnsExpected(List<Student> studentsList)
        {
            var testsTakenNotThisYear = studentsList.Where(student => student.Date.Year != DateTime.Today.Year).Select(x => x.Test);
            var testsTakenThisYear = studentsList.Where(student => student.Date.Year == DateTime.Today.Year).Select(x => x.Test);
            return testsTakenNotThisYear.Except(testsTakenThisYear).ToList();
        }

        public static IEnumerable<TestCaseData> TestsNotTakenThisYear()
        {
            yield return new TestCaseData(new List<Student>() { student6, student7, student5, student4 }).Returns(new List<string>() { "Biography-150" });
        }
    }
}
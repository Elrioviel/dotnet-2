using Department.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department.DAL;
using TestResultsBrowserWinForm;
using Entities;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TestResultsBrowser
{
    public partial class MainForm : Form
    {
        private StudentsBL students;
        private BindingSource studentsSource = new();
        public MainForm(StudentsBL studentsBl)
        {
            InitializeComponent();
            students = studentsBl;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            studentsSource.DataSource = students.InitList();
            studentData.DataSource = studentsSource;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddNewTestResults();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void filterByNameBtn_Click(object sender, EventArgs e)
        {
            AddFilterByName();
        }

        private void DisplayStudents()
        {
            studentData.DataSource = null;
            studentData.DataSource = students.GetList();
        }

        private void AddNewTestResults()
        {
            AddTestResultForm addResults = new AddTestResultForm();
            if (addResults.ShowDialog(this) == DialogResult.OK)
            {
                students.Add(addResults.name, addResults.surname, addResults.test, addResults.date, addResults.score);
                DisplayStudents();
            }
        }

        private void DiscardFilterBtn_Click(object sender, EventArgs e)
        {
            DisplayStudents();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.FileName.Contains("Score"))
                {
                    List<Student> filteredList = FilterStudentsByDeserializedFilter(LoadIntFilter(Path.GetFullPath(openFile.FileName)));
                    studentData.DataSource = filteredList;
                }
                if (openFile.FileName.Contains("Date"))
                {
                    List<Student> filteredList = FilterStudentsByDeserializedFilter(LoadDateFilter(Path.GetFullPath(openFile.FileName)));
                    studentData.DataSource = filteredList;
                }
                else
                {
                    List<Student> filteredList = FilterStudentsByDeserializedFilter(LoadStringFilter(Path.GetFullPath(openFile.FileName)));
                    studentData.DataSource = filteredList;
                }
            }
        }

        private List<Student> FilterStudentsByDeserializedFilter(FilterBuilder<Student, string> filterToApply)
        {
            return (List<Student>)students.FilterStudentsByFilterBuilder(filterToApply);
        }

        private List<Student> FilterStudentsByDeserializedFilter(FilterBuilder<Student, int> filterToApply)
        {
            return (List<Student>)students.FilterStudentsByFilterBuilder(filterToApply);
        }

        private List<Student> FilterStudentsByDeserializedFilter(FilterBuilder<Student, DateTime> filterToApply)
        {
            return (List<Student>)students.FilterStudentsByFilterBuilder(filterToApply);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                students.SaveList(Path.GetFullPath(saveFile.FileName));
            }
        }

        private void AddFilterByName()
        {
            FiltersForm filter = new();
            filter.ButtonNameWasClicked();
            if(filter.ShowDialog(this) == DialogResult.OK)
            {
                studentData.DataSource = students.FilterStudentsByFilterBuilder(filter.GetStringFilter());
            }
        }

        private FilterBuilder<Student, string> LoadStringFilter(string filePath)
        {
            FilterBuilder<Student, string> filter = new();
            BinaryDeserialize(filter, filePath);
            return filter;
        }

        private FilterBuilder<Student, int> LoadIntFilter(string filePath)
        {
            FilterBuilder<Student, int> filter = new();
            BinaryDeserialize(filter, filePath);
            return filter;
        }

        private FilterBuilder<Student, DateTime> LoadDateFilter(string filePath)
        {
            FilterBuilder<Student, DateTime> filter = new();
            BinaryDeserialize(filter, filePath);
            return filter;
        }

        public static void BinaryDeserialize(object data, string filePath)
        {
            FileStream fileStream = new(filePath, FileMode.Open);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                data = bf.Deserialize(fileStream);
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

        private void filterBySurnameBtn_Click(object sender, EventArgs e)
        {
            AddFilterBySurname();
        }

        private void AddFilterBySurname()
        {
            FiltersForm filter = new();
            filter.ButtonSurnameWasClicked();
            if (filter.ShowDialog(this) == DialogResult.OK)
            {
                studentData.DataSource = students.FilterStudentsByFilterBuilder(filter.GetStringFilter());
            }
        }

        private void AddFilterByTest()
        {
            FiltersForm filter = new();
            filter.ButtonTestWasClicked();
            if (filter.ShowDialog(this) == DialogResult.OK)
            {
                studentData.DataSource = students.FilterStudentsByFilterBuilder(filter.GetStringFilter());
            }
        }

        private void filterByTestBtn_Click(object sender, EventArgs e)
        {
            AddFilterByTest();
        }

        private void FilterByDateBtn_Click(object sender, EventArgs e)
        {
            AddFilterByDate();
        }

        private void AddFilterByDate()
        {
            FiltersForm filter = new();
            filter.ButtonDateWasClicked();
            if (filter.ShowDialog(this) == DialogResult.OK)
            {
                studentData.DataSource = students.FilterStudentsByFilterBuilder(filter.GetDateFilter());
            }
        }

        private void FilterByScoreBtn_Click(object sender, EventArgs e)
        {
            AddFilterByScore();
        }

        private void AddFilterByScore()
        {
            FiltersForm filter = new();
            filter.ButtonScoreWasClicked();
            if (filter.ShowDialog(this) == DialogResult.OK)
            {
                studentData.DataSource = students.FilterStudentsByFilterBuilder(filter.GetIntFilter());
            }
        }

        private void openItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                students.GetListFromFile(Path.GetFullPath(openFile.FileName));
                DisplayStudents();
            }
        }
    }
}

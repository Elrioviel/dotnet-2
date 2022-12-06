using Entities;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TestResultsBrowserWinForm
{
    public partial class FiltersForm : Form
    {
        public string filterBy;
        public string value;
        public string? secondValue;
        public string methodName;

        public FiltersForm()
        {
            InitializeComponent();
        }

        private void containsBtn_CheckedChanged(object sender, EventArgs e)
        {
            secondValLabel.Visible = false;
            secondValueTxtBox.Visible = false;
            methodName = "Contains";
        }

        private void equalsBtn_CheckedChanged(object sender, EventArgs e)
        {
            secondValLabel.Visible = false;
            secondValueTxtBox.Visible = false;
            methodName = "Equals";
        }

        private void greaterThanBtn_CheckedChanged(object sender, EventArgs e)
        {
            secondValLabel.Visible = false;
            secondValueTxtBox.Visible = false;
            methodName = "GreaterThan";
        }

        private void lessThanBtn_CheckedChanged(object sender, EventArgs e)
        {
            secondValLabel.Visible = false;
            secondValueTxtBox.Visible = false;
            methodName = "LessThan";
        }

        private void betweenBtn_CheckedChanged(object sender, EventArgs e)
        {
            methodName = "Between";
            secondValLabel.Visible = true;
            secondValueTxtBox.Visible = true;
        }

        private void valueTxtBox_Validated(object sender, EventArgs e)
        {
            value = valueTxtBox.Text;
        }

        private void secondValueTxtBox_Validated(object sender, EventArgs e)
        {
            secondValue = secondValueTxtBox.Text;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ButtonNameWasClicked()
        {
            filterBy = "Name";
        }

        public void ButtonSurnameWasClicked()
        {
            filterBy = "Surname";
        }

        public void ButtonTestWasClicked()
        {
            filterBy = "Test";
        }

        public void ButtonDateWasClicked()
        {
            filterBy = "Date";
        }

        public void ButtonScoreWasClicked()
        {
            filterBy = "Score";
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = $"FilterBy{filterBy}{value}.dat";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if (filterBy == "Score")
                {
                    FilterBuilder<Student, int> intFilter = GetIntFilter();
                    BinarySerialize(intFilter, Path.GetFullPath(saveFile.FileName));
                }
                else if (filterBy == "Date")
                {
                    FilterBuilder<Student, DateTime> dateFilter = GetDateFilter();
                    BinarySerialize(dateFilter, Path.GetFullPath(saveFile.FileName));
                }
                else
                {
                    FilterBuilder<Student, string> stringFilter = GetStringFilter();
                    BinarySerialize(stringFilter, Path.GetFullPath(saveFile.FileName));
                }
            }
        }
        private void applyBtn_Click(object sender, EventArgs e)
        {
            if (methodName == null || value == null || (methodName == "Between" & secondValue == null))
            {
                MessageBox.Show("Required fields empty");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        public FilterBuilder<Student, string> GetStringFilter()
        {
            return secondValue == null? new FilterBuilder<Student, string>(filterBy, value, methodName) : new FilterBuilder<Student, string>(filterBy, value, secondValue, methodName);
        }

        public FilterBuilder<Student, DateTime> GetDateFilter()
        {
            return secondValue == null? new FilterBuilder<Student, DateTime>(filterBy, Convert.ToDateTime(value), methodName) : new FilterBuilder<Student, DateTime>(filterBy, Convert.ToDateTime(value), Convert.ToDateTime(secondValue), methodName);
        }

        public FilterBuilder<Student, int> GetIntFilter()
        {
            return secondValue == null ? new FilterBuilder<Student, int>(filterBy, int.Parse(value), methodName) : new FilterBuilder<Student, int>(filterBy, int.Parse(value), int.Parse(secondValue), methodName);
        }

        public static void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bf = new();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            try
            {
                bf.Serialize(fileStream, data);
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

    }
}

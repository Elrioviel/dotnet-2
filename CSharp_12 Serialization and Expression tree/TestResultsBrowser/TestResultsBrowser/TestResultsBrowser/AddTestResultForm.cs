using System;
using System.Windows.Forms;

namespace TestResultsBrowserWinForm
{
    public partial class AddTestResultForm : Form
    {
        public string name;
        public string surname;
        public string test;
        public DateTime date;
        public int score;

        public AddTestResultForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxtBox.Text == "" | surnameTxtBox.Text == "" | testTxtBox.Text == "")
            {
                MessageBox.Show("Required fields empty");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void nameTxtBox_Validated(object sender, EventArgs e)
        {
            name = nameTxtBox.Text;
        }

        private void surnameTxtBox_Validated(object sender, EventArgs e)
        {
            surname = surnameTxtBox.Text;
        }

        private void testTxtBox_Validated(object sender, EventArgs e)
        {
            test = testTxtBox.Text;
        }

        private void testDatePicker_Validated(object sender, EventArgs e)
        {
            date = testDatePicker.Value;
        }

        private void two_CheckedChanged(object sender, EventArgs e)
        {
            score = 2;
        }

        private void three_CheckedChanged(object sender, EventArgs e)
        {
            score = 3;
        }

        private void four_CheckedChanged(object sender, EventArgs e)
        {
            score = 4;
        }

        private void five_CheckedChanged(object sender, EventArgs e)
        {
            score = 5;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

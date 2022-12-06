
namespace TestResultsBrowserWinForm
{
    partial class AddTestResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.surnameTxtBox = new System.Windows.Forms.TextBox();
            this.testTxtBox = new System.Windows.Forms.TextBox();
            this.testDatePicker = new System.Windows.Forms.DateTimePicker();
            this.two = new System.Windows.Forms.RadioButton();
            this.three = new System.Windows.Forms.RadioButton();
            this.four = new System.Windows.Forms.RadioButton();
            this.five = new System.Windows.Forms.RadioButton();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.scoreBox = new System.Windows.Forms.GroupBox();
            this.scoreBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(45, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student\'s name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(45, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Student\'s surname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(45, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Test subject:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(45, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Test taken:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(45, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Score:";
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameTxtBox.Location = new System.Drawing.Point(210, 55);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(253, 27);
            this.nameTxtBox.TabIndex = 5;
            this.nameTxtBox.Validated += new System.EventHandler(this.nameTxtBox_Validated);
            // 
            // surnameTxtBox
            // 
            this.surnameTxtBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.surnameTxtBox.Location = new System.Drawing.Point(210, 118);
            this.surnameTxtBox.Name = "surnameTxtBox";
            this.surnameTxtBox.Size = new System.Drawing.Size(253, 27);
            this.surnameTxtBox.TabIndex = 6;
            this.surnameTxtBox.Validated += new System.EventHandler(this.surnameTxtBox_Validated);
            // 
            // testTxtBox
            // 
            this.testTxtBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.testTxtBox.Location = new System.Drawing.Point(210, 181);
            this.testTxtBox.Name = "testTxtBox";
            this.testTxtBox.Size = new System.Drawing.Size(253, 27);
            this.testTxtBox.TabIndex = 7;
            this.testTxtBox.Validated += new System.EventHandler(this.testTxtBox_Validated);
            // 
            // testDatePicker
            // 
            this.testDatePicker.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.testDatePicker.Location = new System.Drawing.Point(210, 246);
            this.testDatePicker.Name = "testDatePicker";
            this.testDatePicker.Size = new System.Drawing.Size(253, 25);
            this.testDatePicker.TabIndex = 8;
            this.testDatePicker.Validated += new System.EventHandler(this.testDatePicker_Validated);
            // 
            // two
            // 
            this.two.AutoSize = true;
            this.two.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.two.Location = new System.Drawing.Point(22, 22);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(35, 23);
            this.two.TabIndex = 9;
            this.two.TabStop = true;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            this.two.CheckedChanged += new System.EventHandler(this.two_CheckedChanged);
            // 
            // three
            // 
            this.three.AutoSize = true;
            this.three.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.three.Location = new System.Drawing.Point(80, 22);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(35, 23);
            this.three.TabIndex = 10;
            this.three.TabStop = true;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            this.three.CheckedChanged += new System.EventHandler(this.three_CheckedChanged);
            // 
            // four
            // 
            this.four.AutoSize = true;
            this.four.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.four.Location = new System.Drawing.Point(138, 22);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(35, 23);
            this.four.TabIndex = 11;
            this.four.TabStop = true;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            this.four.CheckedChanged += new System.EventHandler(this.four_CheckedChanged);
            // 
            // five
            // 
            this.five.AutoSize = true;
            this.five.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.five.Location = new System.Drawing.Point(191, 22);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(35, 23);
            this.five.TabIndex = 12;
            this.five.TabStop = true;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = true;
            this.five.CheckedChanged += new System.EventHandler(this.five_CheckedChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveBtn.Location = new System.Drawing.Point(229, 404);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(136, 32);
            this.SaveBtn.TabIndex = 13;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(383, 404);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(136, 32);
            this.cancelBtn.TabIndex = 14;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // scoreBox
            // 
            this.scoreBox.Controls.Add(this.five);
            this.scoreBox.Controls.Add(this.two);
            this.scoreBox.Controls.Add(this.three);
            this.scoreBox.Controls.Add(this.four);
            this.scoreBox.Location = new System.Drawing.Point(210, 292);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(253, 58);
            this.scoreBox.TabIndex = 15;
            this.scoreBox.TabStop = false;
            // 
            // AddTestResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 468);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.testDatePicker);
            this.Controls.Add(this.testTxtBox);
            this.Controls.Add(this.surnameTxtBox);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddTestResultForm";
            this.Text = "New Test Result";
            this.scoreBox.ResumeLayout(false);
            this.scoreBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.TextBox surnameTxtBox;
        private System.Windows.Forms.TextBox testTxtBox;
        private System.Windows.Forms.DateTimePicker testDatePicker;
        private System.Windows.Forms.RadioButton two;
        private System.Windows.Forms.RadioButton three;
        private System.Windows.Forms.RadioButton four;
        private System.Windows.Forms.RadioButton five;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox scoreBox;
    }
}
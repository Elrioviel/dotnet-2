
namespace TestResultsBrowserWinForm
{
    partial class FiltersForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.secondValLabel = new System.Windows.Forms.Label();
            this.containsBtn = new System.Windows.Forms.RadioButton();
            this.equalsBtn = new System.Windows.Forms.RadioButton();
            this.greaterThanBtn = new System.Windows.Forms.RadioButton();
            this.lessThanBtn = new System.Windows.Forms.RadioButton();
            this.betweenBtn = new System.Windows.Forms.RadioButton();
            this.valueTxtBox = new System.Windows.Forms.TextBox();
            this.secondValueTxtBox = new System.Windows.Forms.TextBox();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filter:";
            // 
            // secondValLabel
            // 
            this.secondValLabel.AutoSize = true;
            this.secondValLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.secondValLabel.Location = new System.Drawing.Point(12, 195);
            this.secondValLabel.Name = "secondValLabel";
            this.secondValLabel.Size = new System.Drawing.Size(116, 21);
            this.secondValLabel.TabIndex = 3;
            this.secondValLabel.Text = "Second value:";
            this.secondValLabel.Visible = false;
            // 
            // containsBtn
            // 
            this.containsBtn.AutoSize = true;
            this.containsBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.containsBtn.Location = new System.Drawing.Point(6, 22);
            this.containsBtn.Name = "containsBtn";
            this.containsBtn.Size = new System.Drawing.Size(84, 24);
            this.containsBtn.TabIndex = 4;
            this.containsBtn.TabStop = true;
            this.containsBtn.Text = "Contains";
            this.containsBtn.UseVisualStyleBackColor = true;
            this.containsBtn.CheckedChanged += new System.EventHandler(this.containsBtn_CheckedChanged);
            // 
            // equalsBtn
            // 
            this.equalsBtn.AutoSize = true;
            this.equalsBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.equalsBtn.Location = new System.Drawing.Point(127, 22);
            this.equalsBtn.Name = "equalsBtn";
            this.equalsBtn.Size = new System.Drawing.Size(70, 24);
            this.equalsBtn.TabIndex = 5;
            this.equalsBtn.TabStop = true;
            this.equalsBtn.Text = "Equals";
            this.equalsBtn.UseVisualStyleBackColor = true;
            this.equalsBtn.CheckedChanged += new System.EventHandler(this.equalsBtn_CheckedChanged);
            // 
            // greaterThanBtn
            // 
            this.greaterThanBtn.AutoSize = true;
            this.greaterThanBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.greaterThanBtn.Location = new System.Drawing.Point(234, 22);
            this.greaterThanBtn.Name = "greaterThanBtn";
            this.greaterThanBtn.Size = new System.Drawing.Size(109, 24);
            this.greaterThanBtn.TabIndex = 6;
            this.greaterThanBtn.TabStop = true;
            this.greaterThanBtn.Text = "Greater than";
            this.greaterThanBtn.UseVisualStyleBackColor = true;
            this.greaterThanBtn.CheckedChanged += new System.EventHandler(this.greaterThanBtn_CheckedChanged);
            // 
            // lessThanBtn
            // 
            this.lessThanBtn.AutoSize = true;
            this.lessThanBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lessThanBtn.Location = new System.Drawing.Point(381, 22);
            this.lessThanBtn.Name = "lessThanBtn";
            this.lessThanBtn.Size = new System.Drawing.Size(87, 24);
            this.lessThanBtn.TabIndex = 7;
            this.lessThanBtn.TabStop = true;
            this.lessThanBtn.Text = "Less than";
            this.lessThanBtn.UseVisualStyleBackColor = true;
            this.lessThanBtn.CheckedChanged += new System.EventHandler(this.lessThanBtn_CheckedChanged);
            // 
            // betweenBtn
            // 
            this.betweenBtn.AutoSize = true;
            this.betweenBtn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.betweenBtn.Location = new System.Drawing.Point(504, 22);
            this.betweenBtn.Name = "betweenBtn";
            this.betweenBtn.Size = new System.Drawing.Size(84, 24);
            this.betweenBtn.TabIndex = 8;
            this.betweenBtn.TabStop = true;
            this.betweenBtn.Text = "Between";
            this.betweenBtn.UseVisualStyleBackColor = true;
            this.betweenBtn.CheckedChanged += new System.EventHandler(this.betweenBtn_CheckedChanged);
            // 
            // valueTxtBox
            // 
            this.valueTxtBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.valueTxtBox.Location = new System.Drawing.Point(157, 128);
            this.valueTxtBox.Name = "valueTxtBox";
            this.valueTxtBox.Size = new System.Drawing.Size(582, 27);
            this.valueTxtBox.TabIndex = 14;
            this.valueTxtBox.Validated += new System.EventHandler(this.valueTxtBox_Validated);
            // 
            // secondValueTxtBox
            // 
            this.secondValueTxtBox.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.secondValueTxtBox.Location = new System.Drawing.Point(157, 193);
            this.secondValueTxtBox.Name = "secondValueTxtBox";
            this.secondValueTxtBox.Size = new System.Drawing.Size(582, 27);
            this.secondValueTxtBox.TabIndex = 15;
            this.secondValueTxtBox.Visible = false;
            this.secondValueTxtBox.Validated += new System.EventHandler(this.secondValueTxtBox_Validated);
            // 
            // applyBtn
            // 
            this.applyBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.applyBtn.Location = new System.Drawing.Point(343, 263);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(145, 43);
            this.applyBtn.TabIndex = 16;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(649, 263);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(145, 43);
            this.cancelBtn.TabIndex = 17;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.saveBtn.Location = new System.Drawing.Point(498, 263);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(145, 43);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.containsBtn);
            this.groupBox1.Controls.Add(this.equalsBtn);
            this.groupBox1.Controls.Add(this.greaterThanBtn);
            this.groupBox1.Controls.Add(this.lessThanBtn);
            this.groupBox1.Controls.Add(this.betweenBtn);
            this.groupBox1.Location = new System.Drawing.Point(151, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 68);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 344);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.secondValueTxtBox);
            this.Controls.Add(this.valueTxtBox);
            this.Controls.Add(this.secondValLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "FiltersForm";
            this.Text = "Apply Filter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label secondValLabel;
        private System.Windows.Forms.RadioButton containsBtn;
        private System.Windows.Forms.RadioButton equalsBtn;
        private System.Windows.Forms.RadioButton greaterThanBtn;
        private System.Windows.Forms.RadioButton lessThanBtn;
        private System.Windows.Forms.RadioButton betweenBtn;
        private System.Windows.Forms.TextBox valueTxtBox;
        private System.Windows.Forms.TextBox secondValueTxtBox;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
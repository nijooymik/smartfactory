﻿namespace MyFirstCSharp_01
{
    partial class Chap11_Middle_Exam_TestCode_2_Review
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(421, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "찾기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "다음 나열된 정수 중 2개를 추출하여 합한 값이 16이 되는 쌍을 모두 구하시오.\r\n\r\n                                " +
    "      1, 4, 6, 9, 10, 12, 16\r\n";
            // 
            // Chap11_Middle_Exam_TestCode_2_Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 118);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Chap11_Middle_Exam_TestCode_2_Review";
            this.Text = "Chap11_Middle_Exam_TestCode_2_Review";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}
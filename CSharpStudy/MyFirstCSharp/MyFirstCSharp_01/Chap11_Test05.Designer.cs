namespace MyFirstCSharp_01
{
    partial class Chap11_Test05
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
            this.lblArray = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "다음 문자열에 포함된 수를 정수배열로 만들고 낮은 수부터 중복되는 첫번째 값과 세번째 값을 메세지박스로 나타내세요.\r\n\r\n          * 라" +
    "벨에 입력된 문자열을 받아 정수 배열로 만드는 로직을 작성할 것";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblArray
            // 
            this.lblArray.AutoSize = true;
            this.lblArray.Location = new System.Drawing.Point(226, 69);
            this.lblArray.Name = "lblArray";
            this.lblArray.Size = new System.Drawing.Size(241, 12);
            this.lblArray.TabIndex = 1;
            this.lblArray.Text = "{ 1, 2, 13, 8, 15, 17, 23, 8, 15, 19, 3, 8, 13 }";
            this.lblArray.Click += new System.EventHandler(this.lblArray_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 107);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "중복 값 찾기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Chap11_Test05
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 161);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblArray);
            this.Controls.Add(this.label1);
            this.Name = "Chap11_Test05";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblArray;
        private System.Windows.Forms.Button button1;
    }
}
namespace MyFirstCSharp_01
{
    partial class Chap11_Test04_Review
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtRan3 = new System.Windows.Forms.TextBox();
            this.txtRan2 = new System.Windows.Forms.TextBox();
            this.txtRan1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(260, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 44);
            this.button2.TabIndex = 17;
            this.button2.Text = "결과";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRan3
            // 
            this.txtRan3.Location = new System.Drawing.Point(203, 71);
            this.txtRan3.Name = "txtRan3";
            this.txtRan3.Size = new System.Drawing.Size(51, 21);
            this.txtRan3.TabIndex = 16;
            // 
            // txtRan2
            // 
            this.txtRan2.Location = new System.Drawing.Point(146, 71);
            this.txtRan2.Name = "txtRan2";
            this.txtRan2.Size = new System.Drawing.Size(51, 21);
            this.txtRan2.TabIndex = 15;
            // 
            // txtRan1
            // 
            this.txtRan1.Location = new System.Drawing.Point(89, 71);
            this.txtRan1.Name = "txtRan1";
            this.txtRan1.Size = new System.Drawing.Size(51, 21);
            this.txtRan1.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 13;
            this.button1.Text = "난수 생성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 48);
            this.label1.TabIndex = 12;
            this.label1.Text = "버튼을 클릭하여 0부터 100까지의 임의의 수를 3번 받아 각각 텍스트박스에 표현하고 결과 버튼을 눌렀을 때\r\n3 수의 합이 100 미만일 경우 " +
    "최소값 * 최대값을 메세지로\r\n3 수의 합이 100 이상 200 미만일 때 최소값 + 최대값을 메세지로\r\n3 수의 합이 200 이상 200 일 " +
    "경우 \"세 수의 합이 200 이 넘습니다\"를 메세지로 표현하세요\r\n";
            // 
            // Chap11_Test04_Review
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 109);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtRan3);
            this.Controls.Add(this.txtRan2);
            this.Controls.Add(this.txtRan1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Chap11_Test04_Review";
            this.Text = "Chap11_Test04_Review";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtRan3;
        private System.Windows.Forms.TextBox txtRan2;
        private System.Windows.Forms.TextBox txtRan1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}
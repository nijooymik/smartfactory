namespace MyFirstCSharp_01
{
    partial class Chap14_Property
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
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOut = new System.Windows.Forms.Button();
            this.txtInQty = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(12, 43);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(125, 23);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "입고";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnOut
            // 
            this.btnOut.Location = new System.Drawing.Point(168, 43);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(125, 23);
            this.btnOut.TabIndex = 1;
            this.btnOut.Text = "책 판매";
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // txtInQty
            // 
            this.txtInQty.Location = new System.Drawing.Point(12, 12);
            this.txtInQty.Name = "txtInQty";
            this.txtInQty.Size = new System.Drawing.Size(100, 21);
            this.txtInQty.TabIndex = 2;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(256, 15);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(11, 12);
            this.lblStock.TabIndex = 3;
            this.lblStock.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "개          현재 재고량          개";
            // 
            // Chap14_Property
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 78);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInQty);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnIn);
            this.Name = "Chap14_Property";
            this.Text = "Chap14_Property";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.TextBox txtInQty;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label1;
    }
}
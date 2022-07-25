namespace MyFirstCSharp_01
{
    partial class Chap11_Middel_Test_T
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnShowTotalMargin = new System.Windows.Forms.Button();
            this.btnShowUnitMargin = new System.Windows.Forms.Button();
            this.rdoW_MMargin = new System.Windows.Forms.RadioButton();
            this.rdoMelonMargin = new System.Windows.Forms.RadioButton();
            this.rdoAppleMargin = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnInvoiceClear = new System.Windows.Forms.Button();
            this.btnFruitInvoice = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtW_MInvoice = new System.Windows.Forms.TextBox();
            this.txtMelonInvoice = new System.Windows.Forms.TextBox();
            this.txtAppleInvoice = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblManCash = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCustomerCash = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnOrderCancle = new System.Windows.Forms.Button();
            this.btnShowOrderPrice = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnW_MOrder = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblW_MLeftCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMelonOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMelonLeftCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAppleOrder = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAppleLeftCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.lblManCash);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(8, 201);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 342);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "관리자";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnShowTotalMargin);
            this.groupBox7.Controls.Add(this.btnShowUnitMargin);
            this.groupBox7.Controls.Add(this.rdoW_MMargin);
            this.groupBox7.Controls.Add(this.rdoMelonMargin);
            this.groupBox7.Controls.Add(this.rdoAppleMargin);
            this.groupBox7.Location = new System.Drawing.Point(239, 137);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(326, 185);
            this.groupBox7.TabIndex = 21;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "마진확인";
            // 
            // btnShowTotalMargin
            // 
            this.btnShowTotalMargin.Location = new System.Drawing.Point(18, 114);
            this.btnShowTotalMargin.Name = "btnShowTotalMargin";
            this.btnShowTotalMargin.Size = new System.Drawing.Size(239, 34);
            this.btnShowTotalMargin.TabIndex = 28;
            this.btnShowTotalMargin.Text = "총 마진 보기";
            this.btnShowTotalMargin.UseVisualStyleBackColor = true;
            this.btnShowTotalMargin.Click += new System.EventHandler(this.btnShowTotalMargin_Click);
            // 
            // btnShowUnitMargin
            // 
            this.btnShowUnitMargin.Location = new System.Drawing.Point(18, 62);
            this.btnShowUnitMargin.Name = "btnShowUnitMargin";
            this.btnShowUnitMargin.Size = new System.Drawing.Size(239, 34);
            this.btnShowUnitMargin.TabIndex = 27;
            this.btnShowUnitMargin.Text = "개별 마진보기";
            this.btnShowUnitMargin.UseVisualStyleBackColor = true;
            this.btnShowUnitMargin.Click += new System.EventHandler(this.btnShowUnitMargin_Click);
            // 
            // rdoW_MMargin
            // 
            this.rdoW_MMargin.AutoSize = true;
            this.rdoW_MMargin.Location = new System.Drawing.Point(210, 40);
            this.rdoW_MMargin.Name = "rdoW_MMargin";
            this.rdoW_MMargin.Size = new System.Drawing.Size(47, 16);
            this.rdoW_MMargin.TabIndex = 2;
            this.rdoW_MMargin.TabStop = true;
            this.rdoW_MMargin.Text = "수박";
            this.rdoW_MMargin.UseVisualStyleBackColor = true;
            // 
            // rdoMelonMargin
            // 
            this.rdoMelonMargin.AutoSize = true;
            this.rdoMelonMargin.Location = new System.Drawing.Point(112, 40);
            this.rdoMelonMargin.Name = "rdoMelonMargin";
            this.rdoMelonMargin.Size = new System.Drawing.Size(47, 16);
            this.rdoMelonMargin.TabIndex = 1;
            this.rdoMelonMargin.TabStop = true;
            this.rdoMelonMargin.Text = "참외";
            this.rdoMelonMargin.UseVisualStyleBackColor = true;
            // 
            // rdoAppleMargin
            // 
            this.rdoAppleMargin.AutoSize = true;
            this.rdoAppleMargin.Checked = true;
            this.rdoAppleMargin.Location = new System.Drawing.Point(18, 40);
            this.rdoAppleMargin.Name = "rdoAppleMargin";
            this.rdoAppleMargin.Size = new System.Drawing.Size(47, 16);
            this.rdoAppleMargin.TabIndex = 0;
            this.rdoAppleMargin.TabStop = true;
            this.rdoAppleMargin.Text = "사과";
            this.rdoAppleMargin.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnInvoiceClear);
            this.groupBox6.Controls.Add(this.btnFruitInvoice);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtW_MInvoice);
            this.groupBox6.Controls.Add(this.txtMelonInvoice);
            this.groupBox6.Controls.Add(this.txtAppleInvoice);
            this.groupBox6.Location = new System.Drawing.Point(239, 20);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(326, 111);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "발주";
            // 
            // btnInvoiceClear
            // 
            this.btnInvoiceClear.Location = new System.Drawing.Point(193, 61);
            this.btnInvoiceClear.Name = "btnInvoiceClear";
            this.btnInvoiceClear.Size = new System.Drawing.Size(116, 34);
            this.btnInvoiceClear.TabIndex = 26;
            this.btnInvoiceClear.Text = "전체 삭제";
            this.btnInvoiceClear.UseVisualStyleBackColor = true;
            this.btnInvoiceClear.Click += new System.EventHandler(this.btnInvoiceClear_Click);
            // 
            // btnFruitInvoice
            // 
            this.btnFruitInvoice.Location = new System.Drawing.Point(193, 17);
            this.btnFruitInvoice.Name = "btnFruitInvoice";
            this.btnFruitInvoice.Size = new System.Drawing.Size(116, 34);
            this.btnFruitInvoice.TabIndex = 25;
            this.btnFruitInvoice.Text = "발주 입고";
            this.btnFruitInvoice.UseVisualStyleBackColor = true;
            this.btnFruitInvoice.Click += new System.EventHandler(this.btnFruitInvoice_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(155, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 24;
            this.label19.Text = "개";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(155, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 23;
            this.label18.Text = "개";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(155, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 22;
            this.label17.Text = "개";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 83);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 21;
            this.label16.Text = "수박";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 20;
            this.label15.Text = "참외";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "사과";
            // 
            // txtW_MInvoice
            // 
            this.txtW_MInvoice.Location = new System.Drawing.Point(49, 74);
            this.txtW_MInvoice.Name = "txtW_MInvoice";
            this.txtW_MInvoice.Size = new System.Drawing.Size(100, 21);
            this.txtW_MInvoice.TabIndex = 2;
            // 
            // txtMelonInvoice
            // 
            this.txtMelonInvoice.Location = new System.Drawing.Point(49, 47);
            this.txtMelonInvoice.Name = "txtMelonInvoice";
            this.txtMelonInvoice.Size = new System.Drawing.Size(100, 21);
            this.txtMelonInvoice.TabIndex = 1;
            // 
            // txtAppleInvoice
            // 
            this.txtAppleInvoice.Location = new System.Drawing.Point(49, 20);
            this.txtAppleInvoice.Name = "txtAppleInvoice";
            this.txtAppleInvoice.Size = new System.Drawing.Size(100, 21);
            this.txtAppleInvoice.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(6, 59);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(194, 266);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "거래내역";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 246);
            this.textBox1.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "원";
            // 
            // lblManCash
            // 
            this.lblManCash.AutoSize = true;
            this.lblManCash.Location = new System.Drawing.Point(103, 32);
            this.lblManCash.Name = "lblManCash";
            this.lblManCash.Size = new System.Drawing.Size(41, 12);
            this.lblManCash.TabIndex = 17;
            this.lblManCash.Text = "100000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "거래 잔액";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 25;
            this.label3.Text = "원";
            // 
            // lblCustomerCash
            // 
            this.lblCustomerCash.AutoSize = true;
            this.lblCustomerCash.Location = new System.Drawing.Point(111, 173);
            this.lblCustomerCash.Name = "lblCustomerCash";
            this.lblCustomerCash.Size = new System.Drawing.Size(41, 12);
            this.lblCustomerCash.TabIndex = 24;
            this.lblCustomerCash.Text = "100000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "고객 잔액";
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(477, 134);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(112, 51);
            this.btnBuy.TabIndex = 22;
            this.btnBuy.Text = "결제 하기";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnOrderCancle
            // 
            this.btnOrderCancle.Location = new System.Drawing.Point(363, 134);
            this.btnOrderCancle.Name = "btnOrderCancle";
            this.btnOrderCancle.Size = new System.Drawing.Size(108, 51);
            this.btnOrderCancle.TabIndex = 21;
            this.btnOrderCancle.Text = "주문 취소하기";
            this.btnOrderCancle.UseVisualStyleBackColor = true;
            this.btnOrderCancle.Click += new System.EventHandler(this.btnOrderCancle_Click);
            // 
            // btnShowOrderPrice
            // 
            this.btnShowOrderPrice.Location = new System.Drawing.Point(241, 134);
            this.btnShowOrderPrice.Name = "btnShowOrderPrice";
            this.btnShowOrderPrice.Size = new System.Drawing.Size(116, 51);
            this.btnShowOrderPrice.TabIndex = 20;
            this.btnShowOrderPrice.Text = "총 결제금액 보기";
            this.btnShowOrderPrice.UseVisualStyleBackColor = true;
            this.btnShowOrderPrice.Click += new System.EventHandler(this.btnShowOrderPrice_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnW_MOrder);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblW_MLeftCount);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(402, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 116);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수박";
            // 
            // btnW_MOrder
            // 
            this.btnW_MOrder.Location = new System.Drawing.Point(8, 55);
            this.btnW_MOrder.Name = "btnW_MOrder";
            this.btnW_MOrder.Size = new System.Drawing.Size(179, 51);
            this.btnW_MOrder.TabIndex = 1;
            this.btnW_MOrder.Text = "수박 주문";
            this.btnW_MOrder.UseVisualStyleBackColor = true;
            this.btnW_MOrder.Click += new System.EventHandler(this.btnW_MOrder_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(154, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "개";
            // 
            // lblW_MLeftCount
            // 
            this.lblW_MLeftCount.AutoSize = true;
            this.lblW_MLeftCount.Location = new System.Drawing.Point(137, 29);
            this.lblW_MLeftCount.Name = "lblW_MLeftCount";
            this.lblW_MLeftCount.Size = new System.Drawing.Size(17, 12);
            this.lblW_MLeftCount.TabIndex = 2;
            this.lblW_MLeftCount.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(66, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "남은 수량";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "18000 원";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMelonOrder);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblMelonLeftCount);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(203, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 116);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "참외";
            // 
            // btnMelonOrder
            // 
            this.btnMelonOrder.Location = new System.Drawing.Point(8, 55);
            this.btnMelonOrder.Name = "btnMelonOrder";
            this.btnMelonOrder.Size = new System.Drawing.Size(179, 51);
            this.btnMelonOrder.TabIndex = 1;
            this.btnMelonOrder.Text = "참외 주문";
            this.btnMelonOrder.UseVisualStyleBackColor = true;
            this.btnMelonOrder.Click += new System.EventHandler(this.btnMelonOrder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "개";
            // 
            // lblMelonLeftCount
            // 
            this.lblMelonLeftCount.AutoSize = true;
            this.lblMelonLeftCount.Location = new System.Drawing.Point(137, 29);
            this.lblMelonLeftCount.Name = "lblMelonLeftCount";
            this.lblMelonLeftCount.Size = new System.Drawing.Size(17, 12);
            this.lblMelonLeftCount.TabIndex = 2;
            this.lblMelonLeftCount.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "남은 수량";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "2500 원";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAppleOrder);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblAppleLeftCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 116);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사과";
            // 
            // btnAppleOrder
            // 
            this.btnAppleOrder.Location = new System.Drawing.Point(8, 55);
            this.btnAppleOrder.Name = "btnAppleOrder";
            this.btnAppleOrder.Size = new System.Drawing.Size(179, 51);
            this.btnAppleOrder.TabIndex = 1;
            this.btnAppleOrder.Text = "사과 주문";
            this.btnAppleOrder.UseVisualStyleBackColor = true;
            this.btnAppleOrder.Click += new System.EventHandler(this.btnAppleOrder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "개";
            // 
            // lblAppleLeftCount
            // 
            this.lblAppleLeftCount.AutoSize = true;
            this.lblAppleLeftCount.Location = new System.Drawing.Point(137, 29);
            this.lblAppleLeftCount.Name = "lblAppleLeftCount";
            this.lblAppleLeftCount.Size = new System.Drawing.Size(17, 12);
            this.lblAppleLeftCount.TabIndex = 2;
            this.lblAppleLeftCount.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "남은 수량";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "2000 원";
            // 
            // Chap11_Middel_Test_T
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 550);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCustomerCash);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnOrderCancle);
            this.Controls.Add(this.btnShowOrderPrice);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Chap11_Middel_Test_T";
            this.Text = "Cahp11_Middel_Test";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnShowTotalMargin;
        private System.Windows.Forms.Button btnShowUnitMargin;
        private System.Windows.Forms.RadioButton rdoW_MMargin;
        private System.Windows.Forms.RadioButton rdoMelonMargin;
        private System.Windows.Forms.RadioButton rdoAppleMargin;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnInvoiceClear;
        private System.Windows.Forms.Button btnFruitInvoice;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtW_MInvoice;
        private System.Windows.Forms.TextBox txtMelonInvoice;
        private System.Windows.Forms.TextBox txtAppleInvoice;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblManCash;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCustomerCash;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnOrderCancle;
        private System.Windows.Forms.Button btnShowOrderPrice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnW_MOrder;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblW_MLeftCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMelonOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMelonLeftCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAppleOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAppleLeftCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp_01
{
    public partial class Chap11_Array_test : Form
    {
        public Chap11_Array_test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int[,] aArray = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            int iArrayRowCount = aArray.GetLength(0); //행
            int iArrayColumnCount = aArray.GetLength(1); //열
            
            string sArrayList = string.Empty;

            for (int x = (iArrayRowCount - 1); x >= 0; x--)
            {
                for (int y = 0; y < iArrayColumnCount; y++)
                {
                    sArrayList += $"{aArray[x, y]}, ";
                    
                }
                textBox1.Text += sArrayList + "\r\n";
                sArrayList = "";
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            int[,] aArray = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            int iArrayRowCount = aArray.GetLength(0); //행
            int iArrayColumnCount = aArray.GetLength(1); //열
            string sArrayList = string.Empty;

            for (int x = 0; x < iArrayRowCount; x++)
            {
                for (int y = 0; y < iArrayColumnCount; y++)
                {
                    sArrayList += $"{aArray[x, y]}, ";

                }
                textBox1.Text += sArrayList + "\r\n";
                sArrayList = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        } // 1, 11, 6, 20, 11, 8, 12, 6, 16, 13, 22

        private void button1_Click(object sender, EventArgs e)
        {
            string sTitle = label2.Text.Replace(" ", ""); // 1,11,6,20,11,8,12,6,16,13,22
            string sNum1 = "";
            string sNum2 = "";
            foreach (char ch in sTitle)
            {
                if (ch != ',')
                {
                    sNum1 += ch;
                }
                else
                {

                }
            }

        }
    }
}

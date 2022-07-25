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
    public partial class Chap11_Test05 : Form
    {
        int[] iArray = new int[100];

        public Chap11_Test05()
        {
            InitializeComponent();

            int m;
            string sValue = lblArray.Text; //"{ 1, 2, 13, 8, 15, 17, 23, 8, 15, 19, 3, 8, 13 }";
            char[] charArray = new char[] {'{', '}'};
            sValue = sValue.Trim(charArray);
            string[] sArray = sValue.Split(',');
            for (int i = 0; i < sArray.Length; i++)
            {
                sArray[i] = sArray[i].Trim();
                int.TryParse(sArray[i], out m);
                iArray[i] = m;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] sResult = new int[100];
            int n = 0;
            Array.Sort(iArray); // { 1, 2, 3, 8, 8, 8, 13, 13, 15, 15, 17, 19, 23 }
            for (int i = 0; i < iArray.Length; i++)
            {
                for (int j = i + 1; j < iArray.Length; j++)
                {
                    if (iArray[i] != iArray[j])
                    {
                        i++;
                    }
                    else
                    {
                        i++;
                        sResult[n] = iArray[i];
                        n++;
                        break;
                    }
                }
            }
            MessageBox.Show($"{sResult[0]}, {sResult[2]}");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblArray_Click(object sender, EventArgs e)
        {

        }
    }
}



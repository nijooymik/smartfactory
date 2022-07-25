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
    public partial class Chap11_Test04 : Form
    {
        public Chap11_Test04()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random Ran = new Random();
            textBox1.Text = Convert.ToString(Ran.Next(0, 100));
            textBox2.Text = Convert.ToString(Ran.Next(0, 100));
            textBox3.Text = Convert.ToString(Ran.Next(0, 100));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text);
            int j = Convert.ToInt32(textBox2.Text);
            int k = Convert.ToInt32(textBox3.Text);
            int Sum = i + j + k;
            int max = 0;
            int min = 0;
            if (i >= j)
            {
                max = i;
                min = j;
                if (j >= k) // i >= j >= k
                {
                    //max = i;
                    min = k;
                }
                else // k > j
                {
                    if (k >= i) // k >= i >= j
                    {
                        max = k;
                        //min = j;
                    }
                    //else // i > k > j
                    //{
                    //    max = i;
                    //    min = j;
                    //}
                }
            }
            else // j > i
            {
                max = j;
                min = i;
                if (i >= k) // j > i >= k
                {
                    //max = j;
                    min = k;
                }
                else // k > i
                {
                    if (k >= j) // k >= j > i
                    {
                        max = k;
                        //min = i;
                    }
                    //else // j > k > i
                    //{
                    //    max = j;
                    //    min = i;
                    //}
                }
            }

            if (Sum < 100)
            {
                MessageBox.Show($"{min} * {max} = {min * max}");
            }
            else if (Sum >= 100 && Sum < 200)
            {
                MessageBox.Show($"{min} + {max} = {min + max}");
            }
            else // Sum >= 200
            {
                MessageBox.Show("세 수의 합이 200 이 넘습니다.");
            }
        }
    }
}

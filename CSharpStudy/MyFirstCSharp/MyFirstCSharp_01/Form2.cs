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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int TotalPrice = 0;
            Random Ran = new Random();
            int Cash = Ran.Next(10000, 500000);
            int LeftCash = Cash;
            int Number = Ran.Next(1, 20);
            int Price = Ran.Next(1000, 3000);
            for (int i = 1; i <= Number; i++)
            {
                TotalPrice += Price * i;
            }
            LeftCash -= TotalPrice;
            if (LeftCash >= 0)
            {
                MessageBox.Show($"{Cash} 원이 있을 때 이용요금 {Price} 원인 놀이기구를 {Number} 번 타면 {LeftCash} 원이 남습니다.");
            }
            else
            {
                MessageBox.Show($"{Cash} 원이 있을 때 이용요금 {Price} 원인 놀이기구를 {Number} 번 타면 {-LeftCash} 원이 모자랍니다.");
            }
        }
    }
}

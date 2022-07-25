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
    public partial class Chap10_Loop02_While : Form
    {
        public Chap10_Loop02_While()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // While 특정 조건을 만족시킬 때까지 반복
            // 1부터 100까지의 합을 구하는 로직
            int iCount = 0; // 조건변수 1~100
            int iResult = 0;

            while (iCount <= 100) //조건이 참일 때에만 실행
            {
                ++iCount;
                if (iResult > 1000)
                {
                    break;
                }

                if (iResult > 50 && iResult < 100)
                {
                    continue;
                }
                iResult += iCount;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 무한루프를 사용하는 경우가 있다.

            // 무한루프를 구현하는 여러가지 방법 중 논리 연산자를 사용하는 방법이 많이 사용된다.

            // 변수 생성
            int iCount = 0;
            int iResult = 0;

            while(true)
            {
                ++iCount;
                iResult += iCount;
                if (iResult > 1000)
                {
                    continue;
                    break;
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1부터 100까지 합 Do While로 구해봅시다.

            int iCount = 0; // 반복 횟수
            int iResult = 0; // 누적 값

            do //일단 한 번은 실행
            {
                iResult += iCount;
                ++iCount;
            }
            while (iCount < 101); //조건에 따라 종료
        }
    }
}

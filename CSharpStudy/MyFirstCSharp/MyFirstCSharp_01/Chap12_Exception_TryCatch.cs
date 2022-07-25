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
    public partial class Chap12_Exception_TryCatch : Form
    {
        int[] iValueArray = new int[] { 1, 2, 3 };

        // 예외처리 Exception
        // 프로그램 구동 시 발생할 수 있는 오류를 검출하여
        // 오류로 인해 프로그램이 비정상적인 동작 또는 종료되지 않도록 처리하는 방식
        // try, Catch, Finally, Throw

        // 개발자가 예상하지 못한 벨리데이션 체크 부분을 로직상 처리하여
        // 에러 발생 원인을 유연하게 파악할 수 있는 편의를 제공

        // Java, JavaScript, Python (Try, Except) 프로그래밍 언어에서 모두 사용된다.
        public Chap12_Exception_TryCatch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 예외상황 발생시키기
            for (int i = 0; i < 5; i++)
            {
                MessageBox.Show(Convert.ToString(iValueArray[i]));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 예외 처리 Try, Catch (Try, Catch는 반드시 쌍으로 존재해야 한다.)
            
            try // try{} 프로그램 로직을 처리하는 부분
            {
                // iValueArray 배열에는 3개의 데이터가 있으므로 Index가 3 이상이 되면 오류가 발생한다.
                for (int i = 0; i < 5; i++)
                {
                    MessageBox.Show(Convert.ToString(iValueArray[i]));
                }    
            }
            catch // Catch{} 오류 내역이 검출된 후 처리하는 부분
            {
                MessageBox.Show("동작 중 오류가 발생하였습니다.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bool Check = GetError();
                if (!Check) return;
                    
                MessageBox.Show("정상적으로 완료되었습니다.");
            }
            catch
            {
                MessageBox.Show("동작 중 오류가 발생하였습니다. button3_Click");
            }
        }

        private bool GetError()
        {
            try // try{} 프로그램 로직을 처리하는 부분
            {
                // iValueArray 배열에는 3개의 데이터가 있으므로 Index가 3 이상이 되면 오류가 발생한다.
                for (int i = 0; i < 5; i++)
                {
                    MessageBox.Show(Convert.ToString(iValueArray[i]));
                }
                return true;
            }
            catch // Catch{} 오류 내역이 검출된 후 처리하는 부분
            {
                MessageBox.Show("동작 중 오류가 발생하였습니다. GetError");
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Exception
            // 시스템 구동 시 발생할 수 있는 오류의 원인을 검출하고 메세지로 내역을 반환하는 클래스
            // 프로그램 개발자 또는 사용자에게 오류내역을 표현하도록 하여 어떠한 오류인지 확인할 수 있다.
            // 에러가 검출되는 상황에 통상적으로 Exception 클래스(모든 예외 상황을 검출)를 사용하며
            // 자세한 오류 내역을 검출하고자 할 때는 별도의 Exception 클래스를 혼합하여 사용.

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    MessageBox.Show(Convert.ToString(iValueArray[i]));
                }
            }
            catch (DivideByZeroException dEx)
            {
                MessageBox.Show(dEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("배열을 표현하는 중 오류가 발생");
                MessageBox.Show(ex.Message); //정확히 어떤 오류인지 표현
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Try Catch 다음에 위치하며 오류 발생 여부를 떠나 무조건 실행되는 구문
                // ex) 데이터베이스 작업 후 데이터베이스에 접속을 종료하는 구문
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 예외 던지기 Throw
            // 예외 상황을 발생시켜 Catch로 처리하게끔 한다.

            // 0~20까지 임의의 수를 생성하여 10 이하의 값이 생성 시 Catch로 Throw
            // 아닐 경우 생성된 수를 메세지로 표현하는 구문

            int iRandomInt = 0;
            try
            {
                iRandomInt = RandomValueMaker();
                if (iRandomInt < 10)
                {
                    throw new Exception($"10 이하의 값을 생성하였습니다. {iRandomInt}");
                }
                MessageBox.Show($"10 이상의 값 {iRandomInt}이 생성되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int RandomValueMaker()
        {
            // 랜덤 난수 생성 클래스
            Random Ran = new Random();
            return Ran.Next(0, 20);
        }
    }
}

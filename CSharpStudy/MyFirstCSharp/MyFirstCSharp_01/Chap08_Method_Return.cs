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
    public partial class Chap08_Method_Return : Form
    {
        // 클래스 내에 생성할 수 있는 요소는 필드(변수), 메서드
        string sValue = string.Empty; // ""

        public Chap08_Method_Return()
        {
            InitializeComponent();
        }

        #region < 기본 메서드 호출 >
        private void button1_Click(object sender, EventArgs e)
        {
            // 기본 메서드 호출
            ShowMessage();
        }

        private void ShowMessage()
        {
            MessageBox.Show("안녕하세요");
            textBox1.Text = "안녕하세요";
            label1.Text   = "안녕하세요";
        }
        #endregion

        #region < 인수와 인자 값을 통한 함수의 호출. >
        private void button2_Click(object sender, EventArgs e)
        {
            // 인수와 인자 값을 주고 받는 함수 호출.

            // 주는 값 : 인수, 아규먼트
            // 받는 값 : 인자, 매개변수, 파라매터 // 수주받자
            //ShowMessage2("안녕하세요"); // "안녕하세요" => 인수

            string sMessage = "안녕하세요";
            ShowMessage2(sMessage);
        }

        private void ShowMessage2(string Message) // 인자 값
        {
            MessageBox.Show(Message);
            textBox1.Text = Message;
            label1.Text   = Message;

            Message = "반갑습니다.";
        } // 원하는 상황에 맞게끔 요소를 던져줌
        #endregion

        #region < 테스트 >
        private void button3_Click(object sender, EventArgs e)
        {
            //텍스트박스=안녕하세요 라벨=반갑습니다 메시지박스=화이팅
            ShowMessage3();
        }

        private void ShowMessage3()
        {
            textBox1.Text = "안녕하세요";
            label1.Text = "반갑습니다";
            MessageBox.Show("화이팅");
        }
        #endregion

        #region < 아무 값을 반환하지 않는 리턴. >
        private void button4_Click(object sender, EventArgs e)
        {
            // Return : 메서드에서 처리한 어떠한 결과를 호출한 부분으로 넘겨주는 기능
            // Void 함수는 Return 에게 어떠한 결과값을 기대하지 않으며
            // Return 또한 결과값을 넘겨줄 의무가 없다.
        }
        
        void ShowMessage4() // private 가 없으면 숨어 있는 것
        {
            MessageBox.Show("안녕하세요");
            textBox1.Text = "안녕하세요";
            return; // 함수의 종료처럼 보이지만 반환할 값이 없는 상태로 함수를 호출한 곳으로 돌아간다.
            //label1.Text = "안녕하세요";
        }
        #endregion

        #region < string 값을 반환하는 메서드 리턴 >
        private void button5_Click(object sender, EventArgs e)
        {
            string sMessage = ShowMessage5("안녕하세요"); // string 값을 인자로 받음
            MessageBox.Show(sMessage);
        }

        private string ShowMessage5(string Message)
        {
            MessageBox.Show(Message);
            return "성공";
        }
        #endregion

        #region < int 값을 반환하는 메서드 리턴 >
        private void button6_Click(object sender, EventArgs e)
        {
            // 메세지가 보이는 순서
            // B -> A -> 30 -> C

            int iResult; // 결과 값을 받을 변수.
            MessageBox.Show("B");
            iResult = IntSum(10, 20);
            MessageBox.Show(Convert.ToString(iResult));
            MessageBox.Show("C");
        }

        private int IntSum(int iValue1, int iValue2)
        {
            MessageBox.Show("A");
            // 인자 값을 더하여 결과를 반환하는 메서드 리턴
            return iValue1 + iValue2;   
        }
        #endregion

        #region < 인자가 기본값을 가지는 함수의 결과 값을 반환하는 메서드 리턴 (선택적 인수) >
        private void button7_Click(object sender, EventArgs e)
        {
            int iResult;
            iResult = IntSum2(10); 
            // 인수를 인자의 개수에 맞게 보내줄지 말지는 내가 선택하겠다.
            // 인자는 기본값을 가지고 내가 보내주지 않을 때는 그 기본값으로 메서드를 시행하되
            // 값을 보낼 적에는 보낸 값으로 로직을 처리하라.
            MessageBox.Show(Convert.ToString(iResult));
        }

        private int IntSum2(int iValue1, int iValue2 = 20)
        {
            return iValue1 + iValue2;
        }
        #endregion

        #region < 인수를 배열로 전달하는 경우. >
        private void button8_Click(object sender, EventArgs e)
        {
            // 배열 인수 생성
            string[] sArrayString = { "안녕하세요", "반갑습니다", "화이팅" };
            //                 Index :     0            1          2   
            // sArrayString[0] : "안녕하세요"
            // sArrayString[1] : "반갑습니다"
            // sArrayString[2] : "화이팅"

            // string[] sArraystring2 = new string[1000]; 
            // 배열 데이터타입의 변수를 선언하고 메모리에 할당
            showMessage6(sArrayString);
        }
        private void showMessage6(string[] sValue, string a = "", int vb = 2)
        {
            MessageBox.Show(sValue[0]);
            textBox1.Text = sValue[1];
            label1.Text   = sValue[2];
            //MessagBox.Show(sValue[3]);
            //MessagBox.Show(sValue[4]);
            //MessagBox.Show(sValue[5]);
        }
        #endregion

        #region < 배열을 리턴하는 경우 >
        private void button9_Click(object sender, EventArgs e)
        {
            // 1. 배열 인자 생성
            int[] iArrayInt = { 10, 20 };
            iArrayInt = IntSum3(iArrayInt);

            MessageBox.Show(Convert.ToString(iArrayInt[0]));
            MessageBox.Show(Convert.ToString(iArrayInt[1]));
        }

        // 2. 배열 인수를 일정한 값과 합하는 메서드 생성.
        private int[] IntSum3(int[] iArrayInt)
        {
            int[] iSumInt = { 5, 10 };
            iSumInt[0] = iArrayInt[0] + iSumInt[0]; // 10+5=15
            iSumInt[1] = iArrayInt[1] + iSumInt[1]; // 20+10=30
            return iSumInt;
        }
        #endregion

        #region < 다른 클래스의 함수 호출 >
        private void button10_Click(object sender, EventArgs e)
        {
            NewClass NC = new NewClass();
            NC.intSum(40);
           // MessageBox.Show(Convert.ToString(NC.intSum(40)));
        }
        #endregion

        #region < Ref 인자 변환 Read/Write >
        private void button11_Click(object sender, EventArgs e)
        {
            // Ref 레퍼런스
            // 참조형 파라매터(인자) 전달 방식으로. 값을 복사하지 않고 원본 값을 서로 공유함

            int a = 1;
            int b = 0;

            RefMethod(a, ref b);    
            
            MessageBox.Show("a 의 값은? " + Convert.ToString(a)); //1
            MessageBox.Show("a 의 값은? " + Convert.ToString(b)); //1 // 변경된 b
        }

        private void RefMethod(int ia, ref int ib) //1, 0
        {
            MessageBox.Show("Ref 인자 b 의 값은? " + Convert.ToString(ib)); //0
            ib = ia; // b를 변경 가능
            MessageBox.Show("Ref 인자 b 의 값은? " + Convert.ToString(ib)); //1
        }
        #endregion

        #region < Out 인자 반환 값을 할당하지 않음. Write >
        private void button12_Click(object sender, EventArgs e)
        {
            // Out: 참조형 데이터 전달 방식.
            // 인수를 초기화 할 필요가 없고 인수의 데이터는 모두 무시
            // 인자(파라매터)를 사용하기 전에 초기화 또는 값을 할당해야 한다.
            int a = 1;
            int b;

            OutMethod(a, out b);
        }

        private void OutMethod(int ia, out int ib)
        {
            ib = ia; // 변경 안하면 오류
            MessageBox.Show(Convert.ToString(ib));
        }
        #endregion

        #region < In 형식의 인자 결정. ReadOnly) >
        private void button13_Click(object sender, EventArgs e)
        {
            // IN 인자 타입 : 읽기 전용 속성으로 변경, 수정을 할 수 없다.

            string sInValue = "인수 변수 데이터";
            int iInValue = 3;

            int iResult = 0;
            iResult =INMethod(sInValue, iInValue);
            MessageBox.Show(Convert.ToString(iResult));
        }

        private int INMethod(string sValue, in int iValue) // in 고정 // 메모리 절약을 위함
        {
            //iValue = 30; // 할당 불가 // 불변
            return iValue * 20;
        }
        #endregion

        #region < 메서드 OverLoading >
        private void button14_Click(object sender, EventArgs e)
        {
            // OverLoading
            // 인자를 메세지 박스로 표현하는 일이 해야 하는 메서드가 있다고 할 때
            // 여러 가지 메서드 이름으로 인자 데이터 변수 및 이름을 달리 할 수 있지만
            // 같은 메서드 이름으로 데이터 변수(인자)를 다르게 하여
            // 개발자가 쉽게 사용할 수 있도록 할 수 있다.

            ShowMessage("안녕하세요", "반갑습니다."); // 조건이 다 다른 동명 메서드 3개
            ShowMessage(1, 2);
        }

        private void ShowMessage(string sValue1, string sValue2)
        {
            MessageBox.Show(sValue1 + sValue2);
        }
        private void ShowMessage(int iValue1, int iValue2)       
        {
            MessageBox.Show(Convert.ToString(iValue1) + Convert.ToString(iValue2));
        }
        #endregion

        #region < 일반화 메서드 (Generic Method) >
        private void button15_Click(object sender, EventArgs e)
        {
            // 같은 기능을 하는 메서드가 인자의 데이터 타입만 바뀌는 경우와
            // 인자의 데이터 타입이 같은 메서드를 데이터 타입에 따라 오버로딩할 경우에는
            // 메서드 일반화를 통하여 여러 데이터 타입의 인자를 처리하는 메서드를
            // 하나만 만들어 관리할 수 있다.

            GenericMethod<string>("안녕하세요", "반갑습니다");
            GenericMethod<int>(1, 2);
        }

        void GenericMethod<MyDataType>(MyDataType gValue1, MyDataType gValue2) // 꺽쇠로 공통적인 데이터 타입을 다룬다.
        {
            MessageBox.Show(Convert.ToString(gValue1), Convert.ToString(gValue2));

        }
        #endregion

        #region < Out 을 이용한 TryParce 메서드 만들어 보기. >
        private void button16_Click(object sender, EventArgs e)
        {
            // TryParce()
            string sValue = "1000";

            int iResult;
            //bool bSuccess = int.TryParse(sValue, out iResult); // 문자를 숫자로 변형 //TryParce의 용법
            bool bSuccess = int_.TryParce_(sValue, out iResult);
            MessageBox.Show(Convert.ToString(sValue), Convert.ToString(iResult));
        }
        #endregion

    } // 클래스

    class NewClass
    {
        public int intSum(int iValue, int iValue2 = 20) // private면 타 클래스에서 사용 불가
        {
            int iResult = iValue + iValue2;
            return iResult; // return iValue + iValue2

        }
    }

    class int_
    {
        public static bool TryParce_(string sValue, out int iResult) //
        {
            iResult = 0;

            try
            {
                iResult = Convert.ToInt32(sValue);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
} // 솔루션 네임스페이스

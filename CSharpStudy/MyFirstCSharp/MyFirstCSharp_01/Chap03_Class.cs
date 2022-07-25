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
    public partial class Chap03_Class : Form
    { // class 범위 시작
        // 클래스를 만드는데 CHP_02 라는 이름으로 만들거고(할당)
        // 클래스를 생성하는 생성 조건(파라미터)이 없으니 아무조건 없이 만들어 달라.
        Chap02_DataType CHP_02 = new Chap02_DataType(); //객체 초기화, class 인스턴트화 --> 객체가 클래스 범위에 생성됐기에 클래스 범위 내에서 쓸 수 있다.
        
        public Chap03_Class() // Chap03_Class 클래스의 생성자
        { // 생성자 범위 시작
            InitializeComponent();
            // CHP_02 객체의 ia 변수에 10
            Chap02_DataType CHP_02 = new Chap02_DataType(); // 여기서 선언한 CHP_02는 생성자 범위 안에서만 사용됨
            CHP_02.sMessage = "반갑습니다";
            textBox1.Text = CHP_02.sMessage;
        } // 생성자 범위 끝

        private void button1_Click(object sender, EventArgs e)
        { // button1_Click 메소드 범위 시작
            Chap02_DataType CHP_02 = new Chap02_DataType(); // 여기서 선언한 CHP_02는 button1_Click 메소드 범위 안에서만 사용됨
            textBox1.Text = CHP_02.sMessage;
        } // button1_Click 메소드 범위 끝
    } // class 범위 끝
}

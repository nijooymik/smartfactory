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
    // 네임 스페이스 아래에 두어 모든 클래스에서 참조할 수 있도록 한다.
    public enum ItemType
    {
        HAWA
      , FERT = 11
      , HALB
      , ROH
    }
    public partial class Chap13_Enum : Form
    {
        public Chap13_Enum()
        {
            InitializeComponent();
            MessageBox.Show(Convert.ToString(HAWA)); // 상수 HAWA를 호출

            MessageBox.Show(Convert.ToString(ItemType.HAWA));
        }

        // 1
        // 상수
        // 상수를 아래와 같이 정의하여 사용할 경우
        // 상수의 이름을 보고 변수 내용을 파악할 수 있지만
        // 어떤 유형의 상수인지 쉽게 알아보기 힘든 경우가 있다.
        const int HAWA = 0; // 상품
        const int FERT = 1; // 제품
        const int HALB = 2; // 반제품
        const int ROH  = 3; // 원자재

        // 2
        // Enum
        // Enum을 이용하여 그룹화하면 어떤 종류의 상수 그룹인지 알 수 있어 개발을 용이하게 한다.
        public enum ItemType
        {
            HAWA
            ,FERT = 11
            ,HALB // 12
            ,ROH  // 13
            // Enum 상수 열거형으로 정수 값을 가지며 값이 대입되지 않았을 경우, 0부터 순차적으로 값이 된다.
            // 특정 값이 대입된 상수가 있을 경우, 다음 상수는 +1 된 값을 자동으로 가진다.
        }
    }
}

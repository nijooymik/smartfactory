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
    // 1. 설명
    // 프로퍼티 (Property)
    /* 클래스 내부 변수의 값을 읽거나 쓸 때 사용하는 방법
     * Public으로 선언한 변수의 변질을 막고, Public을 많이 사용하지 않도록 권장
     * 
     * 캡슐화
     * 정보 은닉을 위해 클래스에서 선언된 변수가 외부에서 접근이 안되도록
     * Public이 아닌 Private로 선언하여 접근을 불가능하게 만드는 객체지향 언어에서 지향하는 목표 중 하나
     * */
    public partial class Chap14_Property : Form
    {
        // 6. Chap14_Property 클래스에서 사용할 수 있는 BookStore 클래스 생성
        private BookStore B_S = new BookStore();

        public Chap14_Property()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // 7. 책 입고
            int iInBookCount = Convert.ToInt32(txtInQty.Text);
            B_S.BookCount2 += iInBookCount; // 입고되는 책의 수량을 BookStore 클래스의 iBookCount에 누적
            txtInQty.Text = "";
            lblStock.Text = Convert.ToString(B_S.BookCount); // 현재 총 재고량을 라벨에 표시
            MessageBox.Show($"{iInBookCount}권의 책이 입고되었습니다.");
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            //// 8. 책 판매 현황 및 데이터 변경
            //// -- B_S.BookCount;

            //// 9. 책의 재고는 -가 될 수 없다.
            ////    만약 iBookCount를 Public으로 선언하거나 BookCount 프로퍼티를 Get/Set 상태로 그대로 둔다면
            ////    - 재고로 남게 된다
            //if (B_S.BookCount < 0)
            //{
            //    B_S.BookCount = 0;
            //    MessageBox.Show("책의 수량은 0보다 작을 수 없습니다.");
            //}
            //lblStock.Text = Convert.ToString(B_S.BookCount);

            // 12.
            --B_S.BookCount2;
            lblStock.Text = Convert.ToString(B_S.BookCount2);

            // 10. 다른 사람이 클래스의 BookCount 또는 Public으로 선언된 iBookCount에 접근할 때
            //     iBookcount가 - 값을 가질 수 있다.
            //     따라서 공통으로 사용하는 클래스의 필드일 경우 Public 방식보다는
            //     Get/Set을 통한 (프로퍼티) 값의 변질에 제한을 둘 수 있다.
        }
    }

    // 2. 서점이라는 클래스가 있다고 할 때
    class BookStore
    {
        private int iBookCount; // 3. 외부에 Open하지 않을 iBookCount 변수
        public int BookCount;   // 4. 외부에서 접근할 공용 프로퍼티 BookCount로 접근할 수 있다.
        {
            get { return iBookCount; }  // BookCount를 외부에서 호출할 경우 iBookCount 값을 반환
            set { iBookCount = value; } // BookCount에 외부에서 값을 대입할 경우 iBookCount에 값을 등록
        }
        // 11. 데이터의 변질을 막기 위한 공용 변수 iBookCount2 프로퍼티
        public int BookCount2
        {
            get { return iBookCount; }
            set
            {
                if (value < 0) // 지금 값이 0보다 이하일 경우
                {
                    MessageBox.Show("책의 수량은 0 이하일 수 없습니다.");
                }
                else iBookCount = value; // 그 외일 경우
            }
        }
        // 프로퍼티의 간단한 생성 방법
        public int BookCount3
        {
            // private int BookCount3를 자동으로 생성한다.
            get; set;
        }
        // 읽기 전용 멤버 변수
        public int BookCount4
        {
            get;
        }
        // 쓰기 전용 멤버 변수
        public int BookCount5
        {
            // set;
            set
            {
                BookCount5 = value;
            }
        }
        // 5. 정보 은닉을 위해 변수(iBookCount) 자체는 Private로 선언을 했지만, 
        // Get과 Set으로 접근을 가능하게 하니 Public과 별 차이 없어보인다.
        // 프로퍼티
        // 정보의 은닉성 (캡슐화)를 위하여 클래스의 필드는 Private로 선언해 둘 필요가 있으며
        // 공통으로 사용하는 변수일 경우 데이터의 변질을 막을 수 있어
        // 은닉성과 데이터 변질에 대한 벨리데이션 체크를 동시에 할 수 있다.
    }
}

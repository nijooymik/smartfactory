using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace MyFirstCSharp_01
{
    public partial class Chap11_Array : Form
    {
        // 배열 : 같은 데이터 타입의 여러 데이터가 있을 경우 하나의 배열 변수 이름으로 정의하는 데이터 형식
        public Chap11_Array()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 배열을 초기화
            int[] iaValue = new int[10];
            int[] iaValue1 = new int[5] { 10, 2, 30, 3, 40 }; //[5]개가 들어가야함
            int[] iaValue2 = new int[] { 10, 20, 30, 40 }; //미지정으로 몇 개가 와도 상관없다
            int[] iaValue3 = { 1, 2 };

            string[] sValue1 = "ABCD/EFG".Split('/');
            int[] iValue4 = new int[iaValue.Length];

            // 2. 배열에서 사용할 수 있는 주요 기능
            // 배열 정렬
            Array.Sort(iaValue1);
            foreach (int ivalue in iaValue1)
            {
                // MessageBox.Show(Convert.ToString(ivalue)); //2, 3, 10, 30, 40
            }

            // 특정 데이터의 index 를 반환하는 기능
            int iIndex = Array.IndexOf(iaValue1, 30);
            // MessageBox.Show($"30 의 Index 는 : {iIndex}");

            // 배열을 복사하는 방법.
            //int[] iaValue4 = iaValue3; // 참조 (주소값만) 복사해서 공유하는 형태
            //MessageBox.Show($"iaValue4 의 첫번째 값은 : {iaValue4[0]} 입니다.");
            //iaValue3[0] = 3;
            //MessageBox.Show($"iaValue4 의 첫번째 값은 : {iaValue4[0]} 입니다.");

            // 배열의 크기를 조정한다. <Array.Resize>
            Array.Resize<int>(ref iaValue1, 3);
            //foreach (int ivalue in iaValue1)
            //{
            //    MessageBox.Show(Convert.ToString(ivalue));
            //}

            // 배열을 전체적으로 초기화 <Array.Clear>
            Array.Clear(iaValue1, 0, iaValue1.Length);
            foreach (int ivalue in iaValue1)
            {
                MessageBox.Show(Convert.ToString(ivalue));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 2차원 배열의 초기화하는 방법.
            int[,] iaArray = new int[2, 3];
            iaArray[0, 0] = 1;
            iaArray[0, 1] = 2;
            iaArray[0, 2] = 3;
            iaArray[1, 0] = 4;
            iaArray[1, 1] = 5;
            iaArray[1, 2] = 6;

            int[,] aArray2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            // 행의 수 구하는 기능
            int iArrayRowCount = aArray2.GetLength(0); //0 고정

            // 열의 수 구하는 기능
            int iArrayColumnCount = aArray2.GetLength(1); //1 고정

            // 1. 위의 배열을 텍스트 박스에 표현하세요.
            textBox1.Text = "---------For---------\r\n";
            string sArrayList = string.Empty; //문자열은 null을 허용해서 string sArrayList;여도 동작
            for (int x = 0; x < iArrayRowCount; x++)
            {
                for (int y = 0; y < iArrayColumnCount; y++)
                {
                    sArrayList += $"aArray2 의 [{x}, {y}] 의 값은 : {aArray2[x, y]}     "; //보간은 형변환 자동
                }
                textBox1.Text += sArrayList + "\r\n"; //누적된 값을 텍스트에 담음
                sArrayList = ""; //이전 행의 누적된 결과를 지우고 새 행 시작
            }

            // 2. Foreach
            textBox1.Text += "---------Foreach---------\r\n";
            //textBox1.Text = textBox1.Text + "----------For----------\r\n";
            int iColumnCount = 0;
            foreach(int iResult in aArray2)
            {
                sArrayList += $"{iResult}, ";
                if (++iColumnCount == iArrayColumnCount)
                {
                    sArrayList += "\r\n";
                    iColumnCount = 0;
                }
            }
            textBox1.Text += sArrayList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 가변 배열 (배열의 배열) Jagged_array (배열을 담는 배열)
            int[][] iJa = new int[3][];
            iJa[0] = new int[3] { 1, 2, 3 };
            iJa[1] = new int[] { 1, 2, 3, 12, 224 };
            iJa[2] = new int[] { 1, 2, 3 };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Queue
            // 선입 선출 방식 자료 구조
            // 데이터나 작업을 차례대로 입력된 순서로 하나씩 처리

            Queue<int> Que = new Queue<int>();
            Que.Enqueue(1); //데이터 넣기.초기화
            Que.Enqueue(2);
            Que.Enqueue(3);
            Que.Enqueue(4);

            while (Que.Count > 0)
            {
                textBox1.Text += Convert.ToString(Que.Dequeue()); //데이터 받아오기
            }
            // Dequeue 후에는 데이터가 삭제된다. 
            while (Que.Count > 0)
            {
                textBox1.Text += Convert.ToString(Que.Dequeue());
            }
            // Queue의 초기화
            int[] iValue = new int[2] { 1, 2 };
            Queue<int> Que2 = new Queue<int>(iValue);
            Queue<int> Que3 = new Queue<int>(new int[4] { 1, 2, 3, 4 });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Stack
            // 선입 후출 (후입 선출) 방식 자료 구조

            // Stack 선언 데이터 초기화
            Stack<int> Stack = new Stack<int>();
            Stack.Push(1);
            Stack.Push(2);
            Stack.Push(3);

            while (Stack.Count > 0)
            {
                textBox1.Text += Convert.ToString(Stack.Pop()) + " , ";
            }

            // Stack 배열로 초기화
            Stack<int> stack1 = new Stack<int>(new int[2] { 1, 2 });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // ArrayList
            // 배열과 비슷한 성격을 가지고 있으나
            // 생성 시 용량을 미리 지정해두지 않아도 된다.
            // 모든 값을 참조 형식으로 처리하기 때문에 성능 저하의 원인이 될 수도 있다.
            // using System.Collections;

            ArrayList list = new ArrayList();

            // 1. ArrayList 에 데이터를 추가
            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            // 2번째 위치에 있는 내용을 삭제
            list.Remove(2);

            // 2번 인덱스에 10 데이터를 넣어라.
            list.Insert(2, 10);

            // 배열을 입력하여 데이터 초기화
            int[] iArray = new int[2] { 1, 2 };
            ArrayList AL2 = new ArrayList(iArray);

            string sMessage = string.Empty;
            foreach (object obj in list)
            {
                sMessage += Convert.ToString(obj) + " , ";
            }
            textBox1.Text = sMessage;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // HashTable
            // 키와 값으로 이루어진 데이터를 다룰 때 사용
            // Arrlist 는 순서대로 값을 Indexing 하지만
            // hashTable 은 지정한 키를 통하여 값을 찾아내서 속도가 빠른 장점이 있다.
            // 데이터 형식에 구애없이 키와 값을 지정할 수 있다.

            // 모든 데이터 타입을 Object 로 되어 사용시 데이터 형변환이 필요하다.

            Hashtable hs = new Hashtable();
            hs[1] = "ONE";
            hs["2"] = 2;
            hs[true] = 2;
            hs[1.23] = "1.23";

            // 값을 표현하기 위한 형변환
            MessageBox.Show(Convert.ToString(hs[1.23]));
            int iValue = Convert.ToInt32(hs["2"]);

            // HashTable 의 초기화
            // 1. 딕셔너리 방식 (사전식) //더 많이 사용
            Hashtable Ht2 = new Hashtable()
            {
                ["하나"] = 1, //[키] = 데이터
                ["둘"] = "TWO",
                ["둘"] = "2", //가능
                [2] = 1.3
            };

            // 2. 컬렉션 초기자를 통한 초기화
            Hashtable Ht4 = new Hashtable()
            {
                { "하나", 1 },
                { "둘", "TWO" },
                //{ "둘", 2 }, 불가
                { 2, 1.3 }
            };

            // HashTable의 복사
            // 참조 복사
            Hashtable Ht5 = Ht4;

            // 값형 복사
            Hashtable Ht6 = new Hashtable(Ht4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Dictionary 
            // HashTable 과 유사하나 중복된 키를 사용할 수 없다.
            // 데이터 타입을 명시하여 사용하므로 형변환을 하지 않아도 되며
            // 타입이 다를 경우 에러를 표현하여 개발을 용히하게 한다.

            // 고정적으로 하나의 데이터 타입을 관리할 경우는 딕셔너리를 사용하며
            // Value 의 일정한 데이터 형식에 구애없이 사용할 경우 해시 테이블을 사용한다.

            // 1. Dictionary 의 생성
            // 키와 값의 데이터 타입이 구체적으로 명시되어야 한다.
            Dictionary<string, int> MyTable = new Dictionary<string, int>(); //<키, 값>
            MyTable.Add("A", 1);
            MyTable.Add("B", 2);
            MyTable.Add("C", 3);
            MyTable["D"] = 4;
            //MyTable[5] = "ABC"; 키 값 데이터 타입 오류
            
            // 1. 딕셔너리 복사
            // 값형 복사
            Dictionary<string, int> MyTable2 = new Dictionary<string, int>(MyTable);
            MyTable2["A"] = 10;
            MessageBox.Show(Convert.ToString(MyTable2["A"]));

            // 참조형 복사
            Dictionary<string, int> MyTable3 = MyTable;
            MyTable3["A"] = 10;
            MessageBox.Show(Convert.ToString(MyTable["A"]));

            // key 의 사용여부 확인
            if (MyTable.ContainsKey("A")) //bool
            {
                MessageBox.Show("A 키가 있습니다.");
            }
            
            // Value 의 사용여부 확인
            if (MyTable.ContainsValue(3))
            {
                MessageBox.Show("3 번 값을 가지고 있는 데이터가 있습니다.");
            }

            // 키와 값의 삭제
            MyTable.Remove("A");
            if (!MyTable.ContainsKey("A"))
            {
                MessageBox.Show("A 키를 가지고 있지 않습니다.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly;

namespace Assembly
{
    public class Commons
    {
        // 공통 변수 설정
        //public static string sLogInUserID = string.Empty; // 사용자 ID
        //public static string sLogInUserName = string.Empty; // 사용자 명

        // 사용자 정보 프로퍼티 생성
        public static string sLogInUserID // 사용자 ID
        { get; set; }

        public static string sLogInUserName // 사용자 명
        { get; set; }

        public static string sConnectInfo = string.Empty;

        public static string LogInFlag;
    }
}

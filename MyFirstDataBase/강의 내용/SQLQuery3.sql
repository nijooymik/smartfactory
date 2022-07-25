/*
  - SELECT
    . 데이터베이스 내의 테이블에서 원하는 정보를 추출하는 명령
	. 가장 기본적인 SQL 구문이지만 데이터베이스 운영 시 중요도가 높은 문법이므로 잘 숙지할 것

  - SELECT 구문의 기본 형식
    . SELECT [열이름]
	    FROM [테이블 이름]
	   WHERE [조건] -- 같이 사용할 수도 있고 없이 사용할 수도 있다.
*/

/*********************************************************************
 1. 기본적인 SELECT 형식 */
 
 -- TB_ItemMaster 테이블에 있는 모든 컬럼의 데이터를 검색 표현
 SELECT *
   FROM TB_ItemMaster;
 -- * : 아스테리크 (테이블의 모든 내용을 검색)

/*********************************************************************
  2. 특정 컬럼만 검색 */

  -- TB_ItemMaster 에서 ITEMCODE, ITEMNAME, ITEMTYPE 컬럼의 데이터만 조회
  SELECT ITEMCODE, -- 품목
         ITEMNAME, -- 품목명
		 ITEMTYPE  -- 품목타입
    FROM TB_ItemMaster;

/** 실습 **
 TB_ItemMaster 테이블에서 ITEMCODE, WHCODE, BASEUNIT, MAKEDATE 컬럼을 조회하세요 */
 SELECT ITEMCODE,
        WHCODE,
		BASEUNIT,
		MAKEDATE
   FROM TB_ItemMaster;

/*********************************************************************
  3. 컬럼에 별칭 주기 (AS)
    조회되는 컬럼에 별칭을 주어 지정한 컬럼의 이름으로 변경하여 조회 */

/* TB_ITEMMASTER 테이블에서
   ITEMCODE 컬럼을 ITEM_CODE 로
   ITEMNAME 컬럼을 ITEM_NAME 으로
   ITEMTYPE 컬럼을 ITEM_TYPE 으로 표현 */
 SELECT ITEMCODE AS ITEM_CODE
       ,ITEMNAME AS ITEM_NAME
	   ,ITEMTYPE AS ITEM_TYPE
   FROM TB_ItemMaster;

/*********************************************************************
  4. 조건 절 (WHERE)
    검색 조건을 입력하여 원하는 데이터만 조회한다.
	SQL 에서는 ' 홑따옴표로 문자를 정의한다.
*/
 -- TB_ItemMaster 테이블에서 
 -- BASEUNIT 가 'EA' 인 모든 컬럼을 검색
 SELECT *
   FROM TB_ItemMaster
  WHERE BASEUNIT = 'EA';


 -- ** 검색 조건 추가 AND
/* TB_ItemMaster 테이블에서 
   BASEUNIT 가 'EA' 인 것과
   ITEMTYPE 이 'HALB' 인 모든 컬럼을 검색 */
 SELECT *
   FROM TB_ItemMaster
  WHERE BASEUNIT = 'EA'
    AND ITEMTYPE = 'HALB';

 -- ** 검색조건 추가 OR
/* TB_ItemMaster 테이블에서
   BASEUNIT 가 'EA' 이거나 (또는)
   ITEMTYPE 이 'HALB' 인 모든 컬럼을 검색
*/
SELECT *
  FROM TB_ItemMaster
 WHERE BASEUNIT = 'EA'
    OR ITEMTYPE = 'HALB';

 -- 위 내용은 묶음단위로 표현 가능
SELECT *
  FROM TB_ItemMaster
 WHERE (BASEUNIT = 'EA' OR ITEMTYPE = 'HALB');

 /** 주의 **
   컬럼이 다른 검색 조건에 OR 가 사용될 경우
   BASEUNIT 가 EA 가 아니며 ITEMTYPE 이 HALB 가 아닌 데이터가
   모두 검색될 수 있다. */

 /**** 실습 ****
   TB_ItemMaster 테이블에서
   WHCODE 가 'WH003' 또는 'WH008' 인 데이터 중
   BASEUNIT 가 'KG' 을 가진 ITEMCODE, WHCODE, BASEUNIT 컬럼을 조회하세요. */
SELECT ITEMCODE
      ,WHCODE
	  ,BASEUNIT
  FROM TB_ItemMaster
 WHERE (WHCODE = 'WH003' OR WHCODE = 'WH008' AND BASEUNIT = 'KG');

/*********************************************************************
 5. 관계 연산자의 사용
   검색 조건에 시작과 종료에 대한 정보를 입력하여 원하는 결과를 조회한다.
   보통 기간이나 숫자를 검색하지만 문자의 내역도 검색이 가능하다.
 */

 -- ** 기간 관계 연산 검색
 SELECT *
   FROM TB_ItemMaster
  WHERE EDITDATE > '2020-08-01'
    AND EDITDATE <= '2020-09-01'
-- EDITDATE 컬럼은 DATETIME 데이터 형식의 컬럼이지만
-- DATETIME 형식을 준수하는
-- 비교해 준다.

-- ** 수 관계 연산 검색
-- 정수형 컬럼 정수 조건으로 검색
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK > 10
   AND MAXSTOCK <= 20;

-- ** 문자열로 입력하여 정수형 컬럼 검색 가능
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK > '10'
   AND MAXSTOCK <= '20'

-- 포함하지 않는 데이터 검색 < >
SELECT *
  FROM TB_ItemMaster
 WHERE INSPFLAG <> 'U';

 /* TB_ItemMaster 테이블에서
    INSPFLAG 컬럼 내용이 A 이상이고 U 이하인 데이터의 컬럼을 모두 조회 */
SELECT *
  FROM TB_ItemMaster
 WHERE INSPFLAG >= 'J'
   AND INSPFLAG <= 'U';

-- ** 관계 연산자절 (BETWEEN AND)
/* TB_ItemMaster 테이블에서
MAXSTOCK 이 10 이상, 20 이하인 데이터의 컬럼을 모두 조회 */
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK >= 10 AND MAXSTOCK <= 20

SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 10 AND 20;

 --********** 실습 ************* IiLl 0oOㅇ
 /* TB_ItemMaster 테이블에서
    WHCODE 가 WH002 ~ WH005 사이의 값을 가지고
	UNITCOST 가 1000 을 초과하고
	INSPFLAG 가 I 가 아닌 행의
	PLANTCODE, ITEMCODE, WHCODE, UNITCOST, INSPFLAG 컬럼을 나타내세요. */

SELECT PLANTCODE
      ,ITEMCODE
	  ,WHCODE
	  ,UNITCOST
	  ,INSPFLAG
  FROM TB_ItemMaster
 WHERE WHCODE BETWEEN 'WH002' AND 'WH005'
   AND UNITCOST > 1000
   AND INSPFLAG <> 'I';

/*********************************************************************
 6. 특정 컬럼 검색 조건을 N 개 설정 (IN / NOT IN)
    특정 컬럼이 포함하고 있는 데이터 중 검색하고자 하는 조건이 많을 때 사용
 */

 /* TB_ItemMaster 에서
    ITEMCODE, ITEMTYPE, MAXSTOCK 컬럼을 조회하고
	MAXSTOCK 의 수량이 1 이상 3000 이하인 것 중에
	ITEMTYPE 이 'FERT', 'HALB' 인 데이터만 조회 */

SELECT ITEMCODE
	  ,ITEMNAME -- 품목명
	  ,MAXSTOCK -- 최대수량
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000
   AND ITEMTYPE = 'FERT' OR ITEMTYPE = 'HALB'
-- *** 주의 검색 조건에 OR 을 사용할 경우 괄호 묶음을 잘 해줄 것!
 
SELECT ITEMCODE -- 품목코드
      ,ITEMNAME -- 품목명
	  ,MAXSTOCK -- 최대수량
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000

 -- ** 포함하지 않는 데이터의 검색
 /* TB_ItemMaster 에서
   ITEMCODE, ITEMTYPE, MAXSTOCK 컬럼을 조회하고
   MAXSTOCK 의 수량이 1 이상 3000 이하인 것 중에
   ITEMTYPE 이 'FERT', 'HALB' 가 아닌 데이터만 조회 */
SELECT ITEMCODE
	  ,ITEMTYPE
	  ,MAXSTOCK
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000
   AND ITEMTYPE NOT IN ('FERT', 'HALB');

/****** 실습 ******
TB_ItemMaster 테이블에서
CARTYPE 컬럼의 값이 'TL', 'LM'인 것과
WHCODE 'WH004' 와 'WH007' 사이에 있는 것 중
ITEMTYPE 이 'HALB' 가 아닌
ITEMCODE, ITEMNAME, ITEMTYPE, WHCODE, CARTYPE 컬럼의 데이터를 검색하세요. */

SELECT ITEMCODE
      ,ITEMNAME
	  ,ITEMTYPE
	  ,WHCODE
	  ,CARTYPE
  FROM TB_ItemMaster
 WHERE CARTYPE IN ('TL', 'LM')
   AND WHCODE BETWEEN 'WH004' AND 'WH007'
   AND ITEMTYPE <> 'HALB';

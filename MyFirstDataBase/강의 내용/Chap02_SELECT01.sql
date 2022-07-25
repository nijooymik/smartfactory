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

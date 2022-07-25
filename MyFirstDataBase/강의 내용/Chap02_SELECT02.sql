/* 1. 데이터를 포함하는 행 조회 (LIKE)
   WHERE 조건에 검색하고자 하는 데이터의 일부분만 입력하여
   해당 내용이 포함된 모든 데이터를 표현 '%' */

-- TB_ItemMaster 테이블에서 ITEMCODE 컬럼의 데이터 중 'E'가 포함된 컬럼 데이터를 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '%E%' -- E 를 포함하고 있는 모든 데이터 조회

-- TB_ItemMaster 테이블에서 ITEMCODE 컬럼의 데이터 중 '64'로 시작하는 데이터를 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '64%'

-- TB_ItemMaster 테이블에서 ITEMCODE 컬럼의 데이터 중 '3X000E'로 끝나는 데이터를 모두 조회
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '%3X000E'

/*****************************************************************************************
2. NULL 값이 아닌 데이터 조회 및 NULL 값인 데이터 조회 (IS NULL, IS NOT NULL)
   NULL : 데이터가 없고 비어있는 상태. 데이터가 할당되지 않은 상태 */

-- TB_ItemMaster 테이블에서 MAXSTOCK 컬럼이 NULL 인 데이터를 검색
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK IS NULL;


-- TB_ItemMaster 테이블에서 MAXSTOCK 컬럼이 NULL 이 아닌 데이터 검색
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK IS NOT NULL;

 /********* 실습 ***************
 TB_ItemMaster 테이블에서 
 BOXSPEC 컬럼의 데이터가 '01' 로 끝나면서 NULL 이 아닌 
 PLANTCODE, ITEMCODE, ITEMNAME, 컬럼의 데이터를 검색하세요. */
SELECT PLANTCODE
      ,ITEMCODE
	  ,ITEMNAME
  FROM TB_ItemMaster
 WHERE BOXSPEC LIKE '%01'
   AND BOXSPEC IS NOT NULL;

/*****************************************************************************************
3. 검색 결과 정렬 (ORDER BY ASC/DESC)
  테이블에서 검색한 결과를 조건에 따라 정렬하여 나타낸다.
  오름차순으로 정렬할 경우 ASC, NULL 값을 가진 데이터가 최상위에 나타난다. */

/* TB_ItemMaster 테이블의 ITEMTYPE = 'HALB' 인 
   ITEMCODE, ITEMTYPE 컬럼의 데이터를 ITEMCODE 컬럼 데이터 기준으로 오름차순 조회 */
  SELECT ITEMCODE
	    ,ITEMTYPE
    FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
ORDER BY ITEMCODE ASC; -- ASC : 오름차순 명령 생략 가능

-- ** ORDER BY 조건이 여러 컬럼이 될 경우 왼쪽부터 순차적으로 우선순위를 가진다.
  SELECT ITEMCODE
	    ,ITEMTYPE
	    ,WHCODE
	    ,BOXSPEC
    FROM TB_ItemMaster
ORDER BY ITEMTYPE, WHCODE, BOXSPEC;

-- ** 조회하지 않는 컬럼의 데이터 정렬 조건 추가하기
/* TB_ItemMaster 테이블에서 ITEMTYPE = 'HALB' 인
   ITEMTYPE, WHCODE, BOXSPEC 컬럼을
   ITEMCODE 순서대로 정렬하여 검색 */
  SELECT ITEMTYPE
        ,WHCODE
	    ,BOXSPEC
    FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
ORDER BY ITEMCODE;

-- ** 역순으로 정렬하기 DESC
/* TB_ItemMaster 테이블의 ITEMTYPE = 'HALB' 인
   ITEMCODE
*/
  SELECT ITEMCODE
        ,ITEMTYPE
    FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
ORDER BY ITEMCODE DESC;

-- ** 컬럼 별 내림차순, 오름차순 조건

/* TB_ItemMaster 테이블에서 INSFLAG 가 NULL 이 아닌
   ITEMTYPE, WHCODE, INSFLAG 컬럼을
   ITEMTYPE 값은 오름차순, WHCODE 내림차순, INSFLAG 는 오름차순으로 정렬 */
  SELECT ITEMTYPE
        ,WHCODE
	    ,INSPFLAG
    FROM TB_ItemMaster
   WHERE INSPFLAG IS NOT NULL
ORDER BY ITEMTYPE, WHCODE DESC, INSPFLAG;

/************ 실습 *****************
TB_ItemMaster 테이블에서
MATERIALGRADE 컬럼의 값이 NULL 이고
CARTYPE 컬럼값이 MD,RB,TL 이 아니면서
ITEMCODE 컬럼값이 '001' 을 포함하고
UNITCOST 컬럼값이 0 인 행의 모든 컬럼을
ITEMNAME 컬럼은 내림차순, WHCODE 컬럼은 오름차순으로 조회하세요. */
  SELECT *
    FROM TB_ItemMaster
    WHERE MATERIALGRADE IS NULL
      AND CARTYPE NOT IN ('MD', 'RB', 'TL')
      AND ITEMCODE LIKE '%001%'
      AND UNITCOST = 0
 ORDER BY ITEMNAME DESC, WHCODE;

/*****************************************************************************************
4. 데이터 합병검색 (DISTINCT)
 컬럼의 데이터가 중복이 있을 경우 중복된 데이터를 합병하여 검색 */

-- TB_ItemMaster 테이블의 ITEMTYPE 만 조회
 SELECT ITEMTYPE
   FROM TB_ItemMaster;

-- TB_ItemMaster 테이블의 ITEMTYPE 을 합병 후 검색
SELECT DISTINCT ITEMTYPE
  FROM TB_ItemMaster;

-- ** 다중 컬럼을 조회 시 조회하는 컬럼이 모두 중복되는 조건을 만족하는 데이터만 조회된다.

/* TB_ItemMaster 테이블에서 BASEUNIT = 'KG' 값을 가진 데이터 중
   ITEMTYPE 과 ITEMSPEC 이 동시에 중복되지 않는 합병된 데이터만 조회 */
SELECT DISTINCT ITEMTYPE
			   ,ITEMSPEC
		   FROM TB_ItemMaster
		  WHERE BASEUNIT = 'KG'
	   ORDER BY ITEMSPEC;

/******* 실습 *************
TB_ItemMaster 테이블에서 BOXSPEC 이 'DS-PLT'로 시작하는
ITEMTYPE 별 WHCODE 의 종류를 조회하세요. */
SELECT DISTINCT ITEMTYPE
			   ,WHCODE
		   FROM TB_ItemMaster
		  WHERE BOXSPEC LIKE 'DS-PLT%';

/*****************************************************************************************
5. 검색된 데이터 중 지정하는 행의 개수만 구하기 ( TOP (N) )
 . 검색조건을 만족하는 행 중에 순차적으로 지정한 행의 개수만 표현
   EX) 불량률 발생 품목 상위 TOP 10 등을 산출할 때 자주 사용 */

-- ** 상위 10개의 데이터만 검색
SELECT TOP (10) *
  FROM TB_ItemMaster;

-- ORDER BY 를 통하여 내림차순/오름차순으로 조회된 5개 행을 조회
  SELECT TOP (5) *
  	FROM TB_ItemMaster
ORDER BY MAXSTOCK DESC;

-- ** 검색 조건을 입력한 상위 데이터 조회
  SELECT TOP (8) *
    FROM TB_ItemMaster
   WHERE WHCODE = 'WH005'
ORDER BY MAXSTOCK DESC;


/******* 실습 *********
TB_StockMMrec 테이블에서 INOUTFLAG 가 'O' 인 데이터 중
INOUTDATE(입출일자) 가 가장 최근인 데이터 상위 10개의
PLANTCODE, ITEMCODE, MATLOTNO, WHCODE, INOUTDATE, INOUTQTY 를 조회하세요. */
SELECT TOP (10) PLANTCODE
			   ,ITEMCODE
			   ,MATLOTNO
			   ,WHCODE
			   ,INOUTDATE
			   ,INOUTQTY
		   FROM TB_StockMMrec
	   	  WHERE INOUTFLAG = 'O'
       ORDER BY INOUTDATE DESC;

/*****************************************************************************************
6. 데이터 합병 검색2 (GROUP BY, HAVING, 집계함수) : 중요도 *****
 . GROUP BY 조건에 따라 해당 컬럼의  데이터를 병합
 . GROUP BY 로 조회된결과에서 조회 조건을 주어 검색(HAVING)
 . 집계 함수를 사용하여 병합되는 데이터를 연산할 수 있다. */

-- GROUP BY 의 기본 문법
  SELECT ITEMCODE               -- 5. ITEMCODE 컬럼을 조회하라.
    FROM TB_ItemMaster          -- 1. TB_ItemMaster 테이블에서
   WHERE ITEMTYPE = 'ROH'       -- 2. ITEMTYPE = 'ROH' 라는 데이터를
GROUP BY ITEMCODE               -- 3. ITEMCODE 컬럼 내역으로 병합하고
  HAVING ITEMCODE LIKE '%3%'    -- 4. 병합된 결과 중 ITEMCODE 는 3 을 포함하는
-- WHERE 절과 HAVING 절은 조건절이므로 생략이 가능

/* DISTINCT 와 다른 점
 - DISTINCT
   . WHERE 조건을 만족하는 중복된 내용을 병합하여 검색

 - GROUP BY
   . 병합된 데이터의 결과에 조건을 두어(HAVING) HAVING 조건으로 재검색
   . 집계함수와 같이 사용할 때 용이하다. */

-- ** DISTINCT 
/* TB_ItemMaster 테이블에서 ITEMTYPE = 'HALB' 인 행 중 중복을 병합한 ITEMSPEC
   컬럼 데이터로 검색 */

SELECT DISTINCT ITEMSPEC
  FROM TB_ItemMaster
 WHERE ITEMTYPE = 'HALB'
 
-- ** GROUP BY
/* TB_ItemMaster 테이블에서 ITEMTYPE = 'HALB' 인 행 중 
   WHCODE를 병합하여 검색하고
   결과 중 WHCODE가 'WH003' 인 내역을 검색 */
   
  SELECT WHCODE
	FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
GROUP BY WHCODE
  HAVING WHCODE = 'WH003';

 -- ** 주의 GROUP BY 를 실행할 모든 컬럼은 반드시 SELECT 조회 컬럼에 포함되어 있어야 한다.
 
 /* TB_ItemMaster 테이블에서
    ITEMSPEC 컬럼을 병합하여 결과를 나타내고자 하나
	GROUP BY 를 할 대상에 포함되어 있지 않는 컬럼을 SELECT 하는 경우 */

  SELECT ITEMCODE
    FROM TB_ItemMaster
GROUP BY ITEMSPEC;	-- 오류 발생

-- 정상적인 구문으로 변경;
  SELECT ITEMSPEC
    FROM TB_ItemMaster
GROUP BY ITEMSPEC, WHCODE;

/* GROUP BY, HAVING 구문을 사용하여 TB_StockMMSP 테이블에서
   STOCKQTY 가 1500 개 이상인 데이터의 INDATE(입고일자) 별 ITEMCODE(품목) 컬럼을 조회하고
   조회된 결과 중 ITEMDCODE 가 C 로 끝나는 데이터를 검색하세요. */
  SELECT INDATE            -- 입고 일자
        ,ITEMCODE
    FROM TB_StockMM
   WHERE STOCKQTY > 1500
GROUP BY INDATE, ITEMCODE
  HAVING ITEMCODE LIKE '%C';

-- ** 주의 HAVING 을 실행할 컬럼은 반드시 GROUP BY, 집계함수를 통해 변합된 상태여야 한다.

/* TB_ItemMaster 테이블에서 ITEMNSPEC, WHCODE 컬럼을 병합하여 나온 결과에서 ITEMTYPE 을 검색한 경우 (오류) */

-- 정상 동작 구문으로 변경
  SELECT ITEMSPEC
        ,WHCODE
    FROM TB_ItemMaster
GROUP BY ITEMSPEC, WHCODE
  HAVING WHCODE = 'WH003'; -- GROUP BY 에 병합된 함수여야 함
  
/***** 집계함수
SUM()   : 병합되는 컬럼의 데이터를 모두 합한다.
MIN()   : 병합되는 컬럼의 데이터 중 가작 작은 수를 나타낸다.
MAX()   : 병합되는 컬럼의 데이터 중 가작 높은 수를 나타낸다.
COUNT() : 병합되는 컬럼의 총 병합 개수를 나타낸다.
AVG()   : 병합되는 컬럼의 숫자 데이터 값의 평균을 나타낸다. */

/* 집계함수를 사용하는 컬럼은 GROUP BY 로 병합된 대상에서 생략 가능 
   집계함수를 사용하지 않는 컬럼이 포함되어 있을 경우 GROUP BY 할 컬럼 대상으로 등록되어야 함 */

-- ** ITEMCODE 별 등록 행의 개수 조회
  SELECT ITEMCODE
        ,COUNT(*) AS ITEM_CNT
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE 별 STOCKQTY 합 조회
  SELECT ITEMCODE
        ,SUM(STOCKQTY) STOCKQTY_SUM
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE  별 STOCKQTY 평균 조회
  SELECT ITEMCODE
        ,AVG(STOCKQTY) AS STOFKQTY_AVG
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE  별 STOCKQTY 최소값 조회
  SELECT ITEMCODE
        ,MIN(STOCKQTY) AS STOFKQTY_MIN
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE  별 STOCKQTY 최대값 조회
  SELECT ITEMCODE
        ,MAX(STOCKQTY) AS STOFKQTY_MAX
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** 집계 함수를 여러번 사용하여 원하는 결과를 얻을 수 있다.
-- ITEMTYPE 별 UNITCOST 의 합과 최소값 조회
-- 집계된 결과에서 HAVING 조건절을 추가하여 원하는 결과를 재검색할 수 있다.
  SELECT ITEMTYPE
        ,SUM(UNITCOST) AS SUM_COST
	    ,MIN(UNITCOST) AS MIN_COST
    FROM TB_ItemMaster
GROUP BY ITEMTYPE
  HAVING SUM(UNITCOST) > 20000

-- ** 집계 함수를 사용한 결과의 조회조건 필터링(HAVING) 후 정렬
-- 집계된 결과에서 HAVING 조건절을 추가하여 원하는 결과 값을 얻은 데이터를 정렬

/* TB_ItemMaster 테이블에서 UNITCOST 가 0 이상인 데이터 중
   ITEMTYP 별로 UNITCOST 의 총 합, UNITCOST 의 최대값을 나타내고
   결과의 내용 중 UNITCOST 의 합이 100 이상인 데이터를
   UNITCOST 최대값 기준으로 오름차순 정렬 */

   (SELECT ITEMTYPE							--5
		  ,SUM(UNITCOST) AS UNITCOST_SUM
		  ,MAX(UNITCOST) AS UNITCOST_MAX
	  FROM TB_ItemMaster					--1
	 WHERE UNITCOST >= 0					--2
  GROUP BY ITEMTYPE							--3
    HAVING SUM(UNITCOST) > 100)				--4
  ORDER BY UNITCOST_MAX;					--6
  -- SELECT 수행 후 컬럼 별칭이 부여되어 ORDER BY 에서는 별칭으로 호출 가능
  /* 데이터 베이스 연산 처리 순서
  FROM -> WHERE -> GROUP BY -> HAVING -> SELECT -> ORDER BY */

-- ** 하나의 컬럼에 대한 집계를 나타낼 때에는 GROUP BY 나 DISTNCT 를 생략하여 검색이 가능
SELECT SUM(UNITCOST) AS ITEMCODE_SUM
  FROM TB_ItemMaster;

  /****** 중요 *********
  GROUP BY 는 집계함수와 같이 사용할 때 유용하게 쓰인다. */

  /* TB_StockMM 테이블에서 STOCKQTY 가 1000 개 이상인 
    INDATE 별 ITEMCODE 의 병합될 데이터 개수가 1보다 큰 내역을 검색하라. */
  SELECT INDATE
	    ,COUNT(ITEMCODE) AS CNT
    FROM TB_StockMM
   WHERE STOCKQTY >= 1000
GROUP BY INDATE, ITEMCODE
  HAVING COUNT(*) > 1;

  /******* 실습 *********
  TB_StockMMrec(자재 입출 이력) 테이블의 데이터 중
  INOUTQTY(입출고 수량) 1000 보다 크고, INOUTFLAG 가 'I' (입고이력) 인
  INOUTDATE(입출고일자) 별 WHCODE(창고) 에 병합될 데이터의 개수가 2개 이상인 데이터를
  INOUTDATE 오름차순으로 조회하세요. */
  SELECT INOUTDATE
		,WHCODE
  	    ,COUNT(*) AS CNT
    FROM TB_StockMMrec
   WHERE INOUTQTY > 1000
     AND INOUTFLAG = 'I'
GROUP BY INOUTDATE, WHCODE
  HAVING COUNT(*) >= 2
ORDER BY INOUTDATE;

/*****************************************************************************************
7. 하위 쿼리
  조건을 만족시키는 값을 (WHERE 열이름, 조건 만족 대상 (=,<>,IN,LIKE) '?') 쿼리로 작성하여 
  데이터를 검색하는 방식
  장점 : SQL 구문안에서 유연하게 또다른 SQL 구문을 만들어 활용할 수 있다.
  단점 : 연산속도가 느려진다. 쿼리가 복잡해진다. */

  -- ** 하위쿼리를 통한 데이터의 조회

/* TB_StockMMrec(자재 입출 이력) 테이블에서 PONO(발주번호) 가 'PO202106270001' 인 ITEMCODE 의 정보를
   TB_ItemMaster(품목마스터) 테이블에서 조회하여 ITEMCODE, ITEMNAME, ITEMTYPE, CARTPYE 컬럼의 정보를 검색 */

-- 1. 기준이 되는 테이블 (메인테이블) TB_ItemMaster
SELECT ITEMCODE
	  ,ITEMNAME
	  ,ITEMTYPE
	  ,CARTYPE
  FROM TB_ItemMaster
 WHERE ITEMCODE = (SELECT ITEMCODE
					 FROM TB_StockMMrec 
					WHERE PONO = 'PO202106270001')

-- 하위 쿼리에서 조회되어야 하는 컬럼은 조건을 대입할 컬럼의 내용을 포함해야 한다.

-- ** '=' 인 조건에는 두 개 이상의 값이 나오는 하위쿼리 내용을 적용할 수 없다.
SELECT ITEMCODE -- 품목코드
	  ,ITEMNAME -- 품목명
  FROM TB_ItemMaster
 WHERE ITEMCODE = (SELECT *
					 FROM TB_StockMMrec	
					WHERE INOUTFLAG = 'I')

-- ** 포함하지 않는 데이터 검색
SELECT ITEMCODE
	  ,ITEMNAME
  FROM TB_ItemMaster
 WHERE ITEMCODE <> (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE PONO = 'PO202106270001');

-- ** 두 개 이상인 데이터를 하위 쿼리로 적용하는 방법
SELECT ITEMCODE
	  ,ITEMNAME
  FROM TB_ItemMaster
 WHERE ITEMCODE IN (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE PONO LIKE 'PO%'
					   AND ITEMCODE IS NOT NULL)

-- ** 하위 쿼리의 하위 쿼리... 의 하위 쿼리 ... 의 하위 쿼리

/* TB_StockMM (자재 재고) 테이블에서 STOCKQTY (재고수량) 이 3000 보다 큰 MATLOTNO(LOTNO) 를 가진 
   TB_StockMMrec 테이블의 ITEMCODE 데이터를
   TB_ItemMaster 테이블에서 ITEMCODE, ITEMNAME, ITEMTYPE, CARTYPE 컬럼으로 검색 */

	-- 1. 자재 재고 테이블에서 STOCKQTY 가 30000 보다 큰 MATLOTNO 리스트 조회
SELECT MATLOTNO 
  FROM TB_StockMM
 WHERE STOCKQTY > 3000

	-- 2. 자재 입출이력테이블(TB_StockMMrec) 에서 1번에서 조회한 MATLOTNO 를 가지는 ITEMCODE 조회
SELECT ITEMCODE
  FROM TB_StockMMrec
 WHERE MATLOTNO IN (SELECT MATLOTNO
					  FROM TB_StockMM
					 WHERE STOCKQTY > 3000)

	-- 3. 품목마스터(TB_ItemMaster) 에서 해당 ITEMCODE 정보를 찾기
SELECT ITEMCODE,
	   ITEMNAME,
	   ITEMTYPE
	   CARTYPE
  FROM TB_ItemMaster
 WHERE ITEMCODE IN (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE MATLOTNO IN (SELECT MATLOTNO
										  FROM TB_StockMM
										 WHERE STOCKQTY > 3000));

-- ** 하위쿼리는 아닌데 하위쿼리처럼 보이는 것들

-- 1. SELECT 구문을 컬럼 위치에 두는 경우
/* TB_StockMM 테이블에서 ITEMCODE, INDATE, MALTLOTNO 컬럼의 데이터를 검색하고
   TB_StockMMrec 테이블에서 TB_StockMM 테이블에서 조회한 MATLOTNO 컬럼의 데이터를 포함하고
   INOUTFLAG = 'OUT' 라는 값을 가지는 INOUTDATE 컬럼의 데이터를 조회 */

SELECT ITEMCODE
	  ,INDATE
	  ,MATLOTNO
	  ,(SELECT INOUTDATE 
		  FROM TB_StockMMrec 
		 WHERE MATLOTNO = A.MATLOTNO 
		   AND INOUTFLAG = 'OUT') AS INOUTDATE
  FROM TB_StockMM A

-- 연산 순서
-- 1단계. TB_StockMM 에서 데이터를 조회
SELECT ITEMCODE
	  ,INDATE
	  ,MATLOTNO
  FROM TB_StockMM

-- 2단계. 컬럼에 있는 SELECT 구문을 1단계에서 조회한 MATLOTNO 별로 각각 실행
SELECT INOUTDATE
  FROM TB_StockMMrec
 WHERE MATLOTNO = 'LOTR2021070817274225'
   AND INOUTFLAG = 'OUT';

  -- LOTR2021070817274225
  -- LT_R2021082012481881
  -- LTROH1132574030001
  -- LTROH1438534870001
  -- LTROH1459097100001
  -- LTROH1556377070001
  -- LTROH1650200500001
  -- LTROH2130262570001
  -- LTROH2134195800002

  -- *** 주의 ***
  -- 기준테이블 TB_StockMM 에서 조회 1번
  -- 컬럼 데이터 표현하기 위해서 조회 9번
  -- 총 10번의 검색연산이 실행된다. (비효율)

-- ** SELECT 구문을 FROM 위치에 두는 경우

/* TB_StockMMrec 테이블 데이터 중 INOUTQTY 가 1000 보다 크고, INOUTFLAG 가 'I' 인
   INOUTDATE 별 WHCODE 의 병합될 데이터의 개수가 2개 이상인 데이터를 검색하시오 */
  SELECT INOUTDATE	
  	    ,WHCODE
  	    ,COUNT(*) AS CNT
    FROM TB_StockMMrec
   WHERE INOUTQTY > 1000
     AND INOUTFLAG = 'I'
GROUP BY INOUTDATE, WHCODE
  HAVING COUNT(*) >= 2

  -- GROUP BY 구문을 하나의 테이블로 사용하는 방법

SELECT A.INOUTDATE
	  ,A.WHCODE
	  ,A.CNT
  FROM (SELECT INOUTDATE
			  ,WHCODE
			  ,COUNT(*) AS CNT
		  FROM TB_StockMMrec
		 WHERE INOUTQTY > 1000
		   AND INOUTFLAG = 'I'
	  GROUP BY INOUTDATE,WHCODE) A
 WHERE A.CNT >= 2

/*****************************************************************************************
8. CASE WHEN
-- 분기문, 대상의 상태에 따라서 값이나 조건을 다르게 적용한다.
-- ** 반드시 END 로 끝맺음을 해주어야 한다. */

-- ** 1번째. CASE 용법

SELECT INOUTFLAG -- 입출고 구분. I : 입고 / O : 출고
	  ,CASE INOUTFLAG WHEN 'I' THEN '입고'
				   	  WHEN 'O' THEN '출고'
				      ELSE '기타' END		AS INOUT_FLAG
  FROM TB_StockMMrec

-- ** 2번째. CASE 용법 
SELECT PLANTCODE -- 공장
	  ,MATLOTNO  -- LOTNO
	  ,WHCODE	  -- 창고
	  ,STOCKQTY  -- 재고수량
	  ,CASE WHEN STOCKQTY <= 0 THEN '재고없음'
			WHEN STOCKQTY >= 0 AND STOCKQTY <= 1000 THEN '안전수량'
			ELSE '재고초과' END AS STOCK_STATE
  FROM TB_StockMM

/*****************************************************************************************
9. NULL 인 값을 원하는 데이터로 변형하기 ISNULL(?,?) */

/* TB_StockMMrec 테이블에서 PLANTCODE, INOUTDATE, INOUTSEQ, ITEMCODE 컬럼의 데이터를 검색하고
   ITEMCODE 가 NULL 일 경우 0 으로 표현하세요. */

SELECT PLANTCODE
	  ,INOUTDATE
	  ,INOUTSEQ
	  ,ISNULL(ITEMCODE,0) AS ITEMCODE
  FROM TB_StockMMrec
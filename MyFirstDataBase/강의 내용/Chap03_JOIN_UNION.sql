 /*
	1. 테이블간 데이터 연결 및 조회(JOIN)
	JOIN : 둘 이상의 테이블을 연결해서 데이터를 검색하는 방법
		   테이블을 서로 연결하기 위해서는 하나 이상의 컬럼을 공유하고 있어야 함
	  ON : 두 테이블을 연결할 기준 컬럼 설정 명령어

	- 내부 조인 (INNER JOIN) : JOIN
	- 외부 조인 (OUTER JOIN) : LEFT JOIN, RIGHT JOIN, FULL JOIN
 */

 -- JOIN
 -- 공통적인 부분만 조회되는 연결 문

 /* TB_CUST 테이블과 TB_SaleList 테이블에서
	각각 (TB_CUST) ID, (TB_SaleList) CUST_ID 값이 동일한 데이터를 가지고
	고객 ID, 고객이름, 판매일자, 과일, 판매수량을 표현 */

 -- ** 명시적 표현법 JOIN 문과 ON

 -- 판매 현황 리스트 테이블을 기준으로 고객 정보를 JOIN 한 경우
 SELECT CUST_ID,				-- 고객 ID
		''		AS CUST_NAME,	-- 고객 명
		DATE,					-- 판매일자
		FRUIT_NAME,				-- 과일이름
		AMOUNT					-- 판매수량
   FROM TB_SALELIST A JOIN TB_CUST B
						ON A.CUST_ID = B.ID;

 -- 고객 정보를 기준으로 조회
 -- 아래의 결과처럼 고객 정보가 전부 나타난다.

 SELECT A.ID
	   ,A.NAME
   FROM TB_Cust A

 -- 고객정보 테이블을 기준 테이블로 하고 판매 현황 테이블을 서브 테이블로 한 후 
 -- JOIN 하였지만 기준테이블에 있는 데이터가 나타나지 않는 경우가 생긴다.
 SELECT A.ID
	   ,A.NAME
	   ,B.DATE
	   ,B.FRUIT_NAME
	   ,B.AMOUNT
   FROM TB_CUST A JOIN TB_SALELIST B
					ON A.ID = B.CUST_ID

 -- *** JOIN : 공통적인 부분만 조회되며
 -- 연결되는 테이블 간 공유하는 칼럼의 데이터가 둘다 존재해야 데이터를 나타낸다.

 -- 묵시적 표현법 : JOIN ON 문을 쓰지 않고 테이블만 나열 후 참조될 컬럼을 정의하는 방법
 SELECT A.ID		 AS ID
	   ,A.NAME		 AS CUSTNAME
	   ,B.FRUIT_NAME AS FRUIT_NAME
   FROM TB_Cust		A 
	   ,TB_SaleList B -- INNER JOIN (JOIN)
  WHERE A.ID = B.CUST_ID

 -- 외부 JOIN (LEFT JOIN, RIGHT JOIN)
 
 -- ** LEFT JOIN
 --  . 왼쪽에 있는 테이블의 데이터를 기준으로 오른쪽에 있는 테이블의 데이터를 검색하고
 --	   오른쪽 테이블에 데이터가 없을 경우 NULL 로 표시된다.
 
 /* 왼쪽에 있는 TB_SalesList 의 내용을 기준으로 판매 현황 별 고객 정보를 나타내세요. */
 SELECT A.DATE		 -- 판매일자
	   ,A.CUST_ID	 -- 고객 ID
	   ,B.NAME		 -- 고객 명
	   ,A.FRUIT_NAME -- 과일명
	   ,A.AMOUNT	 -- 판매수량
   FROM TB_SaleList A LEFT JOIN TB_CUST B -- LEFT OUTER JOIN
							 ON A.CUST_ID = B.ID

 -- ** RIGHT JOIN (RIGHT INNER JOIN)
 -- 오른쪽에 있는 테이블의 데이터를 기준으로 왼쪽에 있는 테이블의 데이터를 검색하고
 -- 왼쪽 테이블에 데이터가 없을 경우 NULL 로 표시된다. (JEFT JOIN 과 반대)

 /* 오른쪽에 있는 TB_Cust 의 내용을 기준으로 고객 별 판매 현황을 나타내세요. */
 SELECT B.ID		 -- 고객
	   ,B.NAME		 -- 고객 명
	   ,A.DATE		 -- 판매일자
	   ,A.FRUIT_NAME -- 과일명
	   ,A.AMOUNT	 -- 숫자
 FROM TB_SaleList A RIGHT JOIN TB_Cust B
							  ON A.CUST_ID = B.ID;

 -- ** 다중 JOIN
 -- 참조할 데이터가 여러 테이블에 있을 때 기준 테이블과 참조 테이블과의 다중 JOIN 으로 데이터를 검색할 수 있다.
 
 /* 판매 현황을 판매일자, 고객이름, 고객 연락처, 판매과일, 과일단가, 판매금액 으로 나타내세요. */

 SELECT A.DATE				   AS SALEDATE    -- 판매일자
	   ,B.NAME				   AS CUSTNAME    -- 고객이름
	   ,B.PHONE				   AS CUSTPHONE   -- 고객 연락처
	   ,A.FRUIT_NAME		   AS FRUITNAME   -- 판매 과일
	   ,C.UNITPRICE			   AS UNITPRICE   -- 과일단가
	   ,A.AMOUNT			   AS AMOUNT	  -- 판매수량
	   ,C.UNITPRICE * A.AMOUNT AS SALES_PRICE -- 판매금액
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID			
					  LEFT JOIN T_Fruit C
							 ON A.FRUIT_NAME = C.FRUIT_NAME;

 /****** 실습 *******
	TB_StockMMrec (자재 입출 이력) A 테이블에서 ITEMCODE 가 NULL 이 아니고, INOUTFLAG (입출여부) = 'I' (입고)
	TB_ItemMaster (품목 마스터) B 테이블에서 ITEMTYPE (품목타입) 이 'HALB' 인 것의
	A.INOUTDATE,	A.INOUTSEQ,		A.MATLOTNO,		,A.ITEMCODE,	B.ITEMNAME,		B.CARTYPE 정보를 나타내세요.
	(입출 일자)		(입출순번)		(LOT 번호)		(품목코드)		(품명)			(차종)
 */
 SELECT A.INOUTDATE
	   ,A.INOUTSEQ
	   ,A.MATLOTNO
	   ,A.ITEMCODE
	   ,B.ITEMNAME
	   ,B.CARTYPE
   FROM TB_StockMMrec A LEFT JOIN TB_ItemMaster B
							   ON A.PLANTCODE = B.PLANTCODE
							  AND A.ITEMCODE  = B.ITEMCODE
							--AND B.ITEMTYPE = 'ROH' -- JOIN 을 하기 전에 TB_ItemMaster 테이블에서 필터링
  WHERE A.ITEMCODE IS NOT NULL
    AND A.INOUTFLAG = 'I'
	AND B.ITEMTYPE = 'ROH'; -- JOIN 이후에 검색 결과에서 필터링

 -- ** 하위쿼리의 JOIN

 /* 고객별 과일의 총 계산 금액 구하기 (고객ID, 고객명, 과일이름, 과일별총구매금액)
    . 구매 내역이 없는 고객은 ID와 이름만 표현 */


 -- 산출 과정
 -- 1. 기준 테이블 설정(구상) -- 고객별 과일의 총 구매 현황이므로 고객 테이블이 기준이 된다. TB_Cust
 -- 2. 고객별 과일별 총 판매수량을 구한다.
  SELECT CUST_ID	    AS CUSTID	  -- 고객 ID
 	    ,FRUIT_NAME  AS FRUITNAME  -- 과일정보
 	    ,SUM(AMOUNT) AS FRUITCOUNT -- 과일 판매 수량
    FROM TB_SaleList
GROUP BY CUST_ID,FRUIT_NAME;

 -- 3. 고객별 과일의 총 판매 수량에 단가를 곱한다.
 -- **** SELECT 구문을 테이블처럼 FROM 절에서 사용하기
 SELECT A.CUSTID				   AS CUSTID
	   ,A.FRUITNAME				   AS FRUITNAME
	   ,A.FRUITCOUNT * B.UNITPRICE AS FRUIT_TOTAL_PRICE
   FROM (SELECT CUST_ID	    AS CUSTID	  -- 고객 ID
	  		   ,FRUIT_NAME  AS FRUITNAME  -- 과일정보
 		       ,SUM(AMOUNT) AS FRUITCOUNT -- 과일 판매 수량
		   FROM TB_SaleList
	   GROUP BY CUST_ID,FRUIT_NAME) A LEFT JOIN T_Fruit B
											 ON A.FRUITNAME = B.FRUIT_NAME
									  LEFT JOIN TB_Cust C
											 ON A.CUSTID = C.ID;

 SELECT AA.ID
	   ,AA.NAME
	   ,BB.FRUITNAME
	   ,BB.FRUIT_TOTAL_PRICE
   FROM TB_Cust AA LEFT JOIN (SELECT A.CUSTID				    AS CUSTID
						  		    ,A.FRUITNAME				AS FRUITNAME
									,A.FRUITCOUNT * B.UNITPRICE AS FRUIT_TOTAL_PRICE
							    FROM (SELECT CUST_ID	 AS CUSTID	   -- 고객 ID
							    			,FRUIT_NAME  AS FRUITNAME  -- 과일정보
							  				,SUM(AMOUNT) AS FRUITCOUNT -- 과일 판매 수량
							  		    FROM TB_SaleList
									GROUP BY CUST_ID,FRUIT_NAME) A LEFT JOIN T_Fruit B
							  											  ON A.FRUITNAME = B.FRUIT_NAME) BB
						  ON AA.ID = BB.CUSTID;

 -- 간략하게 줄여서 구현
 -- 1. 고객별 과일별 총 수량 구하기
  SELECT CUST_ID,					-- 고객 ID
 	     FRUIT_NAME,					-- 과일 이름
	     SUM(AMOUNT) AS FRUIT_AMOUNT -- 과일별 총 구매 수량
    FROM TB_SaleList
GROUP BY CUST_ID, FRUIT_NAME

 -- 2. 단가와 구매수량을 합쳐서 총 금액 산출
  SELECT A.CUST_ID
	    ,C.NAME
	    ,A.FRUIT_NAME
		,SUM(A.AMOUNT) AS AMOUNT
	    ,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   RIGHT JOIN TB_Cust C
							   ON A.CUST_ID = C.ID
GROUP BY A.CUST_ID, C.NAME, A.FRUIT_NAME;

/********** 실습 ***************
 과일가게 고객별 총 금액을 구하세요. 판매 내역이 없는 고객은 표현하지 않아도 됨. */
  SELECT C.NAME
	    ,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   LEFT JOIN TB_CUST C
							  ON A.CUST_ID = C.ID
GROUP BY C.NAME;

-- REVIEW
  SELECT A.CUST_ID
		,C.NAME
	    ,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   RIGHT JOIN TB_CUST C
							   ON A.CUST_ID = C.ID
GROUP BY A.CUST_ID, C.NAME;

/****** 실습 **************
고객의 총 구매 금액이 가장 큰 고객만 나타내세요. (고객 ID, 고객이름, 총구매금액) */
  SELECT TOP (1) A.CUST_ID
				,C.NAME
				,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   RIGHT JOIN TB_CUST C
							   ON A.CUST_ID = C.ID
GROUP BY A.CUST_ID, C.NAME
ORDER BY FRUIT_PRICE DESC;

/****** 실습 **************
고객별 총 구매 금액이 40000원이 넘는 고객의 내역만 검색하세요. (고객 ID, 고객이름, 총구매금액) */
  SELECT A.CUST_ID
		,C.NAME
		,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   LEFT JOIN TB_CUST C
							   ON A.CUST_ID = C.ID
GROUP BY A.CUST_ID, C.NAME
  HAVING SUM(A.AMOUNT * B.UNITPRICE) > 40000;

 /******** 실습 ***************
 2022-06-13 일부터 2022-06-14 일까지의 고객별 총 구매 금액을 구하시오. (고객 ID, 고객이름, 총구매금액) */
  SELECT A.CUST_ID
		,C.NAME
		,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   LEFT JOIN TB_CUST C
							   ON A.CUST_ID = C.ID
   WHERE A.DATE BETWEEN '2022-06-13' AND '2022-06-14'
GROUP BY A.CUST_ID, C.NAME, A.DATE;

/*********************************************************
2. UNION / UNION ALL
   - 다수의 검색 내역 병합
     . 검색한 결과가 여러 개 있을 때 병합

   UNION	 : 중복되는 데이터는 합병하여 표시
   UNION ALL : 데이터를 모두 표시

   ** 합병될 컬럼의 데이터 형식과 컬럼의 수는 일치해야 한다. */

 SELECT DATE	   AS DATE
	   ,CUST_ID	   AS CUSTID
	   ,FRUIT_NAME AS FRUITNAME
	   ,AMOUNT	   AS AMOUNT
   FROM TB_SaleList -- 고객 판매 현황 리스트 8

 UNION ALL

 SELECT DATE	   AS DATE
	   ,CUSTCODE   AS CUSTCODE
	   ,FRUIT_NAME AS FRUIT_NAME
	   ,AMOUNT	   AS AMOUNT
   FROM TB_OrderList -- 거래처 발주 현황 리스트 6

 -- UNION 으로 실행 시 6월 12일 사과의 주문 거래처코드와 주문과일, 수량이 일치하여 중복

 -- ** 판매 내역/발주 내역인지 확인하기 위하여 TITLE 을 설정하였을 경우

 SELECT '판매'			AS TITLE
	   ,A.DATE			AS DATE
	   ,A.CUST_ID		AS CUST_ID
	   ,A.FRUIT_NAME	AS FRUIT_NAME
	   ,A.AMOUNT		AS AMOUNT
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID

  UNION

 SELECT '발주'		AS TITLE
	   ,DATE		AS DATE
	   ,CUSTCODE	AS CUSTCODE	
	   ,FRUIT_NAME	AS FRUIT_NAME
	   ,AMOUNT		AS AMOUNT
   FROM TB_OrderList

 -- 고객명, 거래처명으로 표현하고 싶은 경우 
 -- JOIN, 직접입력

 -- 고객이 구매한 내역
 SELECT '판매'			AS TITLE
	   ,A.DATE			AS DATE
	   ,A.CUST_ID		AS CUST_ID
	   ,B.NAME         AS NAME
	   ,A.FRUIT_NAME	AS FRUIT_NAME
	   ,A.AMOUNT		AS AMOUNT
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID

  UNION

 -- 거래처에 발주한 내역
 SELECT '발주'							 AS TITLE
	   ,DATE							 AS DATE
	   ,CUSTCODE                     AS CUST_ID
	   ,CASE CUSTCODE WHEN 1 THEN '대림'	
					  WHEN 2 THEN '삼전'
					  WHEN 3 THEN '하나'
					  END				 AS NAME
	   ,FRUIT_NAME						 AS FRUIT_NAME
	   ,AMOUNT							 AS AMOUNT
   FROM TB_OrderList

 /************* 실습 ************
 발주 내역과 판매 내역에 각각의 과일의 총 발주금액과 판매금액을 추가하여 표현하세요
 발주금액(ORDER_PRICE * 주문수량(AMOUNT)), 판매금액(PRICE * 구매수량(AMOUNT))
 *컬럼 이름은 INOUTPRICE
 *발주 금액은 -로 표현 */
 SELECT '판매'					AS TITLE
	   ,A.DATE					AS DATE
	   ,B.ID				    AS CUST_ID
	   ,B.NAME                  AS NAME
	   ,A.FRUIT_NAME			AS FRUIT_NAME
	   ,A.AMOUNT				AS AMOUNT
	   ,A.AMOUNT * C.UNITPRICE  AS INOUTPRICE
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID
					  LEFT JOIN T_Fruit C
							 ON A.FRUIT_NAME = C.FRUIT_NAME
  UNION

 -- 거래처에 발주한 내역
 SELECT '발주'							 AS TITLE
	   ,DATE							 AS DATE
	   ,A.CUSTCODE						 AS CUSTCODE
	   ,CASE A.CUSTCODE WHEN 1 THEN '대림'	
					    WHEN 2 THEN '삼전'
					    WHEN 3 THEN '하나'
					    END				 AS NAME
	   ,A.FRUIT_NAME					 AS FRUIT_NAME
	   ,A.AMOUNT						 AS AMOUNT
	   ,A.AMOUNT * -C.ORDER_PRICE		 AS INOUTPRICE
   FROM TB_OrderList A LEFT JOIN T_Fruit C
							  ON A.FRUIT_NAME = C.FRUIT_NAME

 -- ** 조회 결과 일자별로 정렬 ORDER BY
 -- ** 주의 **
 -- UNION 할 대상의 조회내역은 개별적으로 ORDER BY 를 할 수 없다.
  SELECT '판매'					AS TITLE
	   ,A.DATE					AS DATE
	   ,B.ID					AS CUST_ID
	   ,B.NAME                  AS NAME
	   ,A.FRUIT_NAME			AS FRUIT_NAME
	   ,A.AMOUNT				AS AMOUNT
	   ,A.AMOUNT * C.UNITPRICE  AS INOUTPRICE
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID
					  LEFT JOIN T_Fruit C
							 ON A.FRUIT_NAME = C.FRUIT_NAME
  UNION

 -- 거래처에 발주한 내역
 SELECT '발주'							 AS TITLE
	   ,DATE							 AS DATE
	   ,A.CUSTCODE                       AS CUST_ID
	   ,CASE A.CUSTCODE WHEN 1 THEN '대림'	
					    WHEN 2 THEN '삼전'
					    WHEN 3 THEN '하나'
					    END				 AS NAME
	   ,A.FRUIT_NAME					 AS FRUIT_NAME
	   ,A.AMOUNT						 AS AMOUNT
	   ,A.AMOUNT * -C.ORDER_PRICE		 AS INOUTPRICE
   FROM TB_OrderList A LEFT JOIN T_Fruit C
							  ON A.FRUIT_NAME = C.FRUIT_NAME

ORDER BY A.DATE; -- 전체 UNION의 정렬

/************** 실습 ******************
 두가지 방법으로 과일가게의 일자별 마진 금액을 산출하세요.
 * 위의 UNION 방법을 사용하고 구할 것
 * UNION 을 쓰지 말고 구할 것

 * 마진 금액 : 판매한 금액 - 발주 금액
 * 표현할 컬럼 : DATE,	MARGIN */
 SELECT DATE AS DATE,
		SUM(X.INPRICE-X.OUTPRICE)	AS MARGIN
	FROM ( SELECT DATE AS DATE,
					A.AMOUNT * C.UNITPRICE  AS INPRICE
			   FROM TB_SaleList A LEFT JOIN TB_Cust B
										 ON A.CUST_ID = B.ID
								  LEFT JOIN T_Fruit C
										 ON A.FRUIT_NAME = C.FRUIT_NAME
			
			UNION

			SELECT DATE AS DATE,
					A.AMOUNT * -C.ORDER_PRICE		 AS OUTPRICE
			   FROM TB_OrderList A LEFT JOIN T_Fruit C
										  ON A.FRUIT_NAME = C.FRUIT_NAME) X
GROUP BY DATE
ORDER BY DATE;

-- REVIEW
-- 1. UNION을 써서 구하기
SELECT A.DATE
	  ,SUM(A.INOUTPRICE) AS INOUTPRICE
FROM (SELECT A.DATE AS DATE
			,A.AMOUNT * C.UNITPRICE AS INOUTPRICE
		FROM TB_SaleList A LEFT JOIN TB_CUST B
								  ON A.CUST_ID = B.ID
						   LEFT JOIN T_FRUIT C
								  ON A.FRUIT_NAME = C.FRUIT_NAME
	   UNION
	  SELECT A.DATE AS DATE
	        ,A.AMOUNT * -C.ORDER_PRICE AS INOUTPRICE
		FROM TB_OrderList A LEFT JOIN T_Fruit C
								   ON A.FRUIT_NAME = C.FRUIT_NAME ) A
GROUP BY A.DATE;

-- 2. UNION을 쓰지 않고 구하기
-- 1) SALES LIST의 일자별 이윤 구하기
SELECT A.DATE
	  ,SUM(A.AMOUNT * B.UNITPRICE) AS SALES_PRICE
  FROM TB_SaleList A LEFT JOIN T_Fruit B
							ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

 -- 2) ORDER LIST의 일자별 발주금액 구하기
  SELECT A.DATE
 	    ,SUM(A.AMOUNT * -B.ORDER_PRICE) AS ORDER_PRICE
    FROM TB_OrderList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
GROUP BY A.DATE;

-- 3) 일자별 판매금액과 일자별 발주 금액 합하기
SELECT A.DATE						 AS DATE
	  ,ISNULL(A.SALES_PRICE,0) + ISNULL(B.ORDER_PRICE,0) AS MARGIN
  FROM (SELECT A.DATE
			  ,SUM(A.AMOUNT * B.UNITPRICE) AS SALES_PRICE
		  FROM TB_SaleList A LEFT JOIN T_Fruit B
									ON A.FRUIT_NAME = B.FRUIT_NAME
		 GROUP BY A.DATE) A LEFT JOIN ( SELECT A.DATE
								     	  ,SUM(A.AMOUNT * -B.ORDER_PRICE) AS ORDER_PRICE
								          FROM TB_OrderList A LEFT JOIN T_Fruit B
								     		   					     ON A.FRUIT_NAME = B.FRUIT_NAME
								      GROUP BY A.DATE) B
								   ON A.DATE = B.DATE
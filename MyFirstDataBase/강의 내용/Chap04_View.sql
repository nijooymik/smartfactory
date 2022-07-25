/*
 - VIEW

 . 자주 사용되는 SELECT 구문을 미리 만들어두고, 테이블처럼 호출할 수 있도록 만든 기능
 . SQL SERVER 의 VIEW 는 하나의 테이블로부터 특정 컬럼들만 보여주거나, 특정 조건에 맞는 행들만 보여주는데 사용될 수 있으며,
   두 개 이상의 테이블을 조인하여 하나의 VIEW 로 사용자에게 보여질 수 있다.
 . VIEW 자체는 테이블처럼 실제 데이터를 가지고 있지 않다. 단지 SELECT 문의 정의만을 가지고 있다.
 . 보안상의 이유로 테이블 중 일부 컬럼만 공개하고자 할 때 사용된다.

*/

-- VIEW 의 작성
/* 과일가게 일자별 판매, 발주한 리스트를 VIEW 형태로 만들고, VIEW 를 호출하여 데이터를 표현 */
CREATE VIEW V_FruitBusinessList AS

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

-- VIEW 를 통한 일자별 마진 금액 계산하기
SELECT DATE
	  ,SUM(INOUTPRICE) AS INOUTPRICE
  FROM V_FruitBusinessList
GROUP BY DATE;

/******** 실습 **********
과일가게 관리 테이블 (T_Fruit, TB_OrderList, TB_SaleList) 에서
일자별 총 판매금액 (V_DAY_SALELIST) 와
일자별 총 발주금액 (V_DAY_ORDERLIST) SELECT 문을 VIEW 형태로 만들고
생성한 VIEW 를 통해 거래(판매, 발주)된 내역의 전체 마진을 구하세요. 컬럼 : TOTALMARGIN */

CREATE VIEW V_DAY_SALELIST AS
   SELECT A.DATE
	     ,SUM(A.AMOUNT * B.UNITPRICE) AS SALES_PRICE
     FROM TB_SaleList A LEFT JOIN T_Fruit B
							ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

CREATE VIEW V_DAY_ORDERLIST AS
  SELECT A.DATE
 	    ,SUM(A.AMOUNT * -B.ORDER_PRICE) AS ORDER_PRICE
    FROM TB_OrderList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
GROUP BY A.DATE;

SELECT SUM(SALES_PRICE) AS TOTALMARGIN
  FROM V_DAY_SALELIST
SELECT SUM(ORDER_PRICE) AS TOTALMARGIN
  FROM V_DAY_ORDERLIST

-- REVIEW
-- 1. SIMPLE
SELECT SUM(SALES_PRICE) + (SELECT SUM(ORDER_PRICE) FROM V_DAY_ORDERLIST)
  FROM V_DAY_SALELIST;
-- 2. JOIN
 SELECT SUM(ISNULL(A.SALES_PRICE,0) + ISNULL(B.ORDER_PRICE,0)) AS TOTALMARGIN
  FROM V_DAY_SALELIST A LEFT JOIN V_DAY_ORDERLIST B
							   ON A.DATE = B.DATE;
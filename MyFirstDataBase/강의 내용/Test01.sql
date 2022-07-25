/*
1. TB_StockMMrec(자재 재고 이력) 테이블 에는 있고 TB_StockMM(자재 재고) 테이블 에는 없는 MATLOTNO 를 찾아보는 SQL 문을 작성하고
 아래 에 SQL 문과 결과의 사진을 첨부하세요.  * 결과의 조회 컬럼은 임의로 설정해도 무관함.
*/
SELECT *
  FROM TB_StockMMrec
 WHERE MATLOTNO NOT IN (SELECT MATLOTNO
					      FROM TB_StockMM);
-- REVIEW
 SELECT *
   FROM TB_StockMMrec 
  WHERE MATLOTNO NOT IN (SELECT MATLOTNO
						   FROM TB_StockMM);
--------------------------------------
/*
2. TB_StockMM(자재재고) 테이블에서 STOCKQTY 가 5000 보다 작은 MATLOTNO 의 값(1)으로 TB_StockMMrec(자재재고이력)테이블 에서     
MATLOTNO 가 값(1) 인 ITEMCODE 값(2) 를 찾아낸후  값(2) 의 ITEMCODE 의 정보를 TB_ItemMaster(품목관리) 테이블 에서 조회하여     
ITEMCODE,ITEMNAME,MAXSTOCK,BASEUNIT 컬럼으로 검색 하는 SQL 내용을 아래 에 기술하고 결과의 사진을 첨부하세요.
*/
SELECT ITEMCODE
	  ,ITEMNAME
	  ,MAXSTOCK
	  ,BASEUNIT
  FROM TB_ItemMaster
 WHERE ITEMCODE IN (SELECT ITEMCODE
					 FROM TB_StockMMrec
					WHERE MATLOTNO IN (SELECT MATLOTNO
										FROM TB_StockMM
									   WHERE STOCKQTY < 5000))
-- REVIEW
-- 단계 1
-- 자재 재고 테이블에서 STOCKQTY 가 5000 보다 작은 MATLOTNO
SELECT MATLOTNO
  FROM TB_StockMM
 WHERE STOCKQTY < 5000

-- 단계 2
-- 1단계의 값을 가진 자재 재고 이력 테이블의 ITEMCODE 를 찾아내기
SELECT ITEMCODE
  FROM TB_StockMMrec
 WHERE MATLOTNO IN (SELECT MATLOTNO
					  FROM TB_StockMM
					 WHERE STOCKQTY < 5000)


-- 단계 3
-- 2단계에서 나온 ITEMCODE 결과값을 가진 품목마스터 테이블의 품목 정보 조회
SELECT ITEMCODE
	  ,ITEMNAME
	  ,MAXSTOCK
	  ,BASEUNIT
  FROM TB_ItemMaster
 WHERE ITEMCODE IN (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE MATLOTNO IN (SELECT MATLOTNO
										  FROM TB_StockMM
										 WHERE STOCKQTY < 5000))
-------------------------------------
  SELECT INOUTDATE
  	    ,WHCODE
  	    ,COUNT(*) AS CNT
    FROM TB_StockMMrec
   WHERE INOUTQTY > 1000
     AND INOUTFLAG = 'I'
GROUP BY INOUTDATE,WHCODE
  HAVING COUNT(*) >=2
ORDER BY INOUTDATE;
/*
3. 위의 내용의 결과를 HAVING 을 사용하지 않고 같은 결과를 도출해 보세요.															
*/
  SELECT INOUTDATE
  	    ,WHCODE
  	    ,COUNT(*) AS CNT
    FROM TB_StockMMrec
   WHERE INOUTQTY > 1000
     AND INOUTFLAG = 'I'
	 AND COUNT(*) >= 2
GROUP BY INOUTDATE,WHCODE
ORDER BY INOUTDATE;

-- REVIEW
SELECT *
  FROM (  SELECT INOUTDATE
		   	    ,WHCODE
		   	    ,COUNT(*) AS CNT
		    FROM TB_StockMMrec
		   WHERE INOUTQTY > 1000
		     AND INOUTFLAG = 'I'
		GROUP BY INOUTDATE, WHCODE ) A
WHERE A.CNT >= 2;
-------------------------------------
/*
4. 실습 에 사용된 테이블 (TB_CUST(고객 관리), T_FRUIT(과일관리), TB_SALELIST(판매 이력) 테이블과 데이터를 사용하여															
2022-06-11 일 부터 2022-06-13 일 까지의 총 구매 금액이 가장 큰 고객을 구하고
해당 고객이 구매했던 모든 이력을 다음과 같이 표현하세요. (결과 사진 첨부할것)
고객ID,  고객이름,  일자,    과일,       구매수량,  구매금액
*/
  SELECT A.CUST_ID
   		,C.NAME
   		,A.DATE
   		,A.FRUIT_NAME
   		,A.AMOUNT
   		,SUM(A.AMOUNT * B.UNITPRICE) AS BUYPRICE
   	FROM TB_SaleList A LEFT JOIN T_Fruit B
   							  ON A.FRUIT_NAME = B.FRUIT_NAME
   					  RIGHT JOIN TB_CUST C
   							  ON A.CUST_ID = C.ID
   WHERE A.CUST_ID IN (SELECT TOP (1) A.CUST_ID
   							 FROM TB_SaleList A LEFT JOIN T_Fruit B
   											           ON A.FRUIT_NAME = B.FRUIT_NAME
   											   RIGHT JOIN TB_CUST C
   													   ON A.CUST_ID = C.ID
   						    WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
   					     GROUP BY A.CUST_ID
   					     ORDER BY SUM(A.AMOUNT * B.UNITPRICE) DESC)
GROUP BY A.CUST_ID 
		,C.NAME
		,A.DATE
		,A.FRUIT_NAME
		,A.AMOUNT
ORDER BY A.DATE;

-- REVIEW
-- 1단계
-- 11일부터 13일까지 고객별 총 구매금액 산출
SELECT A.CUST_ID
	  ,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
  FROM TB_SaleList A LEFT JOIN T_Fruit B
							ON A.FRUIT_NAME = B.FRUIT_NAME
 WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
GROUP BY A.CUST_ID

-- 2단계
-- 총 구매 금액이 가장 큰 한 사람 구하기
SELECT TOP 1 A.CUST_ID
			,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
	  FROM TB_SaleList A LEFT JOIN T_Fruit B
									   ON A.FRUIT_NAME = B.FRUIT_NAME
	 WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
  GROUP BY A.CUST_ID
  ORDER BY FRUIT_PRICE DESC;

-- 3단계
-- 도출한 구매금액이 가장 큰 사람의 구매 이력 구하기
SELECT A.DATE,
	   C.NAME,
	   A.AMOUNT,
	   A.AMOUNT * D.UNITPRICE AND FRUIT_SALE_PRICE
  FROM TB_SaleList A JOIN (SELECT TOP 1 A.CUST_ID
						   			 ,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
						   		 FROM TB_SaleList A LEFT JOIN T_Fruit B
						   								   ON A.FRUIT_NAME = B.FRUIT_NAME
						   	    WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
						     GROUP BY A.CUST_ID
						     ORDER BY FRUIT_PRICE DESC) B
					   ON A.CUST_ID = B.CUST_ID -- 구매금액이 가장 큰 사람의 구매 이력 조회
			    LEFT JOIN TB_CUST C
					   ON A.CUST_ID = C.ID -- 구매 고객 정보를 도출하기 위한 고객 정보 테이블 JOIN
				LEFT JOIN T_Fruit D
					   ON A.FRUIT_NAME = D.FRUIT_NAME; -- 구매 리스에 있는 과일의 구매 금액을 산출하기 위해 과일 정보
													-- 테이블 JOIN
/*
1. TB_StockMMrec(���� ��� �̷�) ���̺� ���� �ְ� TB_StockMM(���� ���) ���̺� ���� ���� MATLOTNO �� ã�ƺ��� SQL ���� �ۼ��ϰ�
 �Ʒ� �� SQL ���� ����� ������ ÷���ϼ���.  * ����� ��ȸ �÷��� ���Ƿ� �����ص� ������.
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
2. TB_StockMM(�������) ���̺��� STOCKQTY �� 5000 ���� ���� MATLOTNO �� ��(1)���� TB_StockMMrec(��������̷�)���̺� ����     
MATLOTNO �� ��(1) �� ITEMCODE ��(2) �� ã�Ƴ���  ��(2) �� ITEMCODE �� ������ TB_ItemMaster(ǰ�����) ���̺� ���� ��ȸ�Ͽ�     
ITEMCODE,ITEMNAME,MAXSTOCK,BASEUNIT �÷����� �˻� �ϴ� SQL ������ �Ʒ� �� ����ϰ� ����� ������ ÷���ϼ���.
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
-- �ܰ� 1
-- ���� ��� ���̺��� STOCKQTY �� 5000 ���� ���� MATLOTNO
SELECT MATLOTNO
  FROM TB_StockMM
 WHERE STOCKQTY < 5000

-- �ܰ� 2
-- 1�ܰ��� ���� ���� ���� ��� �̷� ���̺��� ITEMCODE �� ã�Ƴ���
SELECT ITEMCODE
  FROM TB_StockMMrec
 WHERE MATLOTNO IN (SELECT MATLOTNO
					  FROM TB_StockMM
					 WHERE STOCKQTY < 5000)


-- �ܰ� 3
-- 2�ܰ迡�� ���� ITEMCODE ������� ���� ǰ�񸶽��� ���̺��� ǰ�� ���� ��ȸ
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
3. ���� ������ ����� HAVING �� ������� �ʰ� ���� ����� ������ ������.															
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
4. �ǽ� �� ���� ���̺� (TB_CUST(�� ����), T_FRUIT(���ϰ���), TB_SALELIST(�Ǹ� �̷�) ���̺�� �����͸� ����Ͽ�															
2022-06-11 �� ���� 2022-06-13 �� ������ �� ���� �ݾ��� ���� ū ���� ���ϰ�
�ش� ���� �����ߴ� ��� �̷��� ������ ���� ǥ���ϼ���. (��� ���� ÷���Ұ�)
��ID,  ���̸�,  ����,    ����,       ���ż���,  ���űݾ�
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
-- 1�ܰ�
-- 11�Ϻ��� 13�ϱ��� ���� �� ���űݾ� ����
SELECT A.CUST_ID
	  ,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
  FROM TB_SaleList A LEFT JOIN T_Fruit B
							ON A.FRUIT_NAME = B.FRUIT_NAME
 WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
GROUP BY A.CUST_ID

-- 2�ܰ�
-- �� ���� �ݾ��� ���� ū �� ��� ���ϱ�
SELECT TOP 1 A.CUST_ID
			,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
	  FROM TB_SaleList A LEFT JOIN T_Fruit B
									   ON A.FRUIT_NAME = B.FRUIT_NAME
	 WHERE A.DATE BETWEEN '2022-06-11' AND '2022-06-13'
  GROUP BY A.CUST_ID
  ORDER BY FRUIT_PRICE DESC;

-- 3�ܰ�
-- ������ ���űݾ��� ���� ū ����� ���� �̷� ���ϱ�
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
					   ON A.CUST_ID = B.CUST_ID -- ���űݾ��� ���� ū ����� ���� �̷� ��ȸ
			    LEFT JOIN TB_CUST C
					   ON A.CUST_ID = C.ID -- ���� �� ������ �����ϱ� ���� �� ���� ���̺� JOIN
				LEFT JOIN T_Fruit D
					   ON A.FRUIT_NAME = D.FRUIT_NAME; -- ���� ������ �ִ� ������ ���� �ݾ��� �����ϱ� ���� ���� ����
													-- ���̺� JOIN
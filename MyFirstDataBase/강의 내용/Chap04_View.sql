/*
 - VIEW

 . ���� ���Ǵ� SELECT ������ �̸� �����ΰ�, ���̺�ó�� ȣ���� �� �ֵ��� ���� ���
 . SQL SERVER �� VIEW �� �ϳ��� ���̺�κ��� Ư�� �÷��鸸 �����ְų�, Ư�� ���ǿ� �´� ��鸸 �����ִµ� ���� �� ������,
   �� �� �̻��� ���̺��� �����Ͽ� �ϳ��� VIEW �� ����ڿ��� ������ �� �ִ�.
 . VIEW ��ü�� ���̺�ó�� ���� �����͸� ������ ���� �ʴ�. ���� SELECT ���� ���Ǹ��� ������ �ִ�.
 . ���Ȼ��� ������ ���̺� �� �Ϻ� �÷��� �����ϰ��� �� �� ���ȴ�.

*/

-- VIEW �� �ۼ�
/* ���ϰ��� ���ں� �Ǹ�, ������ ����Ʈ�� VIEW ���·� �����, VIEW �� ȣ���Ͽ� �����͸� ǥ�� */
CREATE VIEW V_FruitBusinessList AS

SELECT '�Ǹ�'					AS TITLE
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

 -- �ŷ�ó�� ������ ����
 SELECT '����'							 AS TITLE
	   ,DATE							 AS DATE
	   ,A.CUSTCODE						 AS CUSTCODE
	   ,CASE A.CUSTCODE WHEN 1 THEN '�븲'	
					    WHEN 2 THEN '����'
					    WHEN 3 THEN '�ϳ�'
					    END				 AS NAME
	   ,A.FRUIT_NAME					 AS FRUIT_NAME
	   ,A.AMOUNT						 AS AMOUNT
	   ,A.AMOUNT * -C.ORDER_PRICE		 AS INOUTPRICE
   FROM TB_OrderList A LEFT JOIN T_Fruit C
							  ON A.FRUIT_NAME = C.FRUIT_NAME

-- VIEW �� ���� ���ں� ���� �ݾ� ����ϱ�
SELECT DATE
	  ,SUM(INOUTPRICE) AS INOUTPRICE
  FROM V_FruitBusinessList
GROUP BY DATE;

/******** �ǽ� **********
���ϰ��� ���� ���̺� (T_Fruit, TB_OrderList, TB_SaleList) ����
���ں� �� �Ǹűݾ� (V_DAY_SALELIST) ��
���ں� �� ���ֱݾ� (V_DAY_ORDERLIST) SELECT ���� VIEW ���·� �����
������ VIEW �� ���� �ŷ�(�Ǹ�, ����)�� ������ ��ü ������ ���ϼ���. �÷� : TOTALMARGIN */

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
 /*
	1. ���̺� ������ ���� �� ��ȸ(JOIN)
	JOIN : �� �̻��� ���̺��� �����ؼ� �����͸� �˻��ϴ� ���
		   ���̺��� ���� �����ϱ� ���ؼ��� �ϳ� �̻��� �÷��� �����ϰ� �־�� ��
	  ON : �� ���̺��� ������ ���� �÷� ���� ��ɾ�

	- ���� ���� (INNER JOIN) : JOIN
	- �ܺ� ���� (OUTER JOIN) : LEFT JOIN, RIGHT JOIN, FULL JOIN
 */

 -- JOIN
 -- �������� �κи� ��ȸ�Ǵ� ���� ��

 /* TB_CUST ���̺�� TB_SaleList ���̺���
	���� (TB_CUST) ID, (TB_SaleList) CUST_ID ���� ������ �����͸� ������
	�� ID, ���̸�, �Ǹ�����, ����, �Ǹż����� ǥ�� */

 -- ** ����� ǥ���� JOIN ���� ON

 -- �Ǹ� ��Ȳ ����Ʈ ���̺��� �������� �� ������ JOIN �� ���
 SELECT CUST_ID,				-- �� ID
		''		AS CUST_NAME,	-- �� ��
		DATE,					-- �Ǹ�����
		FRUIT_NAME,				-- �����̸�
		AMOUNT					-- �Ǹż���
   FROM TB_SALELIST A JOIN TB_CUST B
						ON A.CUST_ID = B.ID;

 -- �� ������ �������� ��ȸ
 -- �Ʒ��� ���ó�� �� ������ ���� ��Ÿ����.

 SELECT A.ID
	   ,A.NAME
   FROM TB_Cust A

 -- ������ ���̺��� ���� ���̺�� �ϰ� �Ǹ� ��Ȳ ���̺��� ���� ���̺�� �� �� 
 -- JOIN �Ͽ����� �������̺� �ִ� �����Ͱ� ��Ÿ���� �ʴ� ��찡 �����.
 SELECT A.ID
	   ,A.NAME
	   ,B.DATE
	   ,B.FRUIT_NAME
	   ,B.AMOUNT
   FROM TB_CUST A JOIN TB_SALELIST B
					ON A.ID = B.CUST_ID

 -- *** JOIN : �������� �κи� ��ȸ�Ǹ�
 -- ����Ǵ� ���̺� �� �����ϴ� Į���� �����Ͱ� �Ѵ� �����ؾ� �����͸� ��Ÿ����.

 -- ������ ǥ���� : JOIN ON ���� ���� �ʰ� ���̺� ���� �� ������ �÷��� �����ϴ� ���
 SELECT A.ID		 AS ID
	   ,A.NAME		 AS CUSTNAME
	   ,B.FRUIT_NAME AS FRUIT_NAME
   FROM TB_Cust		A 
	   ,TB_SaleList B -- INNER JOIN (JOIN)
  WHERE A.ID = B.CUST_ID

 -- �ܺ� JOIN (LEFT JOIN, RIGHT JOIN)
 
 -- ** LEFT JOIN
 --  . ���ʿ� �ִ� ���̺��� �����͸� �������� �����ʿ� �ִ� ���̺��� �����͸� �˻��ϰ�
 --	   ������ ���̺� �����Ͱ� ���� ��� NULL �� ǥ�õȴ�.
 
 /* ���ʿ� �ִ� TB_SalesList �� ������ �������� �Ǹ� ��Ȳ �� �� ������ ��Ÿ������. */
 SELECT A.DATE		 -- �Ǹ�����
	   ,A.CUST_ID	 -- �� ID
	   ,B.NAME		 -- �� ��
	   ,A.FRUIT_NAME -- ���ϸ�
	   ,A.AMOUNT	 -- �Ǹż���
   FROM TB_SaleList A LEFT JOIN TB_CUST B -- LEFT OUTER JOIN
							 ON A.CUST_ID = B.ID

 -- ** RIGHT JOIN (RIGHT INNER JOIN)
 -- �����ʿ� �ִ� ���̺��� �����͸� �������� ���ʿ� �ִ� ���̺��� �����͸� �˻��ϰ�
 -- ���� ���̺� �����Ͱ� ���� ��� NULL �� ǥ�õȴ�. (JEFT JOIN �� �ݴ�)

 /* �����ʿ� �ִ� TB_Cust �� ������ �������� �� �� �Ǹ� ��Ȳ�� ��Ÿ������. */
 SELECT B.ID		 -- ��
	   ,B.NAME		 -- �� ��
	   ,A.DATE		 -- �Ǹ�����
	   ,A.FRUIT_NAME -- ���ϸ�
	   ,A.AMOUNT	 -- ����
 FROM TB_SaleList A RIGHT JOIN TB_Cust B
							  ON A.CUST_ID = B.ID;

 -- ** ���� JOIN
 -- ������ �����Ͱ� ���� ���̺� ���� �� ���� ���̺�� ���� ���̺���� ���� JOIN ���� �����͸� �˻��� �� �ִ�.
 
 /* �Ǹ� ��Ȳ�� �Ǹ�����, ���̸�, �� ����ó, �ǸŰ���, ���ϴܰ�, �Ǹűݾ� ���� ��Ÿ������. */

 SELECT A.DATE				   AS SALEDATE    -- �Ǹ�����
	   ,B.NAME				   AS CUSTNAME    -- ���̸�
	   ,B.PHONE				   AS CUSTPHONE   -- �� ����ó
	   ,A.FRUIT_NAME		   AS FRUITNAME   -- �Ǹ� ����
	   ,C.UNITPRICE			   AS UNITPRICE   -- ���ϴܰ�
	   ,A.AMOUNT			   AS AMOUNT	  -- �Ǹż���
	   ,C.UNITPRICE * A.AMOUNT AS SALES_PRICE -- �Ǹűݾ�
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID			
					  LEFT JOIN T_Fruit C
							 ON A.FRUIT_NAME = C.FRUIT_NAME;

 /****** �ǽ� *******
	TB_StockMMrec (���� ���� �̷�) A ���̺��� ITEMCODE �� NULL �� �ƴϰ�, INOUTFLAG (���⿩��) = 'I' (�԰�)
	TB_ItemMaster (ǰ�� ������) B ���̺��� ITEMTYPE (ǰ��Ÿ��) �� 'HALB' �� ����
	A.INOUTDATE,	A.INOUTSEQ,		A.MATLOTNO,		,A.ITEMCODE,	B.ITEMNAME,		B.CARTYPE ������ ��Ÿ������.
	(���� ����)		(�������)		(LOT ��ȣ)		(ǰ���ڵ�)		(ǰ��)			(����)
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
							--AND B.ITEMTYPE = 'ROH' -- JOIN �� �ϱ� ���� TB_ItemMaster ���̺��� ���͸�
  WHERE A.ITEMCODE IS NOT NULL
    AND A.INOUTFLAG = 'I'
	AND B.ITEMTYPE = 'ROH'; -- JOIN ���Ŀ� �˻� ������� ���͸�

 -- ** ���������� JOIN

 /* ���� ������ �� ��� �ݾ� ���ϱ� (��ID, ����, �����̸�, ���Ϻ��ѱ��űݾ�)
    . ���� ������ ���� ���� ID�� �̸��� ǥ�� */


 -- ���� ����
 -- 1. ���� ���̺� ����(����) -- ���� ������ �� ���� ��Ȳ�̹Ƿ� �� ���̺��� ������ �ȴ�. TB_Cust
 -- 2. ���� ���Ϻ� �� �Ǹż����� ���Ѵ�.
  SELECT CUST_ID	    AS CUSTID	  -- �� ID
 	    ,FRUIT_NAME  AS FRUITNAME  -- ��������
 	    ,SUM(AMOUNT) AS FRUITCOUNT -- ���� �Ǹ� ����
    FROM TB_SaleList
GROUP BY CUST_ID,FRUIT_NAME;

 -- 3. ���� ������ �� �Ǹ� ������ �ܰ��� ���Ѵ�.
 -- **** SELECT ������ ���̺�ó�� FROM ������ ����ϱ�
 SELECT A.CUSTID				   AS CUSTID
	   ,A.FRUITNAME				   AS FRUITNAME
	   ,A.FRUITCOUNT * B.UNITPRICE AS FRUIT_TOTAL_PRICE
   FROM (SELECT CUST_ID	    AS CUSTID	  -- �� ID
	  		   ,FRUIT_NAME  AS FRUITNAME  -- ��������
 		       ,SUM(AMOUNT) AS FRUITCOUNT -- ���� �Ǹ� ����
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
							    FROM (SELECT CUST_ID	 AS CUSTID	   -- �� ID
							    			,FRUIT_NAME  AS FRUITNAME  -- ��������
							  				,SUM(AMOUNT) AS FRUITCOUNT -- ���� �Ǹ� ����
							  		    FROM TB_SaleList
									GROUP BY CUST_ID,FRUIT_NAME) A LEFT JOIN T_Fruit B
							  											  ON A.FRUITNAME = B.FRUIT_NAME) BB
						  ON AA.ID = BB.CUSTID;

 -- �����ϰ� �ٿ��� ����
 -- 1. ���� ���Ϻ� �� ���� ���ϱ�
  SELECT CUST_ID,					-- �� ID
 	     FRUIT_NAME,					-- ���� �̸�
	     SUM(AMOUNT) AS FRUIT_AMOUNT -- ���Ϻ� �� ���� ����
    FROM TB_SaleList
GROUP BY CUST_ID, FRUIT_NAME

 -- 2. �ܰ��� ���ż����� ���ļ� �� �ݾ� ����
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

/********** �ǽ� ***************
 ���ϰ��� ���� �� �ݾ��� ���ϼ���. �Ǹ� ������ ���� ���� ǥ������ �ʾƵ� ��. */
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

/****** �ǽ� **************
���� �� ���� �ݾ��� ���� ū ���� ��Ÿ������. (�� ID, ���̸�, �ѱ��űݾ�) */
  SELECT TOP (1) A.CUST_ID
				,C.NAME
				,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   RIGHT JOIN TB_CUST C
							   ON A.CUST_ID = C.ID
GROUP BY A.CUST_ID, C.NAME
ORDER BY FRUIT_PRICE DESC;

/****** �ǽ� **************
���� �� ���� �ݾ��� 40000���� �Ѵ� ���� ������ �˻��ϼ���. (�� ID, ���̸�, �ѱ��űݾ�) */
  SELECT A.CUST_ID
		,C.NAME
		,SUM(A.AMOUNT * B.UNITPRICE) AS FRUIT_PRICE
    FROM TB_SaleList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
					   LEFT JOIN TB_CUST C
							   ON A.CUST_ID = C.ID
GROUP BY A.CUST_ID, C.NAME
  HAVING SUM(A.AMOUNT * B.UNITPRICE) > 40000;

 /******** �ǽ� ***************
 2022-06-13 �Ϻ��� 2022-06-14 �ϱ����� ���� �� ���� �ݾ��� ���Ͻÿ�. (�� ID, ���̸�, �ѱ��űݾ�) */
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
   - �ټ��� �˻� ���� ����
     . �˻��� ����� ���� �� ���� �� ����

   UNION	 : �ߺ��Ǵ� �����ʹ� �պ��Ͽ� ǥ��
   UNION ALL : �����͸� ��� ǥ��

   ** �պ��� �÷��� ������ ���İ� �÷��� ���� ��ġ�ؾ� �Ѵ�. */

 SELECT DATE	   AS DATE
	   ,CUST_ID	   AS CUSTID
	   ,FRUIT_NAME AS FRUITNAME
	   ,AMOUNT	   AS AMOUNT
   FROM TB_SaleList -- �� �Ǹ� ��Ȳ ����Ʈ 8

 UNION ALL

 SELECT DATE	   AS DATE
	   ,CUSTCODE   AS CUSTCODE
	   ,FRUIT_NAME AS FRUIT_NAME
	   ,AMOUNT	   AS AMOUNT
   FROM TB_OrderList -- �ŷ�ó ���� ��Ȳ ����Ʈ 6

 -- UNION ���� ���� �� 6�� 12�� ����� �ֹ� �ŷ�ó�ڵ�� �ֹ�����, ������ ��ġ�Ͽ� �ߺ�

 -- ** �Ǹ� ����/���� �������� Ȯ���ϱ� ���Ͽ� TITLE �� �����Ͽ��� ���

 SELECT '�Ǹ�'			AS TITLE
	   ,A.DATE			AS DATE
	   ,A.CUST_ID		AS CUST_ID
	   ,A.FRUIT_NAME	AS FRUIT_NAME
	   ,A.AMOUNT		AS AMOUNT
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID

  UNION

 SELECT '����'		AS TITLE
	   ,DATE		AS DATE
	   ,CUSTCODE	AS CUSTCODE	
	   ,FRUIT_NAME	AS FRUIT_NAME
	   ,AMOUNT		AS AMOUNT
   FROM TB_OrderList

 -- ����, �ŷ�ó������ ǥ���ϰ� ���� ��� 
 -- JOIN, �����Է�

 -- ���� ������ ����
 SELECT '�Ǹ�'			AS TITLE
	   ,A.DATE			AS DATE
	   ,A.CUST_ID		AS CUST_ID
	   ,B.NAME         AS NAME
	   ,A.FRUIT_NAME	AS FRUIT_NAME
	   ,A.AMOUNT		AS AMOUNT
   FROM TB_SaleList A LEFT JOIN TB_Cust B
							 ON A.CUST_ID = B.ID

  UNION

 -- �ŷ�ó�� ������ ����
 SELECT '����'							 AS TITLE
	   ,DATE							 AS DATE
	   ,CUSTCODE                     AS CUST_ID
	   ,CASE CUSTCODE WHEN 1 THEN '�븲'	
					  WHEN 2 THEN '����'
					  WHEN 3 THEN '�ϳ�'
					  END				 AS NAME
	   ,FRUIT_NAME						 AS FRUIT_NAME
	   ,AMOUNT							 AS AMOUNT
   FROM TB_OrderList

 /************* �ǽ� ************
 ���� ������ �Ǹ� ������ ������ ������ �� ���ֱݾװ� �Ǹűݾ��� �߰��Ͽ� ǥ���ϼ���
 ���ֱݾ�(ORDER_PRICE * �ֹ�����(AMOUNT)), �Ǹűݾ�(PRICE * ���ż���(AMOUNT))
 *�÷� �̸��� INOUTPRICE
 *���� �ݾ��� -�� ǥ�� */
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

 -- ** ��ȸ ��� ���ں��� ���� ORDER BY
 -- ** ���� **
 -- UNION �� ����� ��ȸ������ ���������� ORDER BY �� �� �� ����.
  SELECT '�Ǹ�'					AS TITLE
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

 -- �ŷ�ó�� ������ ����
 SELECT '����'							 AS TITLE
	   ,DATE							 AS DATE
	   ,A.CUSTCODE                       AS CUST_ID
	   ,CASE A.CUSTCODE WHEN 1 THEN '�븲'	
					    WHEN 2 THEN '����'
					    WHEN 3 THEN '�ϳ�'
					    END				 AS NAME
	   ,A.FRUIT_NAME					 AS FRUIT_NAME
	   ,A.AMOUNT						 AS AMOUNT
	   ,A.AMOUNT * -C.ORDER_PRICE		 AS INOUTPRICE
   FROM TB_OrderList A LEFT JOIN T_Fruit C
							  ON A.FRUIT_NAME = C.FRUIT_NAME

ORDER BY A.DATE; -- ��ü UNION�� ����

/************** �ǽ� ******************
 �ΰ��� ������� ���ϰ����� ���ں� ���� �ݾ��� �����ϼ���.
 * ���� UNION ����� ����ϰ� ���� ��
 * UNION �� ���� ���� ���� ��

 * ���� �ݾ� : �Ǹ��� �ݾ� - ���� �ݾ�
 * ǥ���� �÷� : DATE,	MARGIN */
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
-- 1. UNION�� �Ἥ ���ϱ�
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

-- 2. UNION�� ���� �ʰ� ���ϱ�
-- 1) SALES LIST�� ���ں� ���� ���ϱ�
SELECT A.DATE
	  ,SUM(A.AMOUNT * B.UNITPRICE) AS SALES_PRICE
  FROM TB_SaleList A LEFT JOIN T_Fruit B
							ON A.FRUIT_NAME = B.FRUIT_NAME
 GROUP BY A.DATE;

 -- 2) ORDER LIST�� ���ں� ���ֱݾ� ���ϱ�
  SELECT A.DATE
 	    ,SUM(A.AMOUNT * -B.ORDER_PRICE) AS ORDER_PRICE
    FROM TB_OrderList A LEFT JOIN T_Fruit B
							  ON A.FRUIT_NAME = B.FRUIT_NAME
GROUP BY A.DATE;

-- 3) ���ں� �Ǹűݾװ� ���ں� ���� �ݾ� ���ϱ�
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
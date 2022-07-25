/* 1. �����͸� �����ϴ� �� ��ȸ (LIKE)
   WHERE ���ǿ� �˻��ϰ��� �ϴ� �������� �Ϻκи� �Է��Ͽ�
   �ش� ������ ���Ե� ��� �����͸� ǥ�� '%' */

-- TB_ItemMaster ���̺��� ITEMCODE �÷��� ������ �� 'E'�� ���Ե� �÷� �����͸� ��� ��ȸ
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '%E%' -- E �� �����ϰ� �ִ� ��� ������ ��ȸ

-- TB_ItemMaster ���̺��� ITEMCODE �÷��� ������ �� '64'�� �����ϴ� �����͸� ��� ��ȸ
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '64%'

-- TB_ItemMaster ���̺��� ITEMCODE �÷��� ������ �� '3X000E'�� ������ �����͸� ��� ��ȸ
SELECT *
  FROM TB_ItemMaster
 WHERE ITEMCODE LIKE '%3X000E'

/*****************************************************************************************
2. NULL ���� �ƴ� ������ ��ȸ �� NULL ���� ������ ��ȸ (IS NULL, IS NOT NULL)
   NULL : �����Ͱ� ���� ����ִ� ����. �����Ͱ� �Ҵ���� ���� ���� */

-- TB_ItemMaster ���̺��� MAXSTOCK �÷��� NULL �� �����͸� �˻�
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK IS NULL;


-- TB_ItemMaster ���̺��� MAXSTOCK �÷��� NULL �� �ƴ� ������ �˻�
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK IS NOT NULL;

 /********* �ǽ� ***************
 TB_ItemMaster ���̺��� 
 BOXSPEC �÷��� �����Ͱ� '01' �� �����鼭 NULL �� �ƴ� 
 PLANTCODE, ITEMCODE, ITEMNAME, �÷��� �����͸� �˻��ϼ���. */
SELECT PLANTCODE
      ,ITEMCODE
	  ,ITEMNAME
  FROM TB_ItemMaster
 WHERE BOXSPEC LIKE '%01'
   AND BOXSPEC IS NOT NULL;

/*****************************************************************************************
3. �˻� ��� ���� (ORDER BY ASC/DESC)
  ���̺��� �˻��� ����� ���ǿ� ���� �����Ͽ� ��Ÿ����.
  ������������ ������ ��� ASC, NULL ���� ���� �����Ͱ� �ֻ����� ��Ÿ����. */

/* TB_ItemMaster ���̺��� ITEMTYPE = 'HALB' �� 
   ITEMCODE, ITEMTYPE �÷��� �����͸� ITEMCODE �÷� ������ �������� �������� ��ȸ */
  SELECT ITEMCODE
	    ,ITEMTYPE
    FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
ORDER BY ITEMCODE ASC; -- ASC : �������� ��� ���� ����

-- ** ORDER BY ������ ���� �÷��� �� ��� ���ʺ��� ���������� �켱������ ������.
  SELECT ITEMCODE
	    ,ITEMTYPE
	    ,WHCODE
	    ,BOXSPEC
    FROM TB_ItemMaster
ORDER BY ITEMTYPE, WHCODE, BOXSPEC;

-- ** ��ȸ���� �ʴ� �÷��� ������ ���� ���� �߰��ϱ�
/* TB_ItemMaster ���̺��� ITEMTYPE = 'HALB' ��
   ITEMTYPE, WHCODE, BOXSPEC �÷���
   ITEMCODE ������� �����Ͽ� �˻� */
  SELECT ITEMTYPE
        ,WHCODE
	    ,BOXSPEC
    FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
ORDER BY ITEMCODE;

-- ** �������� �����ϱ� DESC
/* TB_ItemMaster ���̺��� ITEMTYPE = 'HALB' ��
   ITEMCODE
*/
  SELECT ITEMCODE
        ,ITEMTYPE
    FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
ORDER BY ITEMCODE DESC;

-- ** �÷� �� ��������, �������� ����

/* TB_ItemMaster ���̺��� INSFLAG �� NULL �� �ƴ�
   ITEMTYPE, WHCODE, INSFLAG �÷���
   ITEMTYPE ���� ��������, WHCODE ��������, INSFLAG �� ������������ ���� */
  SELECT ITEMTYPE
        ,WHCODE
	    ,INSPFLAG
    FROM TB_ItemMaster
   WHERE INSPFLAG IS NOT NULL
ORDER BY ITEMTYPE, WHCODE DESC, INSPFLAG;

/************ �ǽ� *****************
TB_ItemMaster ���̺���
MATERIALGRADE �÷��� ���� NULL �̰�
CARTYPE �÷����� MD,RB,TL �� �ƴϸ鼭
ITEMCODE �÷����� '001' �� �����ϰ�
UNITCOST �÷����� 0 �� ���� ��� �÷���
ITEMNAME �÷��� ��������, WHCODE �÷��� ������������ ��ȸ�ϼ���. */
  SELECT *
    FROM TB_ItemMaster
    WHERE MATERIALGRADE IS NULL
      AND CARTYPE NOT IN ('MD', 'RB', 'TL')
      AND ITEMCODE LIKE '%001%'
      AND UNITCOST = 0
 ORDER BY ITEMNAME DESC, WHCODE;

/*****************************************************************************************
4. ������ �պ��˻� (DISTINCT)
 �÷��� �����Ͱ� �ߺ��� ���� ��� �ߺ��� �����͸� �պ��Ͽ� �˻� */

-- TB_ItemMaster ���̺��� ITEMTYPE �� ��ȸ
 SELECT ITEMTYPE
   FROM TB_ItemMaster;

-- TB_ItemMaster ���̺��� ITEMTYPE �� �պ� �� �˻�
SELECT DISTINCT ITEMTYPE
  FROM TB_ItemMaster;

-- ** ���� �÷��� ��ȸ �� ��ȸ�ϴ� �÷��� ��� �ߺ��Ǵ� ������ �����ϴ� �����͸� ��ȸ�ȴ�.

/* TB_ItemMaster ���̺��� BASEUNIT = 'KG' ���� ���� ������ ��
   ITEMTYPE �� ITEMSPEC �� ���ÿ� �ߺ����� �ʴ� �պ��� �����͸� ��ȸ */
SELECT DISTINCT ITEMTYPE
			   ,ITEMSPEC
		   FROM TB_ItemMaster
		  WHERE BASEUNIT = 'KG'
	   ORDER BY ITEMSPEC;

/******* �ǽ� *************
TB_ItemMaster ���̺��� BOXSPEC �� 'DS-PLT'�� �����ϴ�
ITEMTYPE �� WHCODE �� ������ ��ȸ�ϼ���. */
SELECT DISTINCT ITEMTYPE
			   ,WHCODE
		   FROM TB_ItemMaster
		  WHERE BOXSPEC LIKE 'DS-PLT%';

/*****************************************************************************************
5. �˻��� ������ �� �����ϴ� ���� ������ ���ϱ� ( TOP (N) )
 . �˻������� �����ϴ� �� �߿� ���������� ������ ���� ������ ǥ��
   EX) �ҷ��� �߻� ǰ�� ���� TOP 10 ���� ������ �� ���� ��� */

-- ** ���� 10���� �����͸� �˻�
SELECT TOP (10) *
  FROM TB_ItemMaster;

-- ORDER BY �� ���Ͽ� ��������/������������ ��ȸ�� 5�� ���� ��ȸ
  SELECT TOP (5) *
  	FROM TB_ItemMaster
ORDER BY MAXSTOCK DESC;

-- ** �˻� ������ �Է��� ���� ������ ��ȸ
  SELECT TOP (8) *
    FROM TB_ItemMaster
   WHERE WHCODE = 'WH005'
ORDER BY MAXSTOCK DESC;


/******* �ǽ� *********
TB_StockMMrec ���̺��� INOUTFLAG �� 'O' �� ������ ��
INOUTDATE(��������) �� ���� �ֱ��� ������ ���� 10����
PLANTCODE, ITEMCODE, MATLOTNO, WHCODE, INOUTDATE, INOUTQTY �� ��ȸ�ϼ���. */
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
6. ������ �պ� �˻�2 (GROUP BY, HAVING, �����Լ�) : �߿䵵 *****
 . GROUP BY ���ǿ� ���� �ش� �÷���  �����͸� ����
 . GROUP BY �� ��ȸ�Ȱ������ ��ȸ ������ �־� �˻�(HAVING)
 . ���� �Լ��� ����Ͽ� ���յǴ� �����͸� ������ �� �ִ�. */

-- GROUP BY �� �⺻ ����
  SELECT ITEMCODE               -- 5. ITEMCODE �÷��� ��ȸ�϶�.
    FROM TB_ItemMaster          -- 1. TB_ItemMaster ���̺���
   WHERE ITEMTYPE = 'ROH'       -- 2. ITEMTYPE = 'ROH' ��� �����͸�
GROUP BY ITEMCODE               -- 3. ITEMCODE �÷� �������� �����ϰ�
  HAVING ITEMCODE LIKE '%3%'    -- 4. ���յ� ��� �� ITEMCODE �� 3 �� �����ϴ�
-- WHERE ���� HAVING ���� �������̹Ƿ� ������ ����

/* DISTINCT �� �ٸ� ��
 - DISTINCT
   . WHERE ������ �����ϴ� �ߺ��� ������ �����Ͽ� �˻�

 - GROUP BY
   . ���յ� �������� ����� ������ �ξ�(HAVING) HAVING �������� ��˻�
   . �����Լ��� ���� ����� �� �����ϴ�. */

-- ** DISTINCT 
/* TB_ItemMaster ���̺��� ITEMTYPE = 'HALB' �� �� �� �ߺ��� ������ ITEMSPEC
   �÷� �����ͷ� �˻� */

SELECT DISTINCT ITEMSPEC
  FROM TB_ItemMaster
 WHERE ITEMTYPE = 'HALB'
 
-- ** GROUP BY
/* TB_ItemMaster ���̺��� ITEMTYPE = 'HALB' �� �� �� 
   WHCODE�� �����Ͽ� �˻��ϰ�
   ��� �� WHCODE�� 'WH003' �� ������ �˻� */
   
  SELECT WHCODE
	FROM TB_ItemMaster
   WHERE ITEMTYPE = 'HALB'
GROUP BY WHCODE
  HAVING WHCODE = 'WH003';

 -- ** ���� GROUP BY �� ������ ��� �÷��� �ݵ�� SELECT ��ȸ �÷��� ���ԵǾ� �־�� �Ѵ�.
 
 /* TB_ItemMaster ���̺���
    ITEMSPEC �÷��� �����Ͽ� ����� ��Ÿ������ �ϳ�
	GROUP BY �� �� ��� ���ԵǾ� ���� �ʴ� �÷��� SELECT �ϴ� ��� */

  SELECT ITEMCODE
    FROM TB_ItemMaster
GROUP BY ITEMSPEC;	-- ���� �߻�

-- �������� �������� ����;
  SELECT ITEMSPEC
    FROM TB_ItemMaster
GROUP BY ITEMSPEC, WHCODE;

/* GROUP BY, HAVING ������ ����Ͽ� TB_StockMMSP ���̺���
   STOCKQTY �� 1500 �� �̻��� �������� INDATE(�԰�����) �� ITEMCODE(ǰ��) �÷��� ��ȸ�ϰ�
   ��ȸ�� ��� �� ITEMDCODE �� C �� ������ �����͸� �˻��ϼ���. */
  SELECT INDATE            -- �԰� ����
        ,ITEMCODE
    FROM TB_StockMM
   WHERE STOCKQTY > 1500
GROUP BY INDATE, ITEMCODE
  HAVING ITEMCODE LIKE '%C';

-- ** ���� HAVING �� ������ �÷��� �ݵ�� GROUP BY, �����Լ��� ���� ���յ� ���¿��� �Ѵ�.

/* TB_ItemMaster ���̺��� ITEMNSPEC, WHCODE �÷��� �����Ͽ� ���� ������� ITEMTYPE �� �˻��� ��� (����) */

-- ���� ���� �������� ����
  SELECT ITEMSPEC
        ,WHCODE
    FROM TB_ItemMaster
GROUP BY ITEMSPEC, WHCODE
  HAVING WHCODE = 'WH003'; -- GROUP BY �� ���յ� �Լ����� ��
  
/***** �����Լ�
SUM()   : ���յǴ� �÷��� �����͸� ��� ���Ѵ�.
MIN()   : ���յǴ� �÷��� ������ �� ���� ���� ���� ��Ÿ����.
MAX()   : ���յǴ� �÷��� ������ �� ���� ���� ���� ��Ÿ����.
COUNT() : ���յǴ� �÷��� �� ���� ������ ��Ÿ����.
AVG()   : ���յǴ� �÷��� ���� ������ ���� ����� ��Ÿ����. */

/* �����Լ��� ����ϴ� �÷��� GROUP BY �� ���յ� ��󿡼� ���� ���� 
   �����Լ��� ������� �ʴ� �÷��� ���ԵǾ� ���� ��� GROUP BY �� �÷� ������� ��ϵǾ�� �� */

-- ** ITEMCODE �� ��� ���� ���� ��ȸ
  SELECT ITEMCODE
        ,COUNT(*) AS ITEM_CNT
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE �� STOCKQTY �� ��ȸ
  SELECT ITEMCODE
        ,SUM(STOCKQTY) STOCKQTY_SUM
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE  �� STOCKQTY ��� ��ȸ
  SELECT ITEMCODE
        ,AVG(STOCKQTY) AS STOFKQTY_AVG
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE  �� STOCKQTY �ּҰ� ��ȸ
  SELECT ITEMCODE
        ,MIN(STOCKQTY) AS STOFKQTY_MIN
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ITEMCODE  �� STOCKQTY �ִ밪 ��ȸ
  SELECT ITEMCODE
        ,MAX(STOCKQTY) AS STOFKQTY_MAX
    FROM TB_StockMM
GROUP BY ITEMCODE;

-- ** ���� �Լ��� ������ ����Ͽ� ���ϴ� ����� ���� �� �ִ�.
-- ITEMTYPE �� UNITCOST �� �հ� �ּҰ� ��ȸ
-- ����� ������� HAVING �������� �߰��Ͽ� ���ϴ� ����� ��˻��� �� �ִ�.
  SELECT ITEMTYPE
        ,SUM(UNITCOST) AS SUM_COST
	    ,MIN(UNITCOST) AS MIN_COST
    FROM TB_ItemMaster
GROUP BY ITEMTYPE
  HAVING SUM(UNITCOST) > 20000

-- ** ���� �Լ��� ����� ����� ��ȸ���� ���͸�(HAVING) �� ����
-- ����� ������� HAVING �������� �߰��Ͽ� ���ϴ� ��� ���� ���� �����͸� ����

/* TB_ItemMaster ���̺��� UNITCOST �� 0 �̻��� ������ ��
   ITEMTYP ���� UNITCOST �� �� ��, UNITCOST �� �ִ밪�� ��Ÿ����
   ����� ���� �� UNITCOST �� ���� 100 �̻��� �����͸�
   UNITCOST �ִ밪 �������� �������� ���� */

   (SELECT ITEMTYPE							--5
		  ,SUM(UNITCOST) AS UNITCOST_SUM
		  ,MAX(UNITCOST) AS UNITCOST_MAX
	  FROM TB_ItemMaster					--1
	 WHERE UNITCOST >= 0					--2
  GROUP BY ITEMTYPE							--3
    HAVING SUM(UNITCOST) > 100)				--4
  ORDER BY UNITCOST_MAX;					--6
  -- SELECT ���� �� �÷� ��Ī�� �ο��Ǿ� ORDER BY ������ ��Ī���� ȣ�� ����
  /* ������ ���̽� ���� ó�� ����
  FROM -> WHERE -> GROUP BY -> HAVING -> SELECT -> ORDER BY */

-- ** �ϳ��� �÷��� ���� ���踦 ��Ÿ�� ������ GROUP BY �� DISTNCT �� �����Ͽ� �˻��� ����
SELECT SUM(UNITCOST) AS ITEMCODE_SUM
  FROM TB_ItemMaster;

  /****** �߿� *********
  GROUP BY �� �����Լ��� ���� ����� �� �����ϰ� ���δ�. */

  /* TB_StockMM ���̺��� STOCKQTY �� 1000 �� �̻��� 
    INDATE �� ITEMCODE �� ���յ� ������ ������ 1���� ū ������ �˻��϶�. */
  SELECT INDATE
	    ,COUNT(ITEMCODE) AS CNT
    FROM TB_StockMM
   WHERE STOCKQTY >= 1000
GROUP BY INDATE, ITEMCODE
  HAVING COUNT(*) > 1;

  /******* �ǽ� *********
  TB_StockMMrec(���� ���� �̷�) ���̺��� ������ ��
  INOUTQTY(����� ����) 1000 ���� ũ��, INOUTFLAG �� 'I' (�԰��̷�) ��
  INOUTDATE(���������) �� WHCODE(â��) �� ���յ� �������� ������ 2�� �̻��� �����͸�
  INOUTDATE ������������ ��ȸ�ϼ���. */
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
7. ���� ����
  ������ ������Ű�� ���� (WHERE ���̸�, ���� ���� ��� (=,<>,IN,LIKE) '?') ������ �ۼ��Ͽ� 
  �����͸� �˻��ϴ� ���
  ���� : SQL �����ȿ��� �����ϰ� �Ǵٸ� SQL ������ ����� Ȱ���� �� �ִ�.
  ���� : ����ӵ��� ��������. ������ ����������. */

  -- ** ���������� ���� �������� ��ȸ

/* TB_StockMMrec(���� ���� �̷�) ���̺��� PONO(���ֹ�ȣ) �� 'PO202106270001' �� ITEMCODE �� ������
   TB_ItemMaster(ǰ�񸶽���) ���̺��� ��ȸ�Ͽ� ITEMCODE, ITEMNAME, ITEMTYPE, CARTPYE �÷��� ������ �˻� */

-- 1. ������ �Ǵ� ���̺� (�������̺�) TB_ItemMaster
SELECT ITEMCODE
	  ,ITEMNAME
	  ,ITEMTYPE
	  ,CARTYPE
  FROM TB_ItemMaster
 WHERE ITEMCODE = (SELECT ITEMCODE
					 FROM TB_StockMMrec 
					WHERE PONO = 'PO202106270001')

-- ���� �������� ��ȸ�Ǿ�� �ϴ� �÷��� ������ ������ �÷��� ������ �����ؾ� �Ѵ�.

-- ** '=' �� ���ǿ��� �� �� �̻��� ���� ������ �������� ������ ������ �� ����.
SELECT ITEMCODE -- ǰ���ڵ�
	  ,ITEMNAME -- ǰ���
  FROM TB_ItemMaster
 WHERE ITEMCODE = (SELECT *
					 FROM TB_StockMMrec	
					WHERE INOUTFLAG = 'I')

-- ** �������� �ʴ� ������ �˻�
SELECT ITEMCODE
	  ,ITEMNAME
  FROM TB_ItemMaster
 WHERE ITEMCODE <> (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE PONO = 'PO202106270001');

-- ** �� �� �̻��� �����͸� ���� ������ �����ϴ� ���
SELECT ITEMCODE
	  ,ITEMNAME
  FROM TB_ItemMaster
 WHERE ITEMCODE IN (SELECT ITEMCODE
					  FROM TB_StockMMrec
					 WHERE PONO LIKE 'PO%'
					   AND ITEMCODE IS NOT NULL)

-- ** ���� ������ ���� ����... �� ���� ���� ... �� ���� ����

/* TB_StockMM (���� ���) ���̺��� STOCKQTY (������) �� 3000 ���� ū MATLOTNO(LOTNO) �� ���� 
   TB_StockMMrec ���̺��� ITEMCODE �����͸�
   TB_ItemMaster ���̺��� ITEMCODE, ITEMNAME, ITEMTYPE, CARTYPE �÷����� �˻� */

	-- 1. ���� ��� ���̺��� STOCKQTY �� 30000 ���� ū MATLOTNO ����Ʈ ��ȸ
SELECT MATLOTNO 
  FROM TB_StockMM
 WHERE STOCKQTY > 3000

	-- 2. ���� �����̷����̺�(TB_StockMMrec) ���� 1������ ��ȸ�� MATLOTNO �� ������ ITEMCODE ��ȸ
SELECT ITEMCODE
  FROM TB_StockMMrec
 WHERE MATLOTNO IN (SELECT MATLOTNO
					  FROM TB_StockMM
					 WHERE STOCKQTY > 3000)

	-- 3. ǰ�񸶽���(TB_ItemMaster) ���� �ش� ITEMCODE ������ ã��
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

-- ** ���������� �ƴѵ� ��������ó�� ���̴� �͵�

-- 1. SELECT ������ �÷� ��ġ�� �δ� ���
/* TB_StockMM ���̺��� ITEMCODE, INDATE, MALTLOTNO �÷��� �����͸� �˻��ϰ�
   TB_StockMMrec ���̺��� TB_StockMM ���̺��� ��ȸ�� MATLOTNO �÷��� �����͸� �����ϰ�
   INOUTFLAG = 'OUT' ��� ���� ������ INOUTDATE �÷��� �����͸� ��ȸ */

SELECT ITEMCODE
	  ,INDATE
	  ,MATLOTNO
	  ,(SELECT INOUTDATE 
		  FROM TB_StockMMrec 
		 WHERE MATLOTNO = A.MATLOTNO 
		   AND INOUTFLAG = 'OUT') AS INOUTDATE
  FROM TB_StockMM A

-- ���� ����
-- 1�ܰ�. TB_StockMM ���� �����͸� ��ȸ
SELECT ITEMCODE
	  ,INDATE
	  ,MATLOTNO
  FROM TB_StockMM

-- 2�ܰ�. �÷��� �ִ� SELECT ������ 1�ܰ迡�� ��ȸ�� MATLOTNO ���� ���� ����
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

  -- *** ���� ***
  -- �������̺� TB_StockMM ���� ��ȸ 1��
  -- �÷� ������ ǥ���ϱ� ���ؼ� ��ȸ 9��
  -- �� 10���� �˻������� ����ȴ�. (��ȿ��)

-- ** SELECT ������ FROM ��ġ�� �δ� ���

/* TB_StockMMrec ���̺� ������ �� INOUTQTY �� 1000 ���� ũ��, INOUTFLAG �� 'I' ��
   INOUTDATE �� WHCODE �� ���յ� �������� ������ 2�� �̻��� �����͸� �˻��Ͻÿ� */
  SELECT INOUTDATE	
  	    ,WHCODE
  	    ,COUNT(*) AS CNT
    FROM TB_StockMMrec
   WHERE INOUTQTY > 1000
     AND INOUTFLAG = 'I'
GROUP BY INOUTDATE, WHCODE
  HAVING COUNT(*) >= 2

  -- GROUP BY ������ �ϳ��� ���̺�� ����ϴ� ���

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
-- �б⹮, ����� ���¿� ���� ���̳� ������ �ٸ��� �����Ѵ�.
-- ** �ݵ�� END �� �������� ���־�� �Ѵ�. */

-- ** 1��°. CASE ���

SELECT INOUTFLAG -- ����� ����. I : �԰� / O : ���
	  ,CASE INOUTFLAG WHEN 'I' THEN '�԰�'
				   	  WHEN 'O' THEN '���'
				      ELSE '��Ÿ' END		AS INOUT_FLAG
  FROM TB_StockMMrec

-- ** 2��°. CASE ��� 
SELECT PLANTCODE -- ����
	  ,MATLOTNO  -- LOTNO
	  ,WHCODE	  -- â��
	  ,STOCKQTY  -- ������
	  ,CASE WHEN STOCKQTY <= 0 THEN '������'
			WHEN STOCKQTY >= 0 AND STOCKQTY <= 1000 THEN '��������'
			ELSE '����ʰ�' END AS STOCK_STATE
  FROM TB_StockMM

/*****************************************************************************************
9. NULL �� ���� ���ϴ� �����ͷ� �����ϱ� ISNULL(?,?) */

/* TB_StockMMrec ���̺��� PLANTCODE, INOUTDATE, INOUTSEQ, ITEMCODE �÷��� �����͸� �˻��ϰ�
   ITEMCODE �� NULL �� ��� 0 ���� ǥ���ϼ���. */

SELECT PLANTCODE
	  ,INOUTDATE
	  ,INOUTSEQ
	  ,ISNULL(ITEMCODE,0) AS ITEMCODE
  FROM TB_StockMMrec
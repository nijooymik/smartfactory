/*
  - SELECT
    . �����ͺ��̽� ���� ���̺��� ���ϴ� ������ �����ϴ� ���
	. ���� �⺻���� SQL ���������� �����ͺ��̽� � �� �߿䵵�� ���� �����̹Ƿ� �� ������ ��

  - SELECT ������ �⺻ ����
    . SELECT [���̸�]
	    FROM [���̺� �̸�]
	   WHERE [����] -- ���� ����� ���� �ְ� ���� ����� ���� �ִ�.
*/

/*********************************************************************
 1. �⺻���� SELECT ���� */
 
 -- TB_ItemMaster ���̺� �ִ� ��� �÷��� �����͸� �˻� ǥ��
 SELECT *
   FROM TB_ItemMaster;
 -- * : �ƽ��׸�ũ (���̺��� ��� ������ �˻�)

/*********************************************************************
  2. Ư�� �÷��� �˻� */

  -- TB_ItemMaster ���� ITEMCODE, ITEMNAME, ITEMTYPE �÷��� �����͸� ��ȸ
  SELECT ITEMCODE, -- ǰ��
         ITEMNAME, -- ǰ���
		 ITEMTYPE  -- ǰ��Ÿ��
    FROM TB_ItemMaster;

/** �ǽ� **
 TB_ItemMaster ���̺��� ITEMCODE, WHCODE, BASEUNIT, MAKEDATE �÷��� ��ȸ�ϼ��� */
 SELECT ITEMCODE,
        WHCODE,
		BASEUNIT,
		MAKEDATE
   FROM TB_ItemMaster;

/*********************************************************************
  3. �÷��� ��Ī �ֱ� (AS)
    ��ȸ�Ǵ� �÷��� ��Ī�� �־� ������ �÷��� �̸����� �����Ͽ� ��ȸ */

/* TB_ITEMMASTER ���̺���
   ITEMCODE �÷��� ITEM_CODE ��
   ITEMNAME �÷��� ITEM_NAME ����
   ITEMTYPE �÷��� ITEM_TYPE ���� ǥ�� */
 SELECT ITEMCODE AS ITEM_CODE
       ,ITEMNAME AS ITEM_NAME
	   ,ITEMTYPE AS ITEM_TYPE
   FROM TB_ItemMaster;

/*********************************************************************
  4. ���� �� (WHERE)
    �˻� ������ �Է��Ͽ� ���ϴ� �����͸� ��ȸ�Ѵ�.
	SQL ������ ' Ȭ����ǥ�� ���ڸ� �����Ѵ�.
*/
 -- TB_ItemMaster ���̺��� 
 -- BASEUNIT �� 'EA' �� ��� �÷��� �˻�
 SELECT *
   FROM TB_ItemMaster
  WHERE BASEUNIT = 'EA';


 -- ** �˻� ���� �߰� AND
/* TB_ItemMaster ���̺��� 
   BASEUNIT �� 'EA' �� �Ͱ�
   ITEMTYPE �� 'HALB' �� ��� �÷��� �˻� */
 SELECT *
   FROM TB_ItemMaster
  WHERE BASEUNIT = 'EA'
    AND ITEMTYPE = 'HALB';

 -- ** �˻����� �߰� OR
/* TB_ItemMaster ���̺���
   BASEUNIT �� 'EA' �̰ų� (�Ǵ�)
   ITEMTYPE �� 'HALB' �� ��� �÷��� �˻�
*/
SELECT *
  FROM TB_ItemMaster
 WHERE BASEUNIT = 'EA'
    OR ITEMTYPE = 'HALB';

 -- �� ������ ���������� ǥ�� ����
SELECT *
  FROM TB_ItemMaster
 WHERE (BASEUNIT = 'EA' OR ITEMTYPE = 'HALB');

 /** ���� **
   �÷��� �ٸ� �˻� ���ǿ� OR �� ���� ���
   BASEUNIT �� EA �� �ƴϸ� ITEMTYPE �� HALB �� �ƴ� �����Ͱ�
   ��� �˻��� �� �ִ�. */

 /**** �ǽ� ****
   TB_ItemMaster ���̺���
   WHCODE �� 'WH003' �Ǵ� 'WH008' �� ������ ��
   BASEUNIT �� 'KG' �� ���� ITEMCODE, WHCODE, BASEUNIT �÷��� ��ȸ�ϼ���. */
SELECT ITEMCODE
      ,WHCODE
	  ,BASEUNIT
  FROM TB_ItemMaster
 WHERE (WHCODE = 'WH003' OR WHCODE = 'WH008' AND BASEUNIT = 'KG');

/*********************************************************************
 5. ���� �������� ���
   �˻� ���ǿ� ���۰� ���ῡ ���� ������ �Է��Ͽ� ���ϴ� ����� ��ȸ�Ѵ�.
   ���� �Ⱓ�̳� ���ڸ� �˻������� ������ ������ �˻��� �����ϴ�.
 */

 -- ** �Ⱓ ���� ���� �˻�
 SELECT *
   FROM TB_ItemMaster
  WHERE EDITDATE > '2020-08-01'
    AND EDITDATE <= '2020-09-01'
-- EDITDATE �÷��� DATETIME ������ ������ �÷�������
-- DATETIME ������ �ؼ��ϴ�
-- ���� �ش�.

-- ** �� ���� ���� �˻�
-- ������ �÷� ���� �������� �˻�
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK > 10
   AND MAXSTOCK <= 20;

-- ** ���ڿ��� �Է��Ͽ� ������ �÷� �˻� ����
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK > '10'
   AND MAXSTOCK <= '20'

-- �������� �ʴ� ������ �˻� < >
SELECT *
  FROM TB_ItemMaster
 WHERE INSPFLAG <> 'U';

 /* TB_ItemMaster ���̺���
    INSPFLAG �÷� ������ A �̻��̰� U ������ �������� �÷��� ��� ��ȸ */
SELECT *
  FROM TB_ItemMaster
 WHERE INSPFLAG >= 'J'
   AND INSPFLAG <= 'U';

-- ** ���� �������� (BETWEEN AND)
/* TB_ItemMaster ���̺���
MAXSTOCK �� 10 �̻�, 20 ������ �������� �÷��� ��� ��ȸ */
SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK >= 10 AND MAXSTOCK <= 20

SELECT *
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 10 AND 20;

 --********** �ǽ� ************* IiLl 0oO��
 /* TB_ItemMaster ���̺���
    WHCODE �� WH002 ~ WH005 ������ ���� ������
	UNITCOST �� 1000 �� �ʰ��ϰ�
	INSPFLAG �� I �� �ƴ� ����
	PLANTCODE, ITEMCODE, WHCODE, UNITCOST, INSPFLAG �÷��� ��Ÿ������. */

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
 6. Ư�� �÷� �˻� ������ N �� ���� (IN / NOT IN)
    Ư�� �÷��� �����ϰ� �ִ� ������ �� �˻��ϰ��� �ϴ� ������ ���� �� ���
 */

 /* TB_ItemMaster ����
    ITEMCODE, ITEMTYPE, MAXSTOCK �÷��� ��ȸ�ϰ�
	MAXSTOCK �� ������ 1 �̻� 3000 ������ �� �߿�
	ITEMTYPE �� 'FERT', 'HALB' �� �����͸� ��ȸ */

SELECT ITEMCODE
	  ,ITEMNAME -- ǰ���
	  ,MAXSTOCK -- �ִ����
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000
   AND ITEMTYPE = 'FERT' OR ITEMTYPE = 'HALB'
-- *** ���� �˻� ���ǿ� OR �� ����� ��� ��ȣ ������ �� ���� ��!
 
SELECT ITEMCODE -- ǰ���ڵ�
      ,ITEMNAME -- ǰ���
	  ,MAXSTOCK -- �ִ����
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000

 -- ** �������� �ʴ� �������� �˻�
 /* TB_ItemMaster ����
   ITEMCODE, ITEMTYPE, MAXSTOCK �÷��� ��ȸ�ϰ�
   MAXSTOCK �� ������ 1 �̻� 3000 ������ �� �߿�
   ITEMTYPE �� 'FERT', 'HALB' �� �ƴ� �����͸� ��ȸ */
SELECT ITEMCODE
	  ,ITEMTYPE
	  ,MAXSTOCK
  FROM TB_ItemMaster
 WHERE MAXSTOCK BETWEEN 1 AND 3000
   AND ITEMTYPE NOT IN ('FERT', 'HALB');

/****** �ǽ� ******
TB_ItemMaster ���̺���
CARTYPE �÷��� ���� 'TL', 'LM'�� �Ͱ�
WHCODE 'WH004' �� 'WH007' ���̿� �ִ� �� ��
ITEMTYPE �� 'HALB' �� �ƴ�
ITEMCODE, ITEMNAME, ITEMTYPE, WHCODE, CARTYPE �÷��� �����͸� �˻��ϼ���. */

SELECT ITEMCODE
      ,ITEMNAME
	  ,ITEMTYPE
	  ,WHCODE
	  ,CARTYPE
  FROM TB_ItemMaster
 WHERE CARTYPE IN ('TL', 'LM')
   AND WHCODE BETWEEN 'WH004' AND 'WH007'
   AND ITEMTYPE <> 'HALB';

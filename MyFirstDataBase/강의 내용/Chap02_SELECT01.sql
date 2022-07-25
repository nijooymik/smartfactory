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

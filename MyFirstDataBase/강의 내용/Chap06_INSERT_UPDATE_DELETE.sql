/* 1. INSERT
  - ���̺� �����͸� ���
  - INSERT �� �⺻ ����
  . INSERT INTO <���̺�> (���̸�1,���̸�2,.....) VALUES(��1,��2.......)

  - * PK �÷����� (���ձ⵵ ����) �ߺ����� �ʴ� �����͸� �����ؾ� ��
  - * NULL ����� ���� ���� �÷����� NULL ���� �Է��� �� ����.
  - * �÷��� FK �� �����Ǿ��� ��� ���� ���̺� ���� �����ʹ� ����� �� ����.
*/

 -- 1-1 TB_Cust�� ������ ���
 SELECT * FROM TB_Cust;
 INSERT INTO TB_Cust (ID, NAME, PHONE) VALUES (5,'��â��',5555);

 -- 1-2 ��� �÷��� �����͸� ����� ���� �� �̸� ���� ����
 INSERT INTO TB_Cust VALUES ('6','������','6666');

 -- 1-3 �Ϻ� �����͸� ��� ���
 INSERT INTO TB_Cust (NAME,PHONE) VALUES ('�̼�',7777); -- PK(NOT NULL) �÷��� �����͸� �Է����� �ʾ� ����
 INSERT INTO TB_Cust (ID,NAME) VALUES (7,'�̼�'); -- PK ���� �Է��Ͽ� ������
 SELECT * FROM TB_Cust;

 -- 1-4 ���̺��� ����
 /* �⺻����
 SELECT * INTO [������ ���̺��] FROM [���� ���̺��] WHERE 'A'='B' // WHERE 1=2 �� ���̸� ���̺� ����
																	// WHERE 1=2 �� ������ �����ͱ��� ���� ����
 */

 -- ���̺� ����
 -- ** ���������� ���̺��� ������ �൥���ʹ� ������ �� ������ PK,FK,INDEX ���� ������ �� ����.
 SELECT * INTO TB_SalesList2 FROM TB_SaleList WHERE 1=2;

 SELECT * FROM TB_SalesList2;

 -- 1-5 �ټ��� �� INSERT
 -- SELECT �� ���� �ټ� �� ������ ���
 INSERT INTO TB_SalesList2 (DATE,CUST_ID,FRUIT_NAME,AMOUNT)
					 SELECT DATE,CUST_ID,FRUIT_NAME,3000
					   FROM TB_SaleList
					  WHERE CUST_ID = 3;
 SELECT * FROM TB_SalesList2;

 -- ���� �����͸� ����� ��� SELECT ���� ����Ͽ� ��ϵ� ����
 INSERT INTO TB_SalesList2 (DATE,CUST_ID,FRUIT_NAME,AMOUNT)
					SELECT '2022-06-14',4,'����',3000;

 /***************************************************************************************************
 2. UPDATE
 - ���̺��� �����͸� ����
 - UPDATE �� �⺻ ����
   . UPDATE <���̺�>
		SET ���̸�1 = ��1
		   ,���̸�2 = ��2
	  WHERE [����]; */
 
 UPDATE TB_SalesList2
	SET AMOUNT  = 1
	   ,DATE    = '2022-06-17'
  WHERE CUST_ID = 4

 SELECT * FROM TB_SalesList2;

 /***************************************************************************************************
 3. DELETE
 - ���̺� ���� �����͸� ����
 - DELETE �� �⺻ ����
   . DELETE <���̺�>
	  WHERE [����] */

 DELETE TB_SalesList2
  WHERE CUST_ID = 4;

 /***************************************************************************************************
 4. ������ ���� ���� ���� �Ǵ� ���� (TRAN, COMMIT, ROLLBACK)
 - �������� �ϰ����� �����ϸ鼭 �����ϰ� ���� �Ǵ� �����ϱ� ���� �۾�
 - MSSQL �� �ڵ����� UPDATE,INSERT,DELETE �� �Ϸ� ����(COMMIT)
   . ������ ���� �� �߻��ϴ� �������� (10�� ������ Ʈ����� ���� �� 6��°���� ����, �������� �Ǽ�)
     � ��ó�ϱ� ���� ������ ���� �� ���� �Ǵ� ������ ������ �ʿ䰡 ����
 - BEGIN TRAN ���� �� �ݵ�� COMMIT, ROLLBACK �� ���־�� �Ѵ�.
   . Ʈ������� ������(�ݸ���) - �ϳ��� Ʈ������� ����ǰ� ���� �� �Ǵٸ� Ʈ������� ������ �� ����.
   . ���� Ʈ������� �����ϸ� �ٸ� ����� �ش� ���̺��� ������ �� ����. */

 BEGIN TRAN
 DELETE TB_SalesList2

 SELECT * FROM TB_SalesList2;

 ROLLBACK;

 COMMIT;
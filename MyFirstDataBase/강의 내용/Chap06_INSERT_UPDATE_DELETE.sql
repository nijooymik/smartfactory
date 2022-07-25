/* 1. INSERT
  - 테이블에 데이터를 등록
  - INSERT 의 기본 유형
  . INSERT INTO <테이블> (열이름1,열이름2,.....) VALUES(값1,값2.......)

  - * PK 컬럼에는 (복합기도 포함) 중복되지 않는 데이터를 저장해야 함
  - * NULL 허용을 하지 않은 컬럼에는 NULL 값을 입력할 수 없다.
  - * 컬럼이 FK 로 설정되었을 경우 기준 테이블에 없는 데이터는 등록할 수 없다.
*/

 -- 1-1 TB_Cust에 데이터 등록
 SELECT * FROM TB_Cust;
 INSERT INTO TB_Cust (ID, NAME, PHONE) VALUES (5,'임창정',5555);

 -- 1-2 모든 컬럼의 데이터를 등록할 때는 열 이름 생략 가능
 INSERT INTO TB_Cust VALUES ('6','윤종신','6666');

 -- 1-3 일부 데이터만 골라서 등록
 INSERT INTO TB_Cust (NAME,PHONE) VALUES ('이수',7777); -- PK(NOT NULL) 컬럼에 데이터를 입력하지 않아 오류
 INSERT INTO TB_Cust (ID,NAME) VALUES (7,'이수'); -- PK 값을 입력하여 정상동작
 SELECT * FROM TB_Cust;

 -- 1-4 테이블의 복사
 /* 기본형태
 SELECT * INTO [생성할 테이블명] FROM [원본 테이블명] WHERE 'A'='B' // WHERE 1=2 를 붙이면 테이블만 복사
																	// WHERE 1=2 가 없으면 데이터까지 같이 복사
 */

 -- 테이블 복사
 -- ** 복사쿼리로 테이블의 구조와 행데이터는 복사할 수 있으나 PK,FK,INDEX 등은 복사할 수 없다.
 SELECT * INTO TB_SalesList2 FROM TB_SaleList WHERE 1=2;

 SELECT * FROM TB_SalesList2;

 -- 1-5 다수의 행 INSERT
 -- SELECT 를 통한 다수 행 데이터 등록
 INSERT INTO TB_SalesList2 (DATE,CUST_ID,FRUIT_NAME,AMOUNT)
					 SELECT DATE,CUST_ID,FRUIT_NAME,3000
					   FROM TB_SaleList
					  WHERE CUST_ID = 3;
 SELECT * FROM TB_SalesList2;

 -- 단일 데이터만 등록할 경우 SELECT 절만 사용하여 등록도 가능
 INSERT INTO TB_SalesList2 (DATE,CUST_ID,FRUIT_NAME,AMOUNT)
					SELECT '2022-06-14',4,'딸기',3000;

 /***************************************************************************************************
 2. UPDATE
 - 테이블의 데이터를 수정
 - UPDATE 의 기본 유형
   . UPDATE <테이블>
		SET 열이름1 = 값1
		   ,열이름2 = 값2
	  WHERE [조건]; */
 
 UPDATE TB_SalesList2
	SET AMOUNT  = 1
	   ,DATE    = '2022-06-17'
  WHERE CUST_ID = 4

 SELECT * FROM TB_SalesList2;

 /***************************************************************************************************
 3. DELETE
 - 테이블 행의 데이터를 삭제
 - DELETE 의 기본 유형
   . DELETE <테이블>
	  WHERE [조건] */

 DELETE TB_SalesList2
  WHERE CUST_ID = 4;

 /***************************************************************************************************
 4. 데이터 갱신 내역 승인 또는 복구 (TRAN, COMMIT, ROLLBACK)
 - 데이터의 일관성을 유지하면서 안전하게 승인 또는 복구하기 위한 작업
 - MSSQL 은 자동으로 UPDATE,INSERT,DELETE 를 완료 승인(COMMIT)
   . 데이터 관리 시 발생하는 오류사항 (10개 데이터 트랜잭션 실행 시 6번째부터 오류, 관리자의 실수)
     등에 대처하기 위해 데이터 갱신 후 승인 또는 복구를 실행할 필요가 있음
 - BEGIN TRAN 선언 후 반드시 COMMIT, ROLLBACK 을 해주어야 한다.
   . 트랜잭션의 독립성(격리성) - 하나의 트랜잭션이 수행되고 있을 때 또다른 트랜잭션이 간섭할 수 없다.
   . 내가 트랜잭션을 선언하면 다른 사람이 해당 테이블을 관리할 수 없다. */

 BEGIN TRAN
 DELETE TB_SalesList2

 SELECT * FROM TB_SalesList2;

 ROLLBACK;

 COMMIT;
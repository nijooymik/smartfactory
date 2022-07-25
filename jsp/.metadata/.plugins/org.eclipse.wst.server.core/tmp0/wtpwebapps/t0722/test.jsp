<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<%@page import="java.sql.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
<%
   // db 접속 변수
   Connection conn = null;
   //드라이버 설정 변수
   String driver ="oracle.jdbc.driver.OracleDriver";
   //계정 경로 설정변수
   String url ="jdbc:oracle:thin:@localhost:1521:orcl";
   //접속 성공 여부 변수
   Boolean connection = false;
   
   try{
      //오라클 드라이버 변수
      Class.forName(driver);
      //DB 접속
      conn = DriverManager.getConnection(url,"C##com","a1234");
      //접속 성공 여부
      connection = true;
      conn.close();
   }catch(Exception e){
      connection=false;
      e.printStackTrace();
   }
   if(connection==true){
      out.print("디비 연결 성공");
   }else{
      out.print("디비 연결 실패");
   }

%>
</body>
</html>
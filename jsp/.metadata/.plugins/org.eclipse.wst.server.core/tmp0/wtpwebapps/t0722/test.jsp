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
   // db ���� ����
   Connection conn = null;
   //����̹� ���� ����
   String driver ="oracle.jdbc.driver.OracleDriver";
   //���� ��� ��������
   String url ="jdbc:oracle:thin:@localhost:1521:orcl";
   //���� ���� ���� ����
   Boolean connection = false;
   
   try{
      //����Ŭ ����̹� ����
      Class.forName(driver);
      //DB ����
      conn = DriverManager.getConnection(url,"C##com","a1234");
      //���� ���� ����
      connection = true;
      conn.close();
   }catch(Exception e){
      connection=false;
      e.printStackTrace();
   }
   if(connection==true){
      out.print("��� ���� ����");
   }else{
      out.print("��� ���� ����");
   }

%>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
    <%@page import = "java.time.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
<center>
<%
	LocalDate spcdate = LocalDate.of(2022,7,20);
	String spc = spcdate.getYear()+"��";
	spc += spcdate.getMonth()+"��";
	spc += spcdate.getDayOfMonth() +"��";
	out.print("Ư���� �� : " + spc + "<br>"); 
%>
</center>
</body>
</html>
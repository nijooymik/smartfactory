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
	String spc = spcdate.getYear()+"년";
	spc += spcdate.getMonth()+"월";
	spc += spcdate.getDayOfMonth() +"일";
	out.print("특별한 날 : " + spc + "<br>"); 
%>
</center>
</body>
</html>
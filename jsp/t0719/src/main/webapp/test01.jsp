<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
<%
	int num1=3;
	int num2=4;
	int sum;
	sum = num1 + num2;
	System.out.println(num1+" + "+num2+" = "+sum);
%>
<%=num1%>+<%=num2%>=<%=sum %>
</body>
</html>
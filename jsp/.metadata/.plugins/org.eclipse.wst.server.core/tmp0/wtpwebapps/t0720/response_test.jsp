<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%@page import="java.util.*" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<%
	Enumeration<String> enu = request.getHeaderNames();

	while(enu.hasMoreElements()){
	
		String name = (String)enu.nextElement();
		String value = (String)request.getHeader(name);
		
		out.print("헤더이름 : " + name + "<br>");
		out.print("헤더값 : " + value + "<br>");
	}
%>
</body>
</html>
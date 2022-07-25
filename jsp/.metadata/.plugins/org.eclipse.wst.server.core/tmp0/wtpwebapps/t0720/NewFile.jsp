<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
<b>request 내장 객체 - [헤더관련 정보]</b><br>
<%
Enumeration<String> enu = request.getHeaderNames();

while (enu.hasMoreElements()) {
	
	String head_name = (String)enu.nextElement();
	String head_value = request.getHeader(head_name);
	
	out.print("헤더 이름 : " + head_name + "<br>"
			+ "헤더 값 : " + head_value + "<br>");
}
%>
</body>
</html>
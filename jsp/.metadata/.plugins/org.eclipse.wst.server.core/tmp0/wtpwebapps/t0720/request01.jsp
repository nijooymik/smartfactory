<%@page import="java.util.Enumeration"%>
<%@page import="java.awt.PageAttributes.OrientationRequestedType"%>
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
	out.print("ip주소 : "+request.getRemoteAddr()+"<br>");
	out.print("host주소 : "+request.getRemoteHost()+"<br>");
	out.print("port주소 : "+request.getRemotePort()+"<br>");
	out.print("user주소 : "+request.getRemoteUser()+"<br>");
%>
	요청정보 프로토콜 : <%=request.getProtocol() %><br>
	
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
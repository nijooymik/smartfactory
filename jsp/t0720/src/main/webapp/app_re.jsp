<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<center>
		<h2>���ȭ��</h2>
		<hr>

		<%=application.getAttribute("name")%><br>
		<%
		Integer count = (Integer) application.getAttribute("count");
		int cnt = count.intValue()+1;
		application.setAttribute("count", cnt);
		%>
		�湮�ڼ�
		<%=cnt %>
	</center>
</body>
</html>
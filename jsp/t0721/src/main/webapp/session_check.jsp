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
		<h2>技记 犬牢</h2>
		<hr>
		技记 加己(id) : <%=session.getAttribute("id")%><br> 
		技记 加己(name) : <%=session.getAttribute("name")%><br> 
		<a href="session_del.jsp">技记 昏力</a><br>
	</center>
</body>
</html>
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
		<h2>세션 확인</h2>
		<hr>
		세션 속성(id) : <%=session.getAttribute("id")%><br> 
		세션 속성(name) : <%=session.getAttribute("name")%><br> 
		<a href="session_del.jsp">세션 삭제</a><br>
	</center>
</body>
</html>
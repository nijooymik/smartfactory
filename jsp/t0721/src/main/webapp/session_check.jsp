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
		<h2>���� Ȯ��</h2>
		<hr>
		���� �Ӽ�(id) : <%=session.getAttribute("id")%><br> 
		���� �Ӽ�(name) : <%=session.getAttribute("name")%><br> 
		<a href="session_del.jsp">���� ����</a><br>
	</center>
</body>
</html>
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
		<h2>技记 积己</h2>
		<hr>
		<%
	session.setAttribute("id","admin");
	session.setAttribute("name","厘霖康");
	
	out.print("技记 积己<br>");
	%>
		技记 加己(id) : <%=session.getAttribute("id") %><br> 
		技记 加己(name) : <%=session.getAttribute("name") %><br>
	</center>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>트위터 메인 화면</title>
</head>
<body>
	@<%=session.getAttribute("username")%><br>
	<hr>
	<ul>
		<li><%=session.getAttribute("username")%> :: 
		<%=session.getAttribute("text")%> ,
		
	</ul>
</body>
</html>
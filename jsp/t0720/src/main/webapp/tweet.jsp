<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Twitter</title>
</head>
<body>
	<center>
		<h1>My Simple Twitter!!</h1>
		<hr>
		@<%=session.getAttribute("username")%>
		<input type="text" name="text"> 
		<input type="submit" value="Tweet">
		<hr>
		<"twitter_list.jsp">
		<%=session.getAttribute("username")%> :: 
		<%=session.getAttribute("text")%> , 
		<%-- <%= now %> --%>
	</center>
</body>
</html>
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
		<h2>세션 삭제</h2>
		<hr>
		<%
		out.print("세션 생성 시간 : " + session.getCreationTime() + "초<br>");
		out.print("클라이언트의 해당세션 마지막접근시간 : " + session.getLastAccessedTime() + "초<br>");
		out.print("세션 유지 시간 : " + (session.getLastAccessedTime() - session.getCreationTime()) + "초<br>");
		out.print("세션 유효 시간 : " + session.getMaxInactiveInterval() + "초<br>");

		session.removeAttribute("id");
		session.removeAttribute("name");
		out.print("세션 삭제<br>");
		%>
		세션 속성(id) : <%=session.getAttribute("id")%><br> 
		세션 속성(name) : <%=session.getAttribute("name")%><br>
		<%
		// 세션 객체 초기화
		session.invalidate();
		%>
		<a href="session_check.jsp">세션 확인</a><br>
	</center>
</body>
</html>
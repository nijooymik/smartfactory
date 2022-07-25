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
		<h2>세션 예제</h2>
		<hr>
		<%
		//최초 세션 설정여부 확인
		if (!session.isNew()) {
			out.print("<script>alert('세션이 해제되었습니다. 다시 설정하세요.')</script>");
			session.setAttribute("id", "김유진");
		}
		%>
		<%=session.getAttribute("id")%>님 반갑습니다.<br> 세션 id :
		<%=session.getId()%><br> 세션 시간 :
		<%=session.getMaxInactiveInterval()%><br>
	</center>
</body>
</html>
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
		<h2>application 예제</h2>
		<hr>
		서버 정보 :
		<%=application.getServerInfo()%><br> api 버전 정보 :
		<%=application.getMajorVersion()%><br> 실제 경로 :
		<%=application.getRealPath("application_test.jsp")%><br>
		<hr>
		<%
		application.setAttribute("name", "김유진");
		application.log("name=김유진");
		application.setAttribute("count", 1);
		%>
		<br> <a href="app_re.jsp">결과보기</a>
	</center>
</body>
</html>
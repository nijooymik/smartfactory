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
		<h2>��Ű ����</h2>
		<hr>
		<%
		Cookie[] cookies = request.getCookies();

		if (cookies != null) {
			for (int i = 0; i < cookies.length; i++) {
				cookies[i].setMaxAge(0);//��Ű����
				response.addCookie(cookies[i]);

				out.print("��Ű ����<br>");
			}
		} else {
			out.print("������ ��Ű ����<br>");
		}
		%>
		<a href="cookie_check.jsp">��Ű ���� Ȯ��</a>
	</center>
</body>
</html>
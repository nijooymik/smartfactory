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
		<h2>��Ű Ȯ��</h2>
		<hr>
		<%
		Cookie[] cookies = request.getCookies();//��Ű ����

		if (cookies != null) {
			for (Cookie c : cookies) {
				String name = c.getName();
				String value = c.getValue();

				out.print("��Ű�̸� : " + name + "<br>");
				out.print("��Ű�� : " + value + "<br>");
			}
		} else
			out.print("��Ű ������ ����");
		%>
		<a href="cookie_del.jsp">��Ű ����</a>
	</center>
</body>
</html>
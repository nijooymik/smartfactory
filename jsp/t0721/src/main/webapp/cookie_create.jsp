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
// ��Ű ��ü ����
Cookie cookie = new Cookie("id","admin");
cookie.setMaxAge(10);
response.addCookie(cookie);

out.print("��Ű ���� ������ <br>");
%>

		��Ű�� : <%=cookie.getValue() %><br> 
		��Ű �̸� : <%=cookie.getName() %><br> 
		��Ű �ð� : <%=cookie.getMaxAge() %><br>

	</center>
</body>
</html>
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
		<h2>���� ����</h2>
		<hr>
		<%
		out.print("���� ���� �ð� : " + session.getCreationTime() + "��<br>");
		out.print("Ŭ���̾�Ʈ�� �ش缼�� ���������ٽð� : " + session.getLastAccessedTime() + "��<br>");
		out.print("���� ���� �ð� : " + (session.getLastAccessedTime() - session.getCreationTime()) + "��<br>");
		out.print("���� ��ȿ �ð� : " + session.getMaxInactiveInterval() + "��<br>");

		session.removeAttribute("id");
		session.removeAttribute("name");
		out.print("���� ����<br>");
		%>
		���� �Ӽ�(id) : <%=session.getAttribute("id")%><br> 
		���� �Ӽ�(name) : <%=session.getAttribute("name")%><br>
		<%
		// ���� ��ü �ʱ�ȭ
		session.invalidate();
		%>
		<a href="session_check.jsp">���� Ȯ��</a><br>
	</center>
</body>
</html>
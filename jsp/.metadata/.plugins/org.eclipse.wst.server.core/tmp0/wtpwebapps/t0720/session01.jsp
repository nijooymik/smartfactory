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
		//���� ���� �������� Ȯ��
		if (!session.isNew()) {
			out.print("<script>alert('������ �����Ǿ����ϴ�. �ٽ� �����ϼ���.')</script>");
			session.setAttribute("id", "������");
		}
		%>
		<%=session.getAttribute("id")%>�� �ݰ����ϴ�.<br> ���� id :
		<%=session.getId()%><br> ���� �ð� :
		<%=session.getMaxInactiveInterval()%><br>
	</center>
</body>
</html>
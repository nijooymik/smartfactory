<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<%
	request.setCharacterEncoding("euc-kr");
	session.setAttribute("username", request.getParameter("username"));
	%>
	<center>
		<h2>��ǰ ����</h2>
		<hr>
		<%=session.getAttribute("username")%>���� �α����� �����Դϴ�.<br>
		<form name=fr method="post" action="add.jsp">
			<select name="product">
				<option>���</option>
				<option>����</option>
				<option>�ٳ���</option>
				<option>���ξ���</option>
				<option>�ڸ�</option>
				<option>����</option>
			</select> <input type="submit" value="�߰�">
		</form>
		<a href="checkOut.jsp">���</a>
	</center>
</body>
</html>
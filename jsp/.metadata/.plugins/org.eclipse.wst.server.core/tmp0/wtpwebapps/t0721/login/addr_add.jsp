<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%
request.setCharacterEncoding("euc-kr");
%>
<!-- useBean ��� -->
<jsp:useBean id="addr" class="com.jsp.AddrBean" scope="page">
	<jsp:setProperty name="addr" property="*" />
</jsp:useBean>
<jsp:useBean id="am" class="com.jsp.AddrManager" scope="application" />

<%
am.add(addr);
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<center>
		<h2>��ϳ���</h2>
		<hr>
		�̸� : <%=addr.getUsername() %><br>
		��ȭ��ȣ : <jsp:getProperty property="tel" name="addr"/><br>
		�̸��� : <jsp:getProperty property="email" name="addr"/><br>
		���� : <%=addr.getGender() %><br>
		<hr>
		<a href="addr_list.jsp">��Ϻ���</a><p>
	</center>
</body>
</html>
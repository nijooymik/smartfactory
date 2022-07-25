<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%@page import="com.jsp.AddrBean"%>
<jsp:useBean id="am" class="com.jsp.AddrManager" scope="application" />

<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<center>
		<h2>주소록</h2>
		<hr>
		<a href="addr_form.jsp">주소록 추가</a>
		<p>
		<table border=1 width=500>
			<tr>
				<td>이름</td>
				<td>전화번호</td>
				<td>이메일</td>
				<td>성별</td>
			</tr>
			<%
			for (AddrBean ab : am.getAddrList()) {
			%>
			<tr>
				<td><%=ab.getUsername() %></td>
				<td><%=ab.getTel() %></td>
				<td><%=ab.getEmail() %></td>
				<td><%=ab.getGender() %></td>
			</tr>
			<%
		}
		%>
		</table>
	</center>
</body>
</html>
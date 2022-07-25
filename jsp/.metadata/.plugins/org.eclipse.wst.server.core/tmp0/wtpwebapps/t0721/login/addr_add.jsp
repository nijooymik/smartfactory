<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%
request.setCharacterEncoding("euc-kr");
%>
<!-- useBean 사용 -->
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
		<h2>등록내용</h2>
		<hr>
		이름 : <%=addr.getUsername() %><br>
		전화번호 : <jsp:getProperty property="tel" name="addr"/><br>
		이메일 : <jsp:getProperty property="email" name="addr"/><br>
		성별 : <%=addr.getGender() %><br>
		<hr>
		<a href="addr_list.jsp">목록보기</a><p>
	</center>
</body>
</html>
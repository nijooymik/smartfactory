<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!-- useBean사용 -->
<jsp:useBean id="login" scope="page" class="com.jsp.LoginBean">
	<jsp:setProperty name="login" property="*" />
</jsp:useBean>
<!DOCTYPE html>
<%
if (!login.checkUser()) {
	out.print("<script> alert('로그인 실패')</script>");
} else
	out.print("<script> alert('로그인 성공')</script>");
%>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<center>
		<h2>로그인 확인</h2>
		<hr>
		사용자 아이디 :
		<jsp:getProperty property="userid" name="login" />
		사용자 비밀번호 :
		<jsp:getProperty property="passwd" name="login" />
	</center>
</body>
</html>
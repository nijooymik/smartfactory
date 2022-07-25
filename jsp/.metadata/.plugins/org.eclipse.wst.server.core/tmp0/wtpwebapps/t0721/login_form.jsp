<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%
// 세션 정보
String cust_id = (String) session.getAttribute("cust_id");
String cust_name = (String) session.getAttribute("cust_name");
Boolean login = false;

if ((cust_id != null) && (cust_name != null)) {
	// 로그인 상태
	login = true;
}
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
<style>
table {
	width: 250px;
	text-align: center;
	border-collapse: collaps;
	background-color: #daf0e4;
}

td {
	border: 1px solid grey;
	font-weight: bold;
	padding: 2px;
	text-align: left;
}
</style>
</head>
<body>
	<center>
		<h2>로그인 화면</h2>
		<hr>
		<form action="login_check.jsp" method="post">
			<table>
				<tr>
					<td>아이디</td>
					<td><input type="text" name="cust_id" size=15></td>
				</tr>
				<tr>
					<td>비밀번호</td>
					<td><input type="password" name="cust_pw" size=15></td>
				</tr>
				<tr align=center>
					<td colspan=2>
						<%
						if (login) { // 로그인 상태
							out.print("<input type='submit' value='로그인' disabled>" + "<input type='button' value='"+cust_name+"님 로그아웃'"
							+ "onClick=location.href='logout.jsp'>");
						} else { // 로그아웃 상태
							out.print("<input type='submit' value='로그인'>" + "<input type='button' value='로그아웃' disabled>");
						}
						%>
					</td>
				</tr>
			</table>
		</form>
	</center>
</body>
</html>
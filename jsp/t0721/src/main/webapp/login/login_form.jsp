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
		<h1>로그인</h1>
		<hr>
		<p>
		<form action="login.jsp" method="post">
			<table>
				<tr>
					<td colspan=2 align=center>로그인</td>
				</tr>
				<tr>
					<td>아이디</td>
					<td><input type="text" name="userid" size=15></td>
				</tr>
				<tr>
					<td>비밀번호</td>
					<td><input type="text" name="passwd" size=15></td>
				</tr>
				<tr>
					<td colspan=2 align=center><input type="submit" value="로그인"></td>
				</tr>
			</table>
		</form>
	</center>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<style>
	table {width:400px;border:2px solid black;border-collapse:collapse;}
	td {background-color:yellowgreen;text-align:center;border:1px solid gray;padding:3px;}
</style>
<title>Insert title here</title>
</head>
<body>
	<h2>회원가입</h2>
	<hr>
	<form action="customer_re.jsp" method="post">
		<table border=1>
			<caption>회원가입창</caption>
			<tr>
				<td>아이디</td>
				<td><input type="text" name="id"></td>
			</tr>
			<tr>
				<td>비밀번호</td>
				<td><input type="text" name="pw"></td>
			</tr>
			<tr>
				<td>이름</td>
				<td><input type="text" name="name"></td>
			</tr>
			<tr>
				<td>성별</td>
				<td><input type="radio" name="gender" value="M">남자
					&nbsp;&nbsp;<input type="radio" name="gender" value="F">여자</td>
			</tr>
			<tr>
				<td>취미</td>
				<td><input type="checkbox" name="hobby" value="등산">등산 <input
					type="checkbox" name="hobby" value="잠자기">잠자기 <input
					type="checkbox" name="hobby" value="춤추기">춤추기 <input
					type="checkbox" name="hobby" value="먹기">먹기 <input
					type="checkbox" name="hobby" value="달리기">달리기</td>
			</tr>
			<tr>
				<td colspan=2><input type="submit" value="확인"> <input
					type="reset" value="취소"></td>
			</tr>
		</table>
	</form>
</body>
</html>
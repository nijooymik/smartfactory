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
		<h1>request 테스트 폼</h1>
		<hr>
		<form action="re.jsp" method="post">

			<table border=1>
				<tr>
					<td>이름</td>
					<td><input type="text" name="name"></td>
				</tr>
				<tr>
					<td>직업</td>
					<td><select name="job">
							<option>회사원</option>
							<option>전문직</option>
							<option selected>학생</option>
							<option>무직</option></td>
				</tr>
				<tr>
					<td>관심분야</td>
					<td><input type="checkbox" name="fav" value="정치">정치 <input
						type="checkbox" name="fav" value="사회">사회 <input
						type="checkbox" name="fav" value="정보통신">정보통신</td>
				</tr>
				<tr>
					<td colspan=2 align=center><input type="submit" value="확인">
						<input type="reset" value="취소"></td>
				</tr>



			</table>
	</center>
</body>
</html>
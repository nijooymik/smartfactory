<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%
request.setCharacterEncoding("euc-kr");
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<div align=center>
		<h2>�ּҷ� ���</h2>
		<hr>
		<form action="addr_add.jsp" method="post" name="form1">
			<table>
				<tr>
					<td>�̸�</td>
					<td><input type="text" name="username"></td>
				</tr>
				<tr>
					<td>��ȭ��ȣ</td>
					<td><input type="text" name="tel"></td>
				</tr>
				<tr>
					<td>�̸���</td>
					<td><input type="text" name="email"></td>
				</tr>
				<tr>
					<td>����</td>
					<td><select name=gender>
							<option>��</option>
							<option>��</option>
					</select></td>
				</tr>
				<tr>
					<td colspan=2><input type="submit" value="Ȯ��"> 
					<input type="reset" value="���"></td>
				</tr>
			</table>
		</form>
	</div>
</body>
</html>
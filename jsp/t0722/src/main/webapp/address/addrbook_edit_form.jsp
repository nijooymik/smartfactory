<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR" errorPage="addrbook_error.jsp"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
<link rel="stylesheet" href="addrbook.css" type="text/css"
	media="screen" />
</head>
<body>
	<div align=center>
		<h2>�ּҷ� ����ȭ��</h2>
		<hr>
		[<a href="addrbook_list.jsp">�ּҷ� ���</a>]
		<p>
		<form method=post action="addrbook_control.jsp">
		<input type="hidden" name="action" value="update">
			<table border=1>
				<tr>
					<th>�̸�</th>
					<td><input type="text" name="ab_name" maxlength=15></td>
				</tr>
				<tr>
					<th>email</th>
					<td><input type="text" name="ab_email" maxlength=20></td>
				</tr>
				<tr>
					<th>��ȭ��ȣ</th>
					<td><input type="text" name="ab_comdept" maxlength=20></td>
				</tr>
				<tr>
					<th>����</th>
					<td><input type="date" name="ab_birth"></td>
				</tr>
				<tr>
					<th>ȸ��</th>
					<td><input type="text" name="ab_tel" maxlength=15></td>
				</tr>
				<tr>
					<th>�޸�</th>
					<td><input type="text" name="ab_memo" maxlength=20></td>
				</tr>
				<tr>
					<td colspan=2><input type="submit" value="Ȯ��">
					<input type="reset" value="Ȯ��">
					<input type="button" value="����" onClick="delCheck()"></td>
				</tr>
			</table>
		</form>
	</div>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<%
// ��� ���
int result = 0;
// �������� ��û�ϴ� post �� ��쿡 form���� ������ ����
if (request.getMethod().equals("POST")) {
	// ������ �ޱ�
	String op = request.getParameter("op");
	// ���ڹޱ�, �� ���ڿ��� ���ڷ� ��ȯ�ϱ�
	int num1 = Integer.parseInt(request.getParameter("num1"));
	int num2 = Integer.parseInt(request.getParameter("num2"));
	if (op.equals("+")) {
		result = num1 + num2;
	} else if (op.equals("-")) {
		result = num1 - num2;
	} else if (op.equals("*")) {
		result = num1 * num2;
	} else if (op.equals("/")) {
		result = num1 / num2;
	} else {
		out.print("�߸��Է�");
	}
}
%>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<div align=center>
		<h3>����</h3>
		<hr>
		<form method=post>
			<input type="text" name="num1"> <select name="op">
				<option>+</option>
				<option>-</option>
				<option>*</option>
				<option>/</option>
			</select> <input type="text" name="num2"> <br> <input
				type="submit" value="Ȯ��"> <input type="reset" value="���">
		</form>
	</div>
	����� :
	<%=result%>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<%
// 결과 출력
int result = 0;
// 웹페이지 요청하는 post 인 경우에 form에서 데이터 전달
if (request.getMethod().equals("POST")) {
	// 연산자 받기
	String op = request.getParameter("op");
	// 숫자받기, 단 문자열을 숫자로 변환하기
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
		out.print("잘못입력");
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
		<h3>계산기</h3>
		<hr>
		<form method=post>
			<input type="text" name="num1"> <select name="op">
				<option>+</option>
				<option>-</option>
				<option>*</option>
				<option>/</option>
			</select> <input type="text" name="num2"> <br> <input
				type="submit" value="확인"> <input type="reset" value="취소">
		</form>
	</div>
	계산결과 :
	<%=result%>
</body>
</html>
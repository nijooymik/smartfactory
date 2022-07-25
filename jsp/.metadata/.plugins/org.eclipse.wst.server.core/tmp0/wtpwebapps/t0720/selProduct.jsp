<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<%
	request.setCharacterEncoding("euc-kr");
	session.setAttribute("username", request.getParameter("username"));
	%>
	<center>
		<h2>상품 선택</h2>
		<hr>
		<%=session.getAttribute("username")%>님이 로그인한 상태입니다.<br>
		<form name=fr method="post" action="add.jsp">
			<select name="product">
				<option>사과</option>
				<option>수박</option>
				<option>바나나</option>
				<option>파인애플</option>
				<option>자몽</option>
				<option>레몬</option>
			</select> <input type="submit" value="추가">
		</form>
		<a href="checkOut.jsp">계산</a>
	</center>
</body>
</html>
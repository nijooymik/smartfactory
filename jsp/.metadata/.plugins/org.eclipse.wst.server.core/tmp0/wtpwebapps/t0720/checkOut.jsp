<%@ page import="java.util.ArrayList"%>
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
		<h2>선택한 상품 목록</h2>
		<hr>
		<%
		ArrayList list = (ArrayList) session.getAttribute("productlist");
		if (list == null) {
			out.print("선택한 상품이 없음");
		} else {
			for (Object productName : list) {
				out.print(productName + "<br>");
			}
		}
		%>
	</center>
</body>
</html>
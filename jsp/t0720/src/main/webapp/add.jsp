<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR"%>
<%@page import="java.util.*"%>
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
	<%
	String productName = request.getParameter("product");
	ArrayList list = (ArrayList) session.getAttribute("productlist");

	if (list == null) {
		list = new ArrayList();
	}
	session.setAttribute("productlist",list);
	list.add(productName);
	%>
	<script>
	alert("<%=productName%> �߰�");
		history.go(-1)
	</script>
</body>
</html>
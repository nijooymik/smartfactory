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
	<h2>회원가입 결과 창</h2>
	<hr>
	아이디 :
	<%=request.getParameter("id")%><br> 비밀번호 :
	<%=request.getParameter("pw")%><br> 이름 :
	<%=request.getParameter("name")%><br> 성별 :
	<%=request.getParameter("gender")%><br> 취미 :
	<%
	String hobbies[] = request.getParameterValues("hobby");
	for (String h : hobbies) {
		out.print(h + "<br>");
	}
	
		response.sendRedirect("customer.jsp");
	%>

	<a href="customer.jsp">회원가입창으로 </a>
	<br>
</body>
</html>
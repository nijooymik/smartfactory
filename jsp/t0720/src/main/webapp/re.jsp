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
	<center>
		<h1>request 테스트 결과화면</h1>
		<hr>
		<form action="re.jsp" method="post">
			<table border=1>
				<tr>
					<td>이름</td>
					<td><%=request.getParameter("name")%></td>
				</tr>
				<tr>
					<td>직업</td>
					<td><%=request.getParameter("job")%></td>
				</tr>
				<tr>
					<td>관심분야</td>
					<td>
						<%
						String favs[] = request.getParameterValues("fav");
						for (String f : favs) {
							out.print(f + "&nbsp;&nbsp; ");
						}
						%>
					</td>
				</tr>
				<tr>
					<td colspan=2 align=center></td>
				</tr>



			</table>
	</center>
</body>
</html>
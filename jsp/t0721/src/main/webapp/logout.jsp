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
		技记 加己(id) : <%=session.getAttribute("cust_id")%><br> 
		技记 加己(cust_name) : <%=session.getAttribute("cust_name")%><br>
		<%
		out.print("<br>" + session.getAttribute("cust_id") + "(" + session.getAttribute("cust_name") + ") 丛 肺弊牢 吝 ...</b><p>");

		out.print("<b>" + session.getCreationTime() + "檬<br></b>");
		out.print("蜡瓤矫埃" + session.getMaxInactiveInterval() + "檬<br>");

		// 技记 加己 昏力

		session.removeAttribute("cust_id");
		session.removeAttribute("cust_name");

		out.print("技记(id) " + session.getAttribute("cust_id"));
		out.print("技记(name) " + session.getAttribute("cust_name"));

		// 技记 檬扁拳
		session.invalidate();

		out.print("肺弊酒眶 凳<br>");
		%>
		<a href="login_form.jsp">技记 昏力犬牢</a><br>
	</center>
</body>
</html>
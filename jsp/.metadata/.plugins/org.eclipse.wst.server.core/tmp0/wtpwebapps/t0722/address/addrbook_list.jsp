<%@ page language="java" contentType="text/html; charset=EUC-KR"
	pageEncoding="EUC-KR" errorPage="addrbook_error.jsp"%>
<%@page import="java.util.*,com.jsp.AddrBook"%>
<!DOCTYPE html>
<jsp:useBean id="datas" class="java.util.ArrayList" scope="request" />
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
<link rel="stylesheet" href="addrbook.css" type="text/css"
	media="screen" />
<script>
	function check(ab_id) {
		pwd = prompt('수정/삭제 하려면 비번 넣으시오.');
		document.location.href = "addrbook_control.jsp?action=edit&ab_id="
				+ ab_id + "&upasswd=" + pwd;
	}
</script>
</head>
<body>
	<div align=center>
		<h2>주소록 목록화면</h2>
		<hr>
		<form>
			<a href="addrbook_form.jsp">주소록 등록</a>
			<p>
				<input type=hidden name="action" value="list">
			<table border=1>
				<tr>
					<th>번호</th>
					<th>이름</th>
					<th>전화번호</th>
					<th>이메일</th>
					<th>생일</th>
					<th>회사</th>
					<th>메모</th>
				</tr>
				<tr>
					<%
				for(AddrBook ab : (ArrayList<AddrBook>)datas){%>
					<td><a href="javascript:check(<%=ab.getAb_id() %>)"><%=ab.getAb_id() %></a></td>}
					<td><%=ab.getAb_name() %></td>
					<td><%=ab.getAb_email() %></td>
					<td><%=ab.getAb_comdept() %></td>
					<td><%=ab.getAb_birth() %></td>
					<td><%=ab.getAb_tel() %></td>
					<td><%=ab.getAb_memo() %></td>
				</tr>
				<%} %>
				<!-- <tr>
					<td><a href="addrbook_edit_form.jsp">1</a></td>
					<td>김유진</td>
					<td>010-8994-6342</td>
					<td>29yoojin@gmail.com</td>
					<td>1995-2-9</td>
					<td>OO회사</td>
					<td>^_^</td>
				</tr>
				<tr>
					<td><a href="addrbook_edit_form.jsp">2</a></td>
					<td>김유진</td>
					<td>010-8994-6342</td>
					<td>29yoojin@gmail.com</td>
					<td>1995-2-9</td>
					<td>OO회사</td>
					<td>^_^</td>
				</tr> -->
			</table>
		</form>
	</div>
</body>
</html>
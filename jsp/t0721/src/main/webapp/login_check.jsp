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
		<%
		// db 고객 정보
		String user_id = "root";
		String user_pw = "1234";
		String user_name = "김유진";

		// 전송 데이터 변수 할당 및 확인
		String cust_id = request.getParameter("cust_id");
		String cust_pw = request.getParameter("cust_pw");

		if (cust_id.isEmpty() || cust_pw.isEmpty()) {
			out.print("<script> alert('아이디와 비밀번호를 입력하시오');" + "history.back() </script>");
		}

		// 로그인 인증 및 세션 설정
		if (cust_id.equals(user_id) && cust_pw.equals(user_pw)) {
			session.setAttribute("cust_id", user_id);
			session.setAttribute("cust_name", user_name);
			out.print("<b>" + session.getAttribute("cust_id") + "(" + session.getAttribute("cust_name") + ")님 환영합니다.</b><br>");
		} else {
			out.print("회원 가입을 하시오.<br>");
		}
		%>
		세션 속성(id) : <%=session.getAttribute("cust_id")%><br> 
		세션 속성(cust_name) : <%=session.getAttribute("cust_name")%><br>
		
		<a href="login_form.jsp">로그인 폼으로 이동</a>
		<p>
	</center>
</body>
</html>
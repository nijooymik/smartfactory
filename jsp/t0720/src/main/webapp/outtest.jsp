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
	out.print("버퍼크기 : " + out.getBufferSize() + "<br>");
	out.print("남은버퍼크기 : " + out.getRemaining() + "<br>");
	out.flush();
	out.print("버퍼크기 : " + out.getBufferSize() + "<br>");
	out.print("남은버퍼크기 : " + out.getRemaining() + "<br>");
	out.print(out.isAutoFlush());
	%>
</body>
</html>
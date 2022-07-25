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
//스크립트 릿
// 1부터 10까지 출력한 후 합계 구하기
	int j=0;
	for(int i=0;i<=10;i++)
	{
		out.print(i+" ");
		j = j + i;
	}
	out.println("<br>");
	out.println("합계 : " + j);
	%>
</body>
</html>
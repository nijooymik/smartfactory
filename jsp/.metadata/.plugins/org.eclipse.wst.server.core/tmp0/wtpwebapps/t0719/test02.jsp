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
//��ũ��Ʈ ��
// 1���� 10���� ����� �� �հ� ���ϱ�
	int j=0;
	for(int i=0;i<=10;i++)
	{
		out.print(i+" ");
		j = j + i;
	}
	out.println("<br>");
	out.println("�հ� : " + j);
	%>
</body>
</html>
<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<%@page import="java.time.*, java.time.format.DateTimeFormatter" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>
	<center>
	
<%
	//�ڹ��ڵ� �ۼ�...
	LocalTime loctime = LocalTime.now();
	out.print("LocalTime "+ loctime + "<br>");
	//�ð�����
	DateTimeFormatter hms= DateTimeFormatter.ofPattern("HH:mm:ss");
	String time1 = loctime.format(hms);
	
	String time2 = loctime.format(DateTimeFormatter.ofPattern("HH/mm/ss"));
	
	out.print("time1: "+time1+"<br>");
	out.print("time2: "+time2+"<br>");
	
	String strtime = loctime.getHour()+"��";
	strtime+=loctime.getMinute()+"��";
	strtime+=loctime.getSecond()+"��";
	strtime+=loctime.getNano()+"������";
	
	out.print("�޼ҵ� �̿� "+strtime);
	%> 
	
	</center>
</body>
</html>
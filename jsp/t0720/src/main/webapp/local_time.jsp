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
	//자바코드 작성...
	LocalTime loctime = LocalTime.now();
	out.print("LocalTime "+ loctime + "<br>");
	//시간관련
	DateTimeFormatter hms= DateTimeFormatter.ofPattern("HH:mm:ss");
	String time1 = loctime.format(hms);
	
	String time2 = loctime.format(DateTimeFormatter.ofPattern("HH/mm/ss"));
	
	out.print("time1: "+time1+"<br>");
	out.print("time2: "+time2+"<br>");
	
	String strtime = loctime.getHour()+"시";
	strtime+=loctime.getMinute()+"분";
	strtime+=loctime.getSecond()+"초";
	strtime+=loctime.getNano()+"나노초";
	
	out.print("메소드 이용 "+strtime);
	%> 
	
	</center>
</body>
</html>
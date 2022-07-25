<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
<link rel="stylesheet" href="addrbook.css" type="text/css" media="screen"/>
<script>
	function check(ab_id){
		pwd = prompt('수정/삭제하려면 비번을 넣으시오.');
		document.location.href="addrbook_control.jsp?action=edit&ab_id="+
				ab_id+"&upasswd"+pwd;
	}
</script>
</head>
<body>
<div>
><
</div>
</body>
</html>
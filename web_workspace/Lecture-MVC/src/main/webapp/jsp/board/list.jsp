<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<!-- forEach 사용 시 태그라이브러리 필요 -->
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<div align="center">
		<h2>전체게시글 조회</h2>

		<table border="1" style="width: 80%">
			<tr>
				<th width="7%">번호</th>
				<th>제목</th>
				<th width="15%">작성자</th>
				<th width="17%">등록일</th>
			</tr>
			<c:forEach items="${ list }" var="board">
				<tr>
					<td>${ board.no }</td>
					<td>${ board.title }</td>
					<td>${ board.writer }</td>
					<td>${ board.regDate }</td>
				</tr>
			</c:forEach>
		</table>
	</div>
	<!-- 
	<c:forEach items="${ list }" var="board">
	${ board.title } : ${ board.writer }<br>
	</c:forEach> -->
</body>
</html>
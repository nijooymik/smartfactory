<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>
    <%@page import="java.util.*, com.jsp.AddrBook" %>
    <%request.setCharacterEncoding("euc-kr"); %>
    <jsp:useBean id="gb" scope="page" class="com.jsp.AddrBean"/>
    <jsp:useBean id="addrbook" class="com.jsp.AddrBook"/>
    <jsp:setProperty name="addrbook" property="*"/>
    
<%
   String action = request.getParameter("action");
   if(action.equals("insert")){   //삽입
      if(gb.insertDB(addrbook)){
         response.sendRedirect("addrbook_control.jsp?action=list");
      }else throw new Exception("DB 입력 오류");
   
   }else if(action.equals("list")){   //목록
      ArrayList<AddrBook> datas = gb.getDBList();
      request.setAttribute("datas", datas);
      pageContext.forward("addrbook_list.jsp");
      
   }else if(action.equals("edit")){   // 수정 
      AddrBook gbook = gb.getDB(addrbook.getAb_id());
      if(!request.getParameter("upasswd").equals("a1234")){
         out.print("<script> alert('비밀번호가 틀림 다시 입력ㄱ'); history.go(-1);</script>");
      }else{
         request.setAttribute("gb",gbook);
         pageContext.forward("addrbook_edit_form.jsp");
      }
   }else if(action.equals("update")){   // 수정 적용
      if(gb.updateDB(addrbook)){
         response.sendRedirect("addrbook_control.jsp?action=list");
      }else throw new Exception("DB 갱신오류");
   
   }else if(action.equals("delete")){   // 삭제
      
   }else{
      if(gb.deleteDB(addrbook.getAb_id())){
         response.sendRedirect("addrbook_control.jsp?action=list");
      }else{
         out.print("<script> alert('action 파라미터 확인하시오');</script>");
      }
      
   }

%>
<!DOCTYPE html>
<html>
<head>
<meta charset="EUC-KR">
<title>Insert title here</title>
</head>
<body>

</body>
</html>
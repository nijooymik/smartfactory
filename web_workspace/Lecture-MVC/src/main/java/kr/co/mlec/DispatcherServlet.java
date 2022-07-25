package kr.co.mlec;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.controller.BoardListController;
import kr.co.mlec.controller.BoardWriteFormController;
import kr.co.mlec.controller.Controller;

@WebServlet("*.do")
public class DispatcherServlet extends HttpServlet { // 클래스

	@Override
	protected void service(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		String context = request.getContextPath();
		System.out.println("context : " + context);
		String uri = request.getRequestURI();
		uri = uri.substring(context.length());
		System.out.println("호출 uri : " + uri);

		Controller control = null;
		String callPage = "";
		try {
			switch (uri) {
			case "/board/list.do":
				control = new BoardListController(); // 묵시적형변환
				break;
			case "/board/writeForm.do":
				control = new BoardWriteFormController();
				break;
			}

			if (control != null) {
				callPage = control.handleRequest(request, response);
				RequestDispatcher dispatcher = request.getRequestDispatcher(callPage);
				dispatcher.forward(request, response);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
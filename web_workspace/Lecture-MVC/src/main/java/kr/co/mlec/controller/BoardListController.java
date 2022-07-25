package kr.co.mlec.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import kr.co.mlec.board.dao.BoardDAO;
import kr.co.mlec.board.vo.BoardVO;

public class BoardListController implements Controller {

	public String handleRequest(HttpServletRequest request, HttpServletResponse response) /* throws Exception */ {

		BoardDAO dao = new BoardDAO();
		List<BoardVO> list = dao.selectAll();

		// 공유영역(request) 등록
		request.setAttribute("list", list);

		return "/jsp/board/list.jsp";
	}

}

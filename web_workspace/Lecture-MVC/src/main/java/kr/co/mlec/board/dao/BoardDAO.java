package kr.co.mlec.board.dao;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import kr.co.mlec.board.vo.BoardVO;

/**
 * t_board 테이블의 게시판 데이터 CRUD 기능클래스
 * 
 * @author user
 * 
 */
public class BoardDAO {

	/**
	 * 전체게시글 조회 기능
	 */
	public List<BoardVO> selectAll() {

		List<BoardVO> boardList = new ArrayList<>();
		Connection conn = null;
		PreparedStatement pstmt = null;

		try

		{
			// 1단계 : 드라이버 로딩
			Class.forName("oracle.jdbc.driver.OracleDriver");

			// 2단계 : DB접속 및 연결객체(Connection) 얻어오기
			String url = "jdbc:oracle:thin:@localhost:1521:orcl";
			String user = "c##com";
			String password = "a1234";
			conn = DriverManager.getConnection(url, user, password);
			System.out.println("conn : " + conn);

			// 3단계 : SQL 생성 및 쿼리실행객체(PreparedStatement) 얻어오기
			StringBuilder sql = new StringBuilder();
			sql.append("select no, title, writer, to_char(reg_date, 'yyyy-mm-dd') as reg_date");
			sql.append(" from t_board ");
			sql.append(" order by no desc ");

			pstmt = conn.prepareStatement(sql.toString());

			// 4단계 : 쿼리실행 및 결과 반환
			ResultSet rs = pstmt.executeQuery();

			while (rs.next()) {
				int no = rs.getInt("no");
				String title = rs.getString("title");
				String writer = rs.getString("writer");
				String regDate = rs.getString("reg_date");

				BoardVO board = new BoardVO();
				board.setNo(no);
				board.setTitle(title);
				board.setWriter(writer);
				board.setRegDate(regDate);

				boardList.add(board);
//				System.out.println(board);
			}

		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			// 5단계 : DB접속(PreparedStatement, Connect) 종료
			try {
				pstmt.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			try {
				conn.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}

		return boardList;
	}
}

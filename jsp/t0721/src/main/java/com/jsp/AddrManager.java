package com.jsp;

import java.util.ArrayList;
import java.util.List;

public class AddrManager {
	List<AddrBean> addrlist = new ArrayList<AddrBean>();
	
	// 메소드(데이터추가(폼에서 입력된 데이터(이름, 전화번호, 이메일, 성별))
	public void add(AddrBean ab) {
		addrlist.add(ab);
	}
	
	// 메소드(데이터 출력)
	public List<AddrBean> getAddrList(){
		return addrlist;
	}

	public List<AddrBean> getAddrlist() {
		return addrlist;
	}

	public void setAddrlist(List<AddrBean> addrlist) {
		this.addrlist = addrlist;
	}
}

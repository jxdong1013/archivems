package com.jxd.archiveapp.bean;

/**
 * Created by Administrator on 2016/2/15.
 */
public class ScanBean extends BoxBean {
    private String status;
     /***
     *  借出时间
     */
    private String borrowDate;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getBorrowDate() {
        return borrowDate;
    }

    public void setBorrowDate(String borrowDate) {
        this.borrowDate = borrowDate;
    }

}

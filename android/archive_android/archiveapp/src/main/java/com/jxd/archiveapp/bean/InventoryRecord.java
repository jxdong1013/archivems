package com.jxd.archiveapp.bean;

/**
 * Created by Administrator on 2016/2/16.
 */
public class InventoryRecord {
    private String floorrfid;
    private String boxrfid;
    private String status;
    private String borrowstatus;
    private String borrowdate;

    public String getFloorrfid() {
        return floorrfid;
    }

    public void setFloorrfid(String floorrfid) {
        this.floorrfid = floorrfid;
    }

    public String getBoxrfid() {
        return boxrfid;
    }

    public void setBoxrfid(String boxrfid) {
        this.boxrfid = boxrfid;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getBorrowdate() {
        return borrowdate;
    }

    public void setBorrowdate(String borrowdate) {
        this.borrowdate = borrowdate;
    }

    public String getBorrowstatus() {
        return borrowstatus;
    }

    public void setBorrowstatus(String borrowstatus) {
        this.borrowstatus = borrowstatus;
    }
}

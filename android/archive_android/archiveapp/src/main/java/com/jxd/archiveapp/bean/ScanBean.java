package com.jxd.archiveapp.bean;

/**
 * Created by Administrator on 2016/2/15.
 */
public class ScanBean extends BoxBean {
    private String status;

    /***
     * 0:在库，1：有借已还，2：有借未还
     */
    private int inventoryStatus;

     /***
     *  借出时间
     */
    private String borrowDateString;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getBorrowDateString() {
        return borrowDateString;
    }

    public void setBorrowDateString(String borrowDateString) {
        this.borrowDateString = borrowDateString;
    }

    public int getInventoryStatus() {
        return inventoryStatus;
    }

    public void setInventoryStatus(int inventoryStatus) {
        this.inventoryStatus = inventoryStatus;
    }
}

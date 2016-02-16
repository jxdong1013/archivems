package com.jxd.archiveapp.bean;

import java.util.List;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryBean {
    private String title;
    private int operateid;
    private String operatename;
    private List<InventoryRecord> records;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public int getOperateid() {
        return operateid;
    }

    public void setOperateid(int operateid) {
        this.operateid = operateid;
    }

    public String getOperatename() {
        return operatename;
    }

    public void setOperatename(String operatename) {
        this.operatename = operatename;
    }

    public List<InventoryRecord> getRecords() {
        return records;
    }

    public void setRecords(List<InventoryRecord> records) {
        this.records = records;
    }

}

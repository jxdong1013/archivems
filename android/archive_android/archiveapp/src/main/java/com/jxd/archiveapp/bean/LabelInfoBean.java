package com.jxd.archiveapp.bean;

/**
 * Created by 向东 on 2016-2-3.
 */
public class LabelInfoBean {
    private String type;
    private String name;
    private String rfid;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getRfid() {
        return rfid;
    }

    public void setRfid(String rfid) {
        this.rfid = rfid;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
}

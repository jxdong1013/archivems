package com.jxd.archiveapp.bean;

import java.util.List;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryBean {
    private String floorrfid;
    private String floorname;
    //private String boxrfid;
    //private String boxname;
    private int boxcount;
    private int inventorycount;
    private List<ScanBean> boxs;

    public String getFloorrfid() {
        return floorrfid;
    }

    public void setFloorrfid(String floorrfid) {
        this.floorrfid = floorrfid;
    }

    public String getFloorname() {
        return floorname;
    }

    public void setFloorname(String floorname) {
        this.floorname = floorname;
    }

//    public String getBoxrfid() {
//        return boxrfid;
//    }
//
//    public void setBoxrfid(String boxrfid) {
//        this.boxrfid = boxrfid;
//    }
//
//    public String getBoxname() {
//        return boxname;
//    }

//    public void setBoxname(String boxname) {
//        this.boxname = boxname;
//    }

    public int getBoxcount() {
        return boxcount;
    }

    public void setBoxcount(int boxcount) {
        this.boxcount = boxcount;
    }

    public int getInventorycount() {
        return inventorycount;
    }

    public void setInventorycount(int inventorycount) {
        this.inventorycount = inventorycount;
    }

    public List<ScanBean> getBoxs() {
        return boxs;
    }

    public void setBoxs(List<ScanBean> boxs) {
        this.boxs = boxs;
    }
}

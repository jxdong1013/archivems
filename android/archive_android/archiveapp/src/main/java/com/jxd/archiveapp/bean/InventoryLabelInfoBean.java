package com.jxd.archiveapp.bean;

import java.util.List;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryLabelInfoBean extends LabelInfoBean {
    private List<ScanBean> boxs;

    public List<ScanBean> getBoxs() {
        return boxs;
    }

    public void setBoxs(List<ScanBean> boxs) {
        this.boxs = boxs;
    }
}

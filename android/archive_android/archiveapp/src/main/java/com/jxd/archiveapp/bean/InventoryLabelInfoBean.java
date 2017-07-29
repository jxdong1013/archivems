package com.jxd.archiveapp.bean;

import java.util.List;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryLabelInfoBean extends LabelInfoBean {
    private List<ScanBean> boxs;
    //private List<ArchiveBean> archives;

    public List<ScanBean> getBoxs() {
        return boxs;
    }

    public int getBoxCount(){
        return  boxs==null ? 0 : boxs.size();
    }

    public void setBoxs(List<ScanBean> boxs) {
        this.boxs = boxs;
    }

//    public List<ArchiveBean> getArchives() {
//        return archives;
//    }

//    public void setArchives(List<ArchiveBean> archives) {
//        this.archives = archives;
//    }
}

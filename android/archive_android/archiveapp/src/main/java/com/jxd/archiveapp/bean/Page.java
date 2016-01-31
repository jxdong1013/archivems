package com.jxd.archiveapp.bean;

import java.util.List;

/**
 * Created by 向东 on 2016-1-31.
 */
public class Page {
    private int PageIdx ;
    private int PageSize ;
    private int TotalRecords ;
    private int TotalPages ;

    private String Key ;

    private List<ArchiveBean> Data ;

    public List<ArchiveBean> getData() {
        return Data;
    }

    public void setData(List<ArchiveBean> data) {
        Data = data;
    }

    public String getKey() {
        return Key;
    }

    public void setKey(String key) {
        Key = key;
    }

    public int getPageIdx() {
        return PageIdx;
    }

    public void setPageIdx(int pageIdx) {
        PageIdx = pageIdx;
    }

    public int getPageSize() {
        return PageSize;
    }

    public void setPageSize(int pageSize) {
        PageSize = pageSize;
    }

    public int getTotalPages() {
        return TotalPages;
    }

    public void setTotalPages(int totalPages) {
        TotalPages = totalPages;
    }

    public int getTotalRecords() {
        return TotalRecords;
    }

    public void setTotalRecords(int totalRecords) {
        TotalRecords = totalRecords;
    }
}

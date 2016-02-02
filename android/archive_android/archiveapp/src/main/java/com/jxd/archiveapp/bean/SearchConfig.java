package com.jxd.archiveapp.bean;

/**
 * 搜索组件
 * Created by jinxiangdong on 2016/1/14.
 */
public class SearchConfig{
    private String widgetBackColor;
    private int verticalDistance;
    private int aroundDistance;
    /**
     * 搜索样式:
     * custom-search-style-A;
     * custom-search-style-B
     */
    private String searchStyle;

    public String getWidgetBackColor() {
        return widgetBackColor;
    }

    public void setWidgetBackColor(String widgetBackColor) {
        this.widgetBackColor = widgetBackColor;
    }

    public int getVerticalDistance() {
        return verticalDistance;
    }

    public void setVerticalDistance(int verticalDistance) {
        this.verticalDistance = verticalDistance;
    }

    public int getAroundDistance() {
        return aroundDistance;
    }

    public void setAroundDistance(int aroundDistance) {
        this.aroundDistance = aroundDistance;
    }

    public String getSearchStyle() {
        return searchStyle;
    }

    public void setSearchStyle(String searchStyle) {
        this.searchStyle = searchStyle;
    }
}

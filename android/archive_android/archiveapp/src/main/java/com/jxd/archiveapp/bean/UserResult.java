package com.jxd.archiveapp.bean;

/**
 * Created by 向东 on 2016-1-30.
 */
public class UserResult extends BaseBean {
    private UserBean Data;

    public UserBean getData() {
        return Data;
    }

    public void setData(UserBean data) {
        Data = data;
    }
}

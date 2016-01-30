package com.jxd.archive_android;

import android.app.Application;

/**
 * Created by Administrator on 2016/1/26.
 */
public class MApplication extends Application {
    @Override
    public void onCreate() {
        super.onCreate();

        CrashHandler crashHandler = CrashHandler.getInstance();
        crashHandler.init(this);
    }
}

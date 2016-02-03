package com.jxd.archive_android;

import android.app.Application;

/**
 * Created by Administrator on 2016/1/26.
 */
public class MApplication extends Application {
    public static MApplication app;

    @Override
    public void onCreate() {
        super.onCreate();

        app = this;
        CrashHandler crashHandler = CrashHandler.getInstance();
        crashHandler.init(this);
    }
}

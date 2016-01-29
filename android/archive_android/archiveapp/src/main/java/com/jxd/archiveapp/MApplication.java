package com.jxd.archiveapp;

import android.app.Application;

import com.jxd.archiveapp.utils.CrashHandler;

/**
 * Created by Administrator on 2016/1/27.
 */
public class MApplication extends Application {
    private static MApplication application;
    public static MApplication getApplication(){
        return  application;
    }

    @Override
    public void onCreate() {
        super.onCreate();

        application = this;

        CrashHandler crashHandler = CrashHandler.getInstance();
        crashHandler.init(this);
    }
}

package com.jxd.archiveapp;

import android.app.Application;
import android.graphics.Typeface;

import com.jxd.archiveapp.bean.InventoryBean;
import com.jxd.archiveapp.utils.CrashHandler;

import java.util.List;

/**
 * Created by Administrator on 2016/1/27.
 */
public class MApplication extends Application {
    private static MApplication application;
    public static Typeface typeface;
    public List<InventoryBean> inventoryData;

    public static MApplication getApplication(){
        return  application;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        application = this;
        typeface = Typeface.createFromAsset( this.getAssets() , "fontawesome-webfont.ttf" );

        CrashHandler crashHandler = CrashHandler.getInstance();
        crashHandler.init(this);
    }
}

package com.jxd.archiveapp.utils;

import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.MApplication;
import com.loopj.android.http.AsyncHttpClient;
import com.loopj.android.http.AsyncHttpResponseHandler;
import com.loopj.android.http.PersistentCookieStore;
import com.loopj.android.http.RequestParams;

import org.apache.http.entity.StringEntity;

/**
 * Created by Administrator on 2016/1/27.
 */
public class AsyncHttpUtil {
    private static AsyncHttpClient client = null;

    private static String ROOTURL(){
        String url = PreferenceHelper.readString( MApplication.getApplication() , Constant.URL_FILE , Constant.URL_API);
        return url;
    }

    public static AsyncHttpClient getInstance(){
        if( client == null){
            client = new AsyncHttpClient();
            client.setTimeout(20000);
            PersistentCookieStore cookieStore = new PersistentCookieStore(MApplication.getApplication());
            client.setCookieStore(cookieStore);
        }
        return  client;
    }

    public static void get(String url , RequestParams params , AsyncHttpResponseHandler responseHandler){

        String urlStr = ROOTURL() + url;

        getInstance().get( urlStr , params , responseHandler );
    }

    public static void post ( String url , RequestParams params , AsyncHttpResponseHandler responseHandler ) {
        String urlStr = ROOTURL() + url;

        //getInstance().post( MApplication.getApplication() , urlStr , null ,params ,"application/x-www-form-urlencoded", responseHandler);
        getInstance().post(urlStr, params, responseHandler);
    }

    public static void post( String url , StringEntity params , String contentType ,AsyncHttpResponseHandler responseHandler){
        String urlStr = ROOTURL() + url;

        //getInstance().addHeader("Content-Type","charset=utf-8");
        getInstance().post( MApplication.getApplication(),  urlStr , null , params , contentType, responseHandler);
    }

}

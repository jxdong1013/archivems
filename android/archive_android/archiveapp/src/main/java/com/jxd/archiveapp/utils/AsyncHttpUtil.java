package com.jxd.archiveapp.utils;

import com.jxd.archiveapp.MApplication;
import com.loopj.android.http.AsyncHttpClient;
import com.loopj.android.http.AsyncHttpResponseHandler;
import com.loopj.android.http.PersistentCookieStore;
import com.loopj.android.http.RequestParams;

import cz.msebera.android.httpclient.client.utils.Punycode;

/**
 * Created by Administrator on 2016/1/27.
 */
public class AsyncHttpUtil {
    private static AsyncHttpClient client = null;

    public static AsyncHttpClient getInstance(){
        if( client == null){
            client = new AsyncHttpClient();
            client.setTimeout(10000);
            PersistentCookieStore cookieStore = new PersistentCookieStore(MApplication.getApplication());
            client.setCookieStore(cookieStore);
        }
        return  client;
    }

    public static void get(String url , RequestParams params , AsyncHttpResponseHandler responseHandler){
        getInstance().get( url , params , responseHandler );
    }

    public static void post ( String url , RequestParams params , AsyncHttpResponseHandler responseHandler ) {
        getInstance().post( url , params , responseHandler);
    }

}

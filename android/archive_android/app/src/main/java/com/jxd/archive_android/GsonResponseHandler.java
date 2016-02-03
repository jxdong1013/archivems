package com.jxd.archive_android;

import android.content.Context;
import android.os.Handler;
import android.os.Message;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.loopj.android.http.BaseJsonHttpResponseHandler;

//import cz.msebera.android.httpclient.Header;

import org.apache.http.Header;


/**
 * Created by Administrator on 2016/1/27.
 */
public class GsonResponseHandler<T> extends BaseJsonHttpResponseHandler<T> {
    Gson gsom;
    Class<T> tclass;
    Context context;
    Handler handler;
    public static int SUCCESS=100;
    public static int FAILTURE = 101;

    public GsonResponseHandler(Context context, Handler handler, Class<T> tclass) {
        super();

        this.context = context;
        this.handler = handler;
        gsom = new GsonBuilder().create();
        this.tclass =  tclass;
    }

//    public GsonResponseHandler(String encoding) {
//        super(encoding);
//
//        gsom = new GsonBuilder().create();
//    }


    @Override
    public void onSuccess(int statusCode, Header[] headers, String rawJsonResponse, T response) {
        Message msg = handler.obtainMessage(SUCCESS);
        msg.obj = response;
        handler.sendMessage(msg);
    }

    @Override
    public void onFailure(int statusCode, Header[] headers, Throwable throwable, String rawJsonData, T errorResponse) {
        Message msg = handler.obtainMessage(FAILTURE);
        msg.obj = throwable;
        handler.sendMessage(msg);
    }

    @Override
    protected T parseResponse(String rawJsonData, boolean isFailure) throws Throwable {

        return  gsom.fromJson( rawJsonData , tclass );

    }


}

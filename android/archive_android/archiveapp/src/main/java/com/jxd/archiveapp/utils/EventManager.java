package com.jxd.archiveapp.utils;

import android.content.Context;
import android.content.Intent;
import android.widget.Toast;

import com.jxd.archiveapp.bean.SearchEvent;

import org.greenrobot.eventbus.EventBus;
import org.greenrobot.eventbus.Subscribe;

/**
 * Created by Administrator on 2016/1/28.
 */
public class EventManager  {
    private Object context;

    public EventManager( Object context){
        this.context = context;
    }

    public void Register(){
        if( false==EventBus.getDefault().isRegistered(context)) {
            EventBus.getDefault().register(context);
        }
    }
    public void UnRegister(){
        if( true == EventBus.getDefault().isRegistered(context)) {
            EventBus.getDefault().unregister(context);
        }
    }

//    @Subscribe
//    public void onLinkEvnent(SearchEvent event){
//        //Toast.makeText(context, event.getUrl(),Toast.LENGTH_LONG).show();
//        Intent intent = new Intent( context , WebViewActivity.class);
//        intent.putExtra("url",event.getUrl());
//        context.startActivity(intent);
//    }

//    public void onEventMainThread(LinkEvent event){
//        Toast.makeText(context, event.getUrl(),Toast.LENGTH_LONG).show();
//    }
}

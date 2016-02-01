package com.jxd.archiveapp.utils;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.lang.reflect.Type;
import java.util.List;

public class JSONUtil<T>{

    private static Gson gson = null;

    static
    {
        if (null == gson)
        {
            gson = new GsonBuilder().serializeNulls().create();
        }
    }

    public String toJson(T t)
    {
        return gson.toJson(t);
    }

    public <T> List<T> toListBean(String json , Type type ){
        return gson.fromJson(json, type);
    }

    @SuppressWarnings("unchecked")
    public T toBean(String msg, T t)
    {
        // 这里起初使用
        // Type type = TypeToken<T>() {}.getType());
        // return (T) gson.fromJson(msg,type);
        // 貌似java泛型不具有传递性。只能采用Class参数的方法。有大神可以解决Type的问题请留言告知。THX。
        return (T) gson.fromJson(msg, t.getClass());
    }

}

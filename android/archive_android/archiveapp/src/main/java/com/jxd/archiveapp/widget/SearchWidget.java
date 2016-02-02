package com.jxd.archiveapp.widget;

import android.content.Context;
import android.graphics.Color;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.SearchConfig;
import com.jxd.archiveapp.utils.DensityUtils;


/**
 * 搜索组件一
 * Created by jinxiangdong on 2016/1/14.
 */
public class SearchWidget  extends LinearLayout {
//    public SearchConfig getConfig() {
//        return config;
//    }
//
//    public void setConfig(SearchConfig config) {
//        this.config = config;
//        setStyle1();
//    }

    //private SearchConfig config;
    private TextView tvName;
    private TextView tvSearch;

//    public SearchWidget(Context context , SearchConfig config) {
//        super(context);
//
//        this.config = config;
//
//        //if( this.config.getSearchStyle().equals(Constant.CUSTOM_SEARCH_STYLE_A )){
//        setStyle1();
//        //}else if(this.config.getSearchStyle().equals(Constant.CUSTOM_SEARCH_STYLE_B)){
//        //    setStyle2();
//        //}
//    }

    public SearchWidget(Context context) {
        super(context);
    }

    public SearchWidget(Context context, AttributeSet attrs) {
        super(context, attrs);

        setStyle1();
    }


    protected void setStyle1(){
        LayoutInflater layoutInflater = LayoutInflater.from(getContext());
        layoutInflater.inflate(R.layout.search_one,this,true);
        LayoutParams layoutParams = new LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        int leftpx = DensityUtils.dip2px(getContext(), 5);
        int toppx = DensityUtils.dip2px(getContext(), 5);
        //layoutParams.setMargins(leftpx, toppx, leftpx, toppx);
        this.setPadding(leftpx, toppx, leftpx , toppx );
        //this.setBackgroundColor( Color.parseColor( config.getWidgetBackColor() ) );
        this.setLayoutParams(layoutParams);

        tvSearch = (TextView)findViewById(R.id.search_one_search);

        tvName=(TextView)findViewById(R.id.search_one_text);

        tvSearch.setTypeface(MApplication.typeface);
    }

    protected void setStyle2(){

        LayoutInflater layoutInflater = LayoutInflater.from(getContext());

        layoutInflater.inflate(R.layout.search_one,this,true);

        LayoutParams layoutParams = new LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        int leftpx = DensityUtils.dip2px( getContext() , 5);
        int toppx = DensityUtils.dip2px( getContext() , 5);
        //layoutParams.setMargins( leftpx , toppx , leftpx , toppx );
        this.setPadding(leftpx, toppx, leftpx , toppx );
        //this.setBackgroundColor(Color.parseColor(config.getWidgetBackColor()));

        this.setLayoutParams(layoutParams);

        tvSearch = (TextView)findViewById(R.id.search_one_search);
        tvName=(TextView)findViewById(R.id.search_one_text);
    }
}

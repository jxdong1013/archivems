package com.jxd.archiveapp.widget;

import android.content.Context;
import android.graphics.Color;
import android.text.TextUtils;
import android.util.AttributeSet;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.SearchConfig;
import com.jxd.archiveapp.bean.SearchEvent;
import com.jxd.archiveapp.utils.DensityUtils;
import com.jxd.archiveapp.utils.PreferenceHelper;

import de.greenrobot.event.EventBus;


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
    private EditText etKey;

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

        etKey = (android.widget.EditText) findViewById(R.id.search_one_text);
        etKey.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                if (actionId == EditorInfo.IME_ACTION_SEARCH
                        || (event != null && event.getKeyCode() == KeyEvent.KEYCODE_ENTER)) {
                    if (TextUtils.isEmpty(etKey.getText())) {
                        etKey.requestFocus();
                        etKey.setError("搜索条件不能为空");
                    } else {
//                        key = etKey.getText().toString();
//                        key = key.trim();
//                        key = key.replace(",", "");
//                        key = key.replace("，", "");
//                        if (searchKeysList != null && !searchKeysList.contains(key)) {
//                            String temp = "";
//                            for (String item : searchKeysList) {
//                                if (!TextUtils.isEmpty(temp)) temp += ",";
//                                temp += item;
//                            }
//                            if (temp != "") temp = "," + temp;
//                            temp = key + temp;
//                            AddGoodsActivity.this.searchKeysList.add(0, key);
//                            keysAdapter.notifyDataSetChanged();
//                            PreferenceHelper.writeString(AddGoodsActivity.this, PRE_SEARCHKEY_FILE, PRE_SEARCHKEY_NAME, temp);
//                        }

                        EventBus.getDefault().post( new SearchEvent());

//                        handler.post(new Runnable() {
//                            @Override
//                            public void run() {
//                                goodListView.setRefreshing(true);
//                            }
//                        });
                    }
                    return true;
                }

                return false;
            }
        });
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

package com.jxd.archiveapp.widget;

import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.v7.widget.RecyclerView;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.util.AttributeSet;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.SearchAdapter;
import com.jxd.archiveapp.bean.SearchConfig;
import com.jxd.archiveapp.bean.SearchEvent;
import com.jxd.archiveapp.utils.DensityUtils;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;

import java.security.spec.KeySpec;
import java.util.ArrayList;
import java.util.List;

import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildClickListener;
import org.greenrobot.eventbus.EventBus;


/**
 * 搜索组件一
 * Created by jinxiangdong on 2016/1/14.
 */
public class SearchWidget  extends LinearLayout implements BGAOnItemChildClickListener , ViewGroup.OnClickListener{
    private TextView tvSearch;
    private EditText etKey;
    //private RecyclerView recyclerViewList;
    private List<String> keys;
    private SearchAdapter searchAdapter;
    private int MAX_SIZE=50;
    //private PopupWindow popupWindow;

    public SearchWidget(Context context) {
        super(context);
    }

    public SearchWidget(Context context, AttributeSet attrs) {
        super(context, attrs);
        setStyle1();
    }

//    protected void createPopwindow(){
//        recyclerViewList = new RecyclerView(getContext());
//
//        popupWindow = new PopupWindow( recyclerViewList , ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
//        ColorDrawable dw = new ColorDrawable( 0x000000 );
//        popupWindow.setBackgroundDrawable(dw);
//        popupWindow.update();
//        //popupWindow.setContentView(recyclerViewList);
//    }

    protected void setStyle1() {
        LayoutInflater layoutInflater = LayoutInflater.from(getContext());
        layoutInflater.inflate(R.layout.search_one, this, true);
        LayoutParams layoutParams = new LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ViewGroup.LayoutParams.WRAP_CONTENT);
        int leftpx = DensityUtils.dip2px(getContext(), 5);
        int toppx = DensityUtils.dip2px(getContext(), 5);
        this.setPadding(leftpx, toppx, leftpx, toppx);
        this.setLayoutParams(layoutParams);

        tvSearch = (TextView) findViewById(R.id.search_one_search);

        tvSearch.setTypeface(MApplication.typeface);
        tvSearch.setOnClickListener(this);

        //recyclerViewList = (RecyclerView) findViewById(R.id.search_one_list);
        //createPopwindow();

        //readKeys();

        setEditText();
    }

    protected void saveKey(String key){
        if(TextUtils.isEmpty(key.trim()))return;
        if(keys.contains(key))return;

        keys.add(key);
        searchAdapter.addLastItem(key);
        if( keys.size()>MAX_SIZE){
            keys.remove(0);
        }
        JSONUtil<List<String>> jsonUtil=new JSONUtil<>();
        String json = jsonUtil.toJson(keys);
        PreferenceHelper.writeString(getContext(), Constant.SEARCH_INFO_FILE, Constant.SEARCH_KEY, json);
    }

    protected void setEditText(){
        etKey = (android.widget.EditText) findViewById(R.id.search_one_text);

        etKey.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                if (actionId == EditorInfo.IME_ACTION_SEARCH
                        || (event != null && event.getKeyCode() == KeyEvent.KEYCODE_ENTER)) {

                    String key = v.getText().toString().trim();
                    //saveKey(key);
                    //recyclerViewList.setVisibility(GONE);

                    EventBus.getDefault().post(new SearchEvent());
                    return true;
                }
                return false;
            }
        });

        etKey.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
//                if (keys != null && keys.size() > 0) {
//                    recyclerViewList.setVisibility(View.VISIBLE);
//                    searchAdapter.clear();
//                    searchAdapter.addNewDatas(keys);
//                }
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                //List<String> filterList = new ArrayList<String>();
                //boolean isNodata = false;
                //popupWindow.showAsDropDown(etKey);
//                if (s.length() > 0) {
//                    for (int i = 0; i < keys.size(); i++) {
//                        if (keys.get(i).toLowerCase().contains(s.toString().trim().toLowerCase())) {
//                            filterList.add(keys.get(i));
//                            //recyclerViewList.setVisibility(View.VISIBLE);
//                            //SearchWidget.this.bringToFront();
//                            //searchAdapter.clear();
//                            //searchAdapter.addNewDatas(filterList);
//                            popupWindow.showAsDropDown(etKey);
//                            isNodata = true;
//                        }
//                    }
//                    if (!isNodata) {
//                        //recyclerViewList.setVisibility(View.GONE);
//                        popupWindow.dismiss();
//                    }
//                } else {
//                    //recyclerViewList.setVisibility(View.GONE);
//                    popupWindow.dismiss();
//                }
            }

            @Override
            public void afterTextChanged(Editable s) {
            }
        });
    }

//    protected void readKeys(){
//        keys =new ArrayList<>();
//        String str = PreferenceHelper.readString(getContext(),Constant.SEARCH_INFO_FILE,Constant.SEARCH_KEY);
//        if(!TextUtils.isEmpty(str)) {
//            JSONUtil<List<String>> jsonUtil = new JSONUtil<>();
//            keys = jsonUtil.toBean(str, keys);
//        }
//        searchAdapter = new SearchAdapter(recyclerViewList);
//        recyclerViewList.setAdapter(searchAdapter);
//        searchAdapter.addNewDatas( keys );
//        searchAdapter.setOnItemChildClickListener(this);
//    }

    @Override
    public void onItemChildClick(ViewGroup viewGroup, View view, int i) {
//        if( view.getId()== R.id.txt_key){
//            String key = keys.get(i);
//            etKey.setText( key );
//            recyclerViewList.setVisibility(View.GONE);
//            EventBus.getDefault().post(new SearchEvent());
//        }
    }

    @Override
    public void onClick(View v) {

        //popupWindow.showAsDropDown(etKey);

        if(v.getId()==R.id.search_one_search){



            saveKey(etKey.getText().toString());

            EventBus.getDefault().post( new SearchEvent());
        }
    }

}

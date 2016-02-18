package com.jxd.archiveapp.adapters;

import android.graphics.drawable.Drawable;
import android.os.Build;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;

import com.jxd.archiveapp.R;

import cn.bingoogolapple.androidcommon.adapter.BGARecyclerViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGAViewHolderHelper;

/**
 * Created by Administrator on 2016/2/18.
 */
public class SearchAdapter extends BGARecyclerViewAdapter<String> {
    public SearchAdapter(RecyclerView recyclerView ) {
        super(recyclerView, R.layout.layout_search_item);
    }

    @Override
    protected void setItemChildListener(BGAViewHolderHelper viewHolderHelper) {
        super.setItemChildListener(viewHolderHelper);

        viewHolderHelper.setItemChildClickListener(R.id.txt_key);
    }

    @Override
    protected void fillData(BGAViewHolderHelper bgaViewHolderHelper, int i, String key) {
        bgaViewHolderHelper.setText(R.id.txt_key, key);

        Drawable icon;
        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.LOLLIPOP){
            icon = mContext.getResources().getDrawable(R.mipmap.search_grey, null);
        } else {
            icon = mContext.getResources().getDrawable(R.mipmap.search_grey);
        }

        bgaViewHolderHelper.getTextView(R.id.txt_key).setCompoundDrawables(icon,null,null,null);
    }
}

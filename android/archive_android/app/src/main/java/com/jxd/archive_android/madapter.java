package com.jxd.archive_android;

import android.support.v7.widget.RecyclerView;

import java.util.List;

import cn.bingoogolapple.androidcommon.adapter.BGARecyclerViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGAViewHolderHelper;

/**
 * Created by Administrator on 2016/2/3.
 */
public class madapter extends BGARecyclerViewAdapter<data> {
    private List<data> list;
    public madapter(RecyclerView recyclerView, List<data> list) {
        super(recyclerView, R.layout.item);

        this.list = list;
    }

    @Override
    protected void fillData(BGAViewHolderHelper bgaViewHolderHelper, int i, data data) {
        bgaViewHolderHelper.setText( R.id.text1, list.get(i).getName() );
    }
}

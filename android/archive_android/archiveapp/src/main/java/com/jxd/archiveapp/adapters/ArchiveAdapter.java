package com.jxd.archiveapp.adapters;

import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;

import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.ArchiveBean;

import cn.bingoogolapple.androidcommon.adapter.BGARecyclerViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGAViewHolderHelper;

/**
 * Created by 向东 on 2016-1-31.
 */
public class ArchiveAdapter extends BGARecyclerViewAdapter<ArchiveBean> {

    public ArchiveAdapter(RecyclerView recyclerView ) {
        super(recyclerView, R.layout.layout_archive_item);
    }

    @Override
    protected void fillData(BGAViewHolderHelper bgaViewHolderHelper, int i, ArchiveBean archiveBean) {
        bgaViewHolderHelper.setText( R.id.item_manager, archiveBean.getManager() );
        bgaViewHolderHelper.setText( R.id.item_number , archiveBean.getNumber());
        String position = TextUtils.isEmpty( archiveBean.getPosition())? "无位置信息": archiveBean.getPosition();
        bgaViewHolderHelper.setText(R.id.item_position , position );
        bgaViewHolderHelper.setText(R.id.item_title,archiveBean.getTitle());
    }


}

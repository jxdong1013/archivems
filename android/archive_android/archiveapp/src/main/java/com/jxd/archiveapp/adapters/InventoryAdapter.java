package com.jxd.archiveapp.adapters;

import android.support.v7.widget.RecyclerView;

import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.ArchiveBean;
import com.jxd.archiveapp.bean.InventoryBean;

import cn.bingoogolapple.androidcommon.adapter.BGAAdapterViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGARecyclerViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGAViewHolderHelper;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryAdapter extends BGARecyclerViewAdapter<InventoryBean> {

    public InventoryAdapter(RecyclerView recyclerView ) {
        super(recyclerView, R.layout.layout_inventory_item );
    }

    @Override
    protected void fillData(BGAViewHolderHelper bgaViewHolderHelper, int i, InventoryBean inventoryBean ) {
        bgaViewHolderHelper.setText( R.id.item_floorname, inventoryBean.getFloorname() );
        String info = "共"+ String.valueOf( inventoryBean.getBoxcount() ) + ",盘定"+ String.valueOf( inventoryBean.getInventorycount() );
        bgaViewHolderHelper.setText( R.id.item_info , info );
    }
}

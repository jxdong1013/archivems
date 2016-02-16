package com.jxd.archiveapp.adapters;

import android.support.v7.widget.RecyclerView;

import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.InventoryLabelInfoBean;
import com.jxd.archiveapp.bean.ScanBean;
import cn.bingoogolapple.androidcommon.adapter.BGARecyclerViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGAViewHolderHelper;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryAdapter extends BGARecyclerViewAdapter<InventoryLabelInfoBean> {

    public InventoryAdapter(RecyclerView recyclerView ) {
        super(recyclerView, R.layout.layout_inventory_item );
    }

    @Override
    protected void setItemChildListener(BGAViewHolderHelper viewHolderHelper) {
        super.setItemChildListener(viewHolderHelper);

        viewHolderHelper.setItemChildClickListener(R.id.item_panel);
    }

    @Override
    protected void fillData(BGAViewHolderHelper bgaViewHolderHelper, int i, InventoryLabelInfoBean inventoryBean ) {
        bgaViewHolderHelper.setText( R.id.item_floorname, inventoryBean.getName() );
        bgaViewHolderHelper.setText(R.id.item_floorrfid , inventoryBean.getRfid());
        String info = "";
        int normal =0;
        int damage = 0;
        int miss=0;
        int total=0;
        if( inventoryBean.getBoxs()!=null ){
            total=inventoryBean.getBoxs().size();
            for(ScanBean item : inventoryBean.getBoxs()){
                if( item.getStatus()!=null && item.getStatus().equals(Constant.LABEL_NORMAL)){
                    normal++;
                }else if(item.getStatus()!=null && item.getStatus().equals(Constant.LABEL_DAMAGE)){
                    damage++;
                }else if(item.getStatus()!=null && item.getStatus().equals(Constant.LABEL_MISS)){
                    miss++;
                }
            }
        }
        info+="共"+ String.valueOf(total)+"个标签,正常"+ String.valueOf(normal)+"个,损坏"+String.valueOf(damage)+"个,丢失"+String.valueOf(miss)+"个";
        //String info = "共"+ String.valueOf( inventoryBean.g() ) + "个资产,已盘定"+ String.valueOf( inventoryBean.getInventorycount() )+"个";
        bgaViewHolderHelper.setText(R.id.item_info, info);

    }
}

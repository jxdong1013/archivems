package com.jxd.archiveapp.adapters;

import android.support.v7.widget.RecyclerView;
import android.view.ViewGroup;
import android.widget.CompoundButton;

import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.ScanBean;

import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildCheckedChangeListener;
import cn.bingoogolapple.androidcommon.adapter.BGARecyclerViewAdapter;
import cn.bingoogolapple.androidcommon.adapter.BGAViewHolderHelper;

/**
 * Created by Administrator on 2016/2/15.
 */
public class ScanAdapter extends BGARecyclerViewAdapter<ScanBean> {

    public ScanAdapter(RecyclerView recyclerView) {
        super(recyclerView, R.layout.layout_scan_item );
    }

    @Override
    protected void setItemChildListener(BGAViewHolderHelper viewHolderHelper) {
        super.setItemChildListener(viewHolderHelper);

        viewHolderHelper.setItemChildCheckedChangeListener(R.id.scan_item_normal);
        viewHolderHelper.setItemChildCheckedChangeListener(R.id.scan_item_damage);
        viewHolderHelper.setItemChildCheckedChangeListener(R.id.scan_item_miss);
    }

    @Override
    protected void fillData(BGAViewHolderHelper bgaViewHolderHelper, int i, ScanBean scanBean ) {
        bgaViewHolderHelper.setText( R.id.scan_item_name , scanBean.getName() );
        bgaViewHolderHelper.setText(R.id.scan_item_rfid, scanBean.getRfid());
        //bgaViewHolderHelper.getTextView(R.id.scan_item_delete).setTypeface(MApplication.typeface);
        if( scanBean.getStatus() !=null && scanBean.getStatus().equals(Constant.LABEL_NORMAL)){
            bgaViewHolderHelper.setChecked(R.id.scan_item_normal,true);
        }else if(scanBean.getStatus() !=null && scanBean.getStatus().equals(Constant.LABEL_DAMAGE)){
            bgaViewHolderHelper.setChecked(R.id.scan_item_damage,true);
        }else if(scanBean.getStatus() !=null && scanBean.getStatus().equals(Constant.LABEL_MISS)){
            bgaViewHolderHelper.setChecked(R.id.scan_item_miss,true);
        }

    }
}

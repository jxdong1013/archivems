package com.jxd.archiveapp.fragments;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.widget.TextView;

import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.GsonResponseHandler;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.InventoryAdapter;
import com.jxd.archiveapp.adapters.ScanAdapter;
import com.jxd.archiveapp.bean.BaseBean;
import com.jxd.archiveapp.bean.InventoryBean;
import com.jxd.archiveapp.bean.InventoryLabelInfoResult;
import com.jxd.archiveapp.bean.LabelResult;
import com.jxd.archiveapp.bean.ScanBean;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;

import java.util.List;

/**
 * Created by Administrator on 2016/2/15.
 */
public class InventoryScanFragment extends BaseFragment implements Handler.Callback {
    RecyclerView recyclerView;
    ScanAdapter adapter;
    TextView tvFloor;
    GsonResponseHandler<InventoryLabelInfoResult > inventoryLabelResponeseHandler;
    Handler handler;

    public InventoryScanFragment() {
    }

    @Override
    public boolean handleMessage(Message msg) {
        this.closeProgressDialog();
        if( msg.what== GsonResponseHandler.SUCCESS ){
            deal_data(msg.obj);
        }else if(msg.what==GsonResponseHandler.FAILTURE){
            BaseBean result = (BaseBean)msg.obj;
            String error = result.getMessage();
            Snackbar.make(mContentView, error, Snackbar.LENGTH_LONG).show();
        }
        return false;
    }

    private void deal_data( Object obj ){
        InventoryLabelInfoResult result = (InventoryLabelInfoResult)obj;
        if( result==null)return;
        if( result.getCode()== Constant.REQUEST_SCUESS){
            if( result.getData().getType().equals("floor")) {
                tvFloor.setText(result.getData().getName());
                tvFloor.setTag(result.getData());
                adapter.addNewDatas(result.getData().getBoxs());

                String key = result.getData().getRfid();
                JSONUtil<List<ScanBean>> jsonUtil = new JSONUtil<>();
                String json = jsonUtil.toJson( result.getData().getBoxs() );
                PreferenceHelper.writeString( getActivity() , Constant.INVENTORY_INFO_FILE , key , json );
            }

        }else if(result.getCode() == Constant.REQUEST_FAILED ) {
            String msg = result.getMessage();
            Snackbar.make(mContentView, msg, Snackbar.LENGTH_LONG).show();
        }
    }

    @Override
    protected void initView(Bundle savedInstanceState) {
        setContentView(R.layout.fragment_inventory_scan);
        recyclerView = getViewById(R.id.scan_boxs);
        LinearLayoutManager manager = new LinearLayoutManager(this.getActivity());
        recyclerView.setLayoutManager(manager);
        tvFloor = getViewById(R.id.scan_floor);

        handler = new Handler(this);
    }

    @Override
    protected void processLogic(Bundle savedInstanceState) {

    }

    @Override
    protected void onUserVisible() {

    }

    @Override
    protected void setListener() {

    }

    @Override
    public String getTitle() {
        return Constant.FRAGMENT_INVENTORYSCAN;
    }

    @Override
    public void setRFID(String rfid) {
        if(TextUtils.isEmpty( rfid))return;

        if( !queryLabelInfoByLocal(rfid) ) {
            queryLabelInfoByRFID(rfid);
        }
    }

    private boolean queryLabelInfoByLocal(String rfid){
        if(MApplication.getApplication().inventoryData ==null || MApplication.getApplication().inventoryData.size()<1){
            return  false;
        }

        for(InventoryBean bean : MApplication.getApplication().inventoryData){
            if( bean.getFloorrfid().equals( rfid)) {
                tvFloor.setText(bean.getFloorname());
                tvFloor.setTag(bean);
                adapter = new ScanAdapter(recyclerView);
                recyclerView.setAdapter(adapter);
                adapter.addNewDatas( bean.getBoxs() );
                return true;
            }
        }
        return false;
    }

    protected void queryLabelInfoByRFID(String rfid){
        this.showProgressDialog("", "正在查询标签信息，请稍等...");

        String url = Constant.GET_INVENTORY_LABELINFO_URL;
        RequestParams params =new RequestParams();
        params.add("rfid",rfid);

        AsyncHttpUtil.get(url, params, inventoryLabelResponeseHandler );
    }
}

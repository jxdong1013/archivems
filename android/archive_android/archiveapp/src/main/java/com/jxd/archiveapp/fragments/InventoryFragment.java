package com.jxd.archiveapp.fragments;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RelativeLayout;
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
import com.jxd.archiveapp.bean.ScanBean;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

/**
 * 盘点
 */
public class InventoryFragment extends BaseFragment implements Handler.Callback{
    RecyclerView recyclerViewList;
    InventoryAdapter adapter;
    RelativeLayout rlNoData;
    TextView tvNoDataPic;
    RelativeLayout rlContain;
    RelativeLayout rlScan;
    //-----------------------------------------------------------
    RecyclerView recyclerViewScanBox;
    TextView tvScanFloor;
    Handler handler;
    ScanAdapter scanAdapter;
    GsonResponseHandler<InventoryLabelInfoResult > inventoryLabelResponeseHandler;

    public InventoryFragment() {
        // Required empty public constructor
    }

    @Override
    public boolean handleMessage(Message msg) {
        this.closeProgressDialog();
        if( msg.what== GsonResponseHandler.SUCCESS ){
            if( msg.obj instanceof InventoryLabelInfoResult ) {
                deal_data(msg.obj);
            }

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
                tvScanFloor.setText(result.getData().getName());
                tvScanFloor.setTag(result.getData());
                if( scanAdapter ==null ){
                    scanAdapter=new ScanAdapter(recyclerViewScanBox);
                    recyclerViewScanBox.setAdapter(scanAdapter);
                }
                scanAdapter.addNewDatas(result.getData().getBoxs());

                String key = result.getData().getRfid();
                JSONUtil<List<ScanBean>> jsonUtil = new JSONUtil<>();
                String json = jsonUtil.toJson( result.getData().getBoxs() );
                PreferenceHelper.writeString(getActivity(), Constant.INVENTORY_INFO_FILE, key, json);

                Set<String> floors = PreferenceHelper.readStringSet(getActivity(), Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor);
                if( floors==null){
                    floors= new HashSet<>();
                    floors.add(key);
                }else{
                    if( !floors.contains(key)) {
                        floors.add(key);
                    }
                }

                PreferenceHelper.writeStringSet(getActivity(),Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor, floors);
            }

        }else if(result.getCode() == Constant.REQUEST_FAILED ) {
            String msg = result.getMessage();
            Snackbar.make(mContentView, msg, Snackbar.LENGTH_LONG).show();
        }
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @Override
    public void onDetach() {
        super.onDetach();
    }

    @Override
    protected void processLogic(Bundle savedInstanceState) {
        loadLocalData();
    }

    protected void loadLocalData(){
        //List<InventoryBean> data=new ArrayList<>();
        MApplication.getApplication().inventoryData = new ArrayList<>();
        Set<String> set = PreferenceHelper.readStringSet(this.getActivity(), Constant.INVENTORY_INFO_FILE , Constant.INVENTORY_Floor );
        if( set!=null){

            JSONUtil<ScanBean> jsonUtil =new JSONUtil<>();
            for(String item : set){
                InventoryBean inventoryBean = new InventoryBean();
                //inventoryBean.setFloorname(item);
                inventoryBean.setFloorrfid(item);

                String json = PreferenceHelper.readString(getActivity(), Constant.INVENTORY_INFO_FILE, item );
                List<ScanBean> boxs = new ArrayList<>();
                boxs = jsonUtil.toListBean(json , boxs.getClass() );
                inventoryBean.setBoxs(boxs);
                MApplication.getApplication().inventoryData.add(inventoryBean);
            }
        }

        adapter = new InventoryAdapter(recyclerViewList);
        recyclerViewList.setAdapter(adapter);
        adapter.addNewDatas(MApplication.getApplication().inventoryData);

        if( MApplication.getApplication().inventoryData.size()<1 ){
            rlNoData.setVisibility(View.VISIBLE);
        }else{
            rlNoData.setVisibility(View.GONE);
        }
    }

    @Override
    protected void onUserVisible() {

    }

    @Override
    public String getTitle() {
        return Constant.FRAGMENT_INVENTORY;
    }

    @Override
    protected void setListener() {

    }

    @Override
    protected void initView(Bundle savedInstanceState) {
        this.setContentView(R.layout.fragment_inventory);

        handler = new Handler(this);
        rlContain = getViewById(R.id.inventory_contain);
        rlScan = getViewById(R.id.inventory_scan);
        rlScan.setVisibility(View.GONE);

        recyclerViewList = getViewById(R.id.inventory_list);
        LinearLayoutManager manager = new LinearLayoutManager(this.getActivity());
        recyclerViewList.setLayoutManager(manager);

        rlNoData = getViewById(R.id.inventory_nodata);
        tvNoDataPic = getViewById(R.id.inventory_nodata_pic);
        tvNoDataPic.setTypeface(MApplication.typeface );

        //----------------------------------------------------
        recyclerViewScanBox = getViewById(R.id.scan_boxs);
        manager = new LinearLayoutManager(this.getActivity());
        recyclerViewScanBox.setLayoutManager(manager);
        tvScanFloor = getViewById(R.id.scan_floor);
        inventoryLabelResponeseHandler =new GsonResponseHandler<>(getContext(),handler, InventoryLabelInfoResult.class);
    }

    @Override
    public void setRFID(String rfid) {
        if(TextUtils.isEmpty(rfid))return;

        //TODO
        Snackbar.make(mContentView,rfid,Snackbar.LENGTH_LONG).show();

        rlContain.setVisibility(View.GONE);
        rlScan.setVisibility(View.VISIBLE);

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
                tvScanFloor.setText(bean.getFloorname());
                tvScanFloor.setTag(bean);
                scanAdapter = new ScanAdapter(recyclerViewScanBox);
                recyclerViewScanBox.setAdapter(adapter);
                scanAdapter.addNewDatas( bean.getBoxs() );
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

        AsyncHttpUtil.get(url, params, inventoryLabelResponeseHandler);
    }

    public void Upload(){
        Snackbar.make(mContentView, "upload", Snackbar.LENGTH_LONG).show();

        setRFID("1");

    }
}

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
import android.widget.CompoundButton;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.google.gson.reflect.TypeToken;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.GsonResponseHandler;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.InventoryAdapter;
import com.jxd.archiveapp.adapters.ScanAdapter;
import com.jxd.archiveapp.bean.BaseBean;
import com.jxd.archiveapp.bean.InventoryBean;
import com.jxd.archiveapp.bean.InventoryLabelInfoBean;
import com.jxd.archiveapp.bean.InventoryLabelInfoResult;
import com.jxd.archiveapp.bean.InventoryRecord;
import com.jxd.archiveapp.bean.ScanBean;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.Divider;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;
import org.apache.http.conn.ConnectTimeoutException;
import java.lang.reflect.Type;
import java.net.SocketTimeoutException;
import java.util.ArrayList;
import java.util.List;
import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildCheckedChangeListener;
import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildClickListener;

/**
 * 盘点
 */
public class InventoryFragment extends BaseFragment implements Handler.Callback , BGAOnItemChildClickListener , BGAOnItemChildCheckedChangeListener {
    RecyclerView recyclerViewList;
    InventoryAdapter inventoryAdapter;
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
    List<InventoryLabelInfoBean> data;
    String split="_";
    GsonResponseHandler<BaseBean> uploadInventoryResponseHandler;

    public InventoryFragment() {
        // Required empty public constructor
    }

    public boolean isScanUI(){
        return rlScan.getVisibility()==View.VISIBLE;
    }
    public void backInventoryUI(){
        rlScan.setVisibility(View.GONE);
        rlContain.setVisibility(View.VISIBLE);
        if( data==null||data.size()<1 ) {
            rlNoData.setVisibility(View.VISIBLE);
        }else{
            rlNoData.setVisibility(View.GONE);
        }
    }

    @Override
    public void onItemChildClick(ViewGroup viewGroup, View view, int i) {
        //Snackbar.make(mContentView , String.valueOf( i ), Snackbar.LENGTH_LONG).show();
       if(view.getId()== R.id.item_panel) {

           InventoryLabelInfoBean bean = inventoryAdapter.getItem(i);
           rlContain.setVisibility(View.GONE);
           rlScan.setVisibility(View.VISIBLE);
           setScanData(bean);
       }else if(view.getId()==R.id.item_delete){
           InventoryLabelInfoBean bean = inventoryAdapter.getItem(i);
           String rfid_name = bean.getRfid()+split+bean.getName();
           PreferenceHelper.remove(getActivity(),Constant.INVENTORY_INFO_FILE,rfid_name);
           data.remove(bean);

           String json = "";
           for(InventoryLabelInfoBean item : data){
               String temp = item.getRfid()+split+item.getName();
               if(!TextUtils.isEmpty(json)){
                   json+=",";
               }
               json+= temp;
           }
           PreferenceHelper.writeString(getActivity(), Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor, json);

           inventoryAdapter.removeItem(i);

           if( !TextUtils.isEmpty( tvScanFloor.getText().toString() )){
               InventoryLabelInfoBean model = (InventoryLabelInfoBean)tvScanFloor.getTag();
               if( bean.getRfid().equals( model.getRfid())){
                   tvScanFloor.setText("");
                   tvScanFloor.setTag(null);
                   scanAdapter.clear();
               }
           }

       }
    }

    @Override
    public void onItemChildCheckedChanged(ViewGroup viewGroup, CompoundButton compoundButton, int i, boolean b) {
        if( b==false ) return;
        scanAdapter.getDatas().get(i).setStatus(compoundButton.getText().toString());

        List<ScanBean> boxes = scanAdapter.getDatas();
        String floorname = tvScanFloor.getText().toString();
        String floorrfid = ((InventoryLabelInfoBean)tvScanFloor.getTag()).getRfid();
        String key = floorrfid+ split +floorname;
        JSONUtil<List<ScanBean>> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson(boxes);
        PreferenceHelper.writeString(getActivity(), Constant.INVENTORY_INFO_FILE, key, json);

        inventoryAdapter.notifyDataSetChanged();
    }

    @Override
    public boolean handleMessage(Message msg) {
        this.closeProgressDialog();
        if( msg.what== GsonResponseHandler.SUCCESS ){
            if( msg.obj instanceof InventoryLabelInfoResult ) {
                deal_data(msg.obj);
            }

        }else if(msg.what==GsonResponseHandler.FAILTURE){
            if( msg.obj instanceof SocketTimeoutException || msg.obj instanceof ConnectTimeoutException){
                Snackbar.make(this.mContentView , "连接超时，请重试", Snackbar.LENGTH_LONG).show();
                return true;
            }else {
                Snackbar.make(mContentView, "请求失败", Snackbar.LENGTH_LONG).show();
                return true;
            }
        }
        return false;
    }

    private void setScanData( InventoryLabelInfoBean bean ){
        tvScanFloor.setText(bean.getName());
        tvScanFloor.setTag(bean);
        if( scanAdapter == null ){
            scanAdapter=new ScanAdapter(recyclerViewScanBox);
            scanAdapter.setOnItemChildCheckedChangeListener(this);
            recyclerViewScanBox.setAdapter(scanAdapter);
        }else {
            scanAdapter.clear();
        }
        if( bean.getBoxs()!=null ) {
            scanAdapter.addNewDatas(bean.getBoxs());
        }

        String floorrfid = bean.getRfid();
        String floorname = bean.getName();
        String rfid_name = floorrfid+ split +floorname;
        JSONUtil<List<ScanBean>> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson(bean.getBoxs());
        PreferenceHelper.writeString(getActivity(), Constant.INVENTORY_INFO_FILE, rfid_name, json);


        String floors = PreferenceHelper.readString(getActivity(), Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor);

        //Set<String> floors = PreferenceHelper.readStringSet(getActivity(), Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor);
        if( TextUtils.isEmpty(floors)){
            //floors = new HashSet<>();
            //floors.add(rfid_name);
            floors = rfid_name;
        }else{
            //if( !floors.contains(rfid_name)) {
            //    floors.add(rfid_name);
            //}
            boolean isexist = false;
            String[] items = floors.split(",");
            if( items!=null && items.length>0 ){
                for(int i=0;i<items.length;i++){
                    if( items[i].equals( rfid_name )){
                        isexist= true;
                        break;
                    }
                }
            }
            if( !isexist ){
                if( !TextUtils.isEmpty(floors)){
                    floors+=",";
                }
                floors+= rfid_name;
            }
        }



        //PreferenceHelper.writeStringSet(getActivity(), Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor, floors);
        PreferenceHelper.writeString(getActivity(),Constant.INVENTORY_INFO_FILE,Constant.INVENTORY_Floor,floors);

        String temp = PreferenceHelper.readString(getActivity(), Constant.INVENTORY_INFO_FILE, Constant.INVENTORY_Floor);

        boolean exist=false;
        for(InventoryLabelInfoBean item : data){
            if( item.getRfid().equals( floorrfid )){
                exist=true;break;
            }
        }
        if( !exist){
            data.add(bean);
            inventoryAdapter.clear();
            inventoryAdapter.addNewDatas(data);
        }
    }

    private void deal_data( Object obj ){
        InventoryLabelInfoResult result = (InventoryLabelInfoResult)obj;
        if( result==null)return;
        if( result.getCode()== Constant.REQUEST_SCUESS){
            if( result.getData().getType().equals("floor")) {
                setScanData( result.getData() );
            }else if( result.getData().getType().equals("box")){
                if( TextUtils.isEmpty( tvScanFloor.getText()) ) {
                    Snackbar.make(mContentView, "请先扫描层架标签", Snackbar.LENGTH_LONG).show();
                    return;
                }else{
                    findBoxLabel(result.getData().getRfid());
                }
            }
        }else if(result.getCode() == Constant.REQUEST_FAILED ) {
            String msg = result.getMessage();
            Snackbar.make(mContentView, msg, Snackbar.LENGTH_LONG).show();
        }
    }

    private void findBoxLabel( String rfid ){
        List<ScanBean> boxes = scanAdapter.getDatas();
        if( boxes==null || boxes.size()<1){
            Snackbar.make(mContentView,"无法找到层架下的档案盒信息",Snackbar.LENGTH_LONG).show();
            return;
        }
        boolean isExist = false;
        for( ScanBean bean :  boxes){
            if( bean.getRfid().equals(rfid) ){
                bean.setStatus(Constant.LABEL_NORMAL);
                scanAdapter.notifyDataSetChanged();

                String floorname = tvScanFloor.getText().toString();
                String floorrfid = ((InventoryLabelInfoBean)tvScanFloor.getTag()).getRfid();
                String key = floorrfid+ split +floorname;
                JSONUtil<List<ScanBean>> jsonUtil = new JSONUtil<>();
                String json = jsonUtil.toJson( boxes );
                PreferenceHelper.writeString(getActivity(), Constant.INVENTORY_INFO_FILE , key ,  json );
                isExist=true;
                Snackbar.make(mContentView, bean.getName(),Snackbar.LENGTH_LONG).show();
                break;
            }
        }
        if( !isExist){
            Snackbar.make(mContentView,"无法找到层架下的档案盒信息",Snackbar.LENGTH_LONG).show();
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
        data = new ArrayList<>();
        //Set<String> set = PreferenceHelper.readStringSet(this.getActivity(), Constant.INVENTORY_INFO_FILE , Constant.INVENTORY_Floor );
        String set = PreferenceHelper.readString(getActivity(),Constant.INVENTORY_INFO_FILE,Constant.INVENTORY_Floor);

        if( !TextUtils.isEmpty(set) ){
            String[] items= set.split(",");
            JSONUtil<List<ScanBean>> jsonUtil =new JSONUtil<>();
            for(String item : items){
                String[] rfid_name = item.split( split );
                if( rfid_name==null || rfid_name.length<2 ) continue;
                InventoryLabelInfoBean inventoryBean = new InventoryLabelInfoBean();
                inventoryBean.setName( rfid_name[1] );
                inventoryBean.setRfid(rfid_name[0]);
                inventoryBean.setType("floor");

                String json = PreferenceHelper.readString(getActivity(), Constant.INVENTORY_INFO_FILE, item );
                List<ScanBean> boxs = new ArrayList<>();
                Type type = new TypeToken<ArrayList<ScanBean>>(){}.getType();
                boxs = jsonUtil.toListBean(json , type );
                inventoryBean.setBoxs(boxs);
                data.add(inventoryBean);
            }
        }

        inventoryAdapter = new InventoryAdapter(recyclerViewList);
        inventoryAdapter.setOnItemChildClickListener(this);
        recyclerViewList.setAdapter(inventoryAdapter);
        inventoryAdapter.addNewDatas(data);


        if( data.size()<1 ){
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
        recyclerViewList.addItemDecoration(new Divider(this.getActivity()));


        rlNoData = getViewById(R.id.inventory_nodata);
        tvNoDataPic = getViewById(R.id.inventory_nodata_pic);
        tvNoDataPic.setTypeface(MApplication.typeface );

        //----------------------------------------------------
        recyclerViewScanBox = getViewById(R.id.scan_boxs);
        manager = new LinearLayoutManager(this.getActivity());
        recyclerViewScanBox.setLayoutManager(manager);
        tvScanFloor = getViewById(R.id.scan_floor);
        inventoryLabelResponeseHandler =new GsonResponseHandler<>(getContext(),handler, InventoryLabelInfoResult.class);

        uploadInventoryResponseHandler = new GsonResponseHandler<>(getContext(),handler, BaseBean.class);
    }

    @Override
    public void setRFID(String rfid) {
        if(TextUtils.isEmpty(rfid))return;

        rlContain.setVisibility(View.GONE);
        rlScan.setVisibility(View.VISIBLE);

        if( !queryFloorLabelInfoByLocal(rfid) ) {
            queryFloorLabelInfoByRFID(rfid);
        }
    }

    private boolean queryFloorLabelInfoByLocal(String rfid){
        if( data ==null || data.size()<1){
            return false;
        }
        //如果rfid 等于 同一个标签，则返回 true
        if( !TextUtils.isEmpty( tvScanFloor.getText()) ){
            InventoryLabelInfoBean floor = (InventoryLabelInfoBean)tvScanFloor.getTag();
            if( floor.getRfid().equals(rfid) ) {
                Snackbar.make(mContentView, floor.getName(), Snackbar.LENGTH_LONG).show();
                return true;
            }
        }

        for(InventoryLabelInfoBean bean : data ){
            if( bean.getRfid().equals(rfid)) {
                tvScanFloor.setText(bean.getName());
                tvScanFloor.setTag(bean);
                if( scanAdapter==null) {
                    scanAdapter = new ScanAdapter(recyclerViewScanBox);
                    scanAdapter.setOnItemChildCheckedChangeListener(this);
                    recyclerViewScanBox.setAdapter(scanAdapter);
                }
                scanAdapter.addNewDatas( bean.getBoxs() );
                return true;
            }
        }
        return false;
    }

    protected void queryFloorLabelInfoByRFID(String rfid){
        this.showProgressDialog("", "正在查询信息,请稍等...");

        String url = Constant.GET_INVENTORY_LABELINFO_URL;
        RequestParams params =new RequestParams();
        params.add("rfid",rfid);

        AsyncHttpUtil.get(url, params, inventoryLabelResponeseHandler);
    }

    public void Upload(){
        setRFID("1");

        setRFID("213");

        setRFID("217");

        setRFID("300");

        //setRFID("2");

        setRFID("3");
    }

    protected  void UploadInventory(){
        if( data==null|| data.size()<1 ) {
            Snackbar.make(mContentView,"请盘点，再上传",Snackbar.LENGTH_LONG).show();
            return;
        }

        InventoryBean list = new InventoryBean();
        String name = PreferenceHelper.readString( getActivity() , Constant.USER_INFO_FILE , Constant.USER_NAME );
        int id = PreferenceHelper.readInt( getActivity(),Constant.USER_INFO_FILE,Constant.USER_USERID);
        list.setOperateid( id );
        list.setOperatename(name);
        String title= name + "盘点记录";
        list.setTitle(title);

        List<InventoryRecord> records = new ArrayList<>();

        for( InventoryLabelInfoBean bean : data) {
            if( bean.getBoxs()==null|| bean.getBoxs().size()<1 ) continue;
            for(ScanBean child : bean.getBoxs()) {
                InventoryRecord record = new InventoryRecord();
                record.setBoxrfid(child.getRfid());
                record.setFloorrfid(bean.getRfid());
                record.setStatus(child.getStatus());
                records.add(record);
            }
        }

        list.setRecords(records);

        JSONUtil<InventoryBean> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson(list);

        this.showProgressDialog("", "正在上传盘点信息,请稍等...");

        String url = Constant.UPLOAD_INVENTORY_URL;
        RequestParams params =new RequestParams();
        params.add("data", json );

        AsyncHttpUtil.post(url, params, uploadInventoryResponseHandler);
    }
}

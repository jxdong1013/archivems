package com.jxd.archiveapp.fragments;

import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CompoundButton;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

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
import com.jxd.archiveapp.bean.LoginEvent;
import com.jxd.archiveapp.bean.ScanBean;
import com.jxd.archiveapp.bean.SwitchFragmentEvent;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.Divider;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.entity.StringEntity;
import java.io.UnsupportedEncodingException;
import java.lang.reflect.Type;
import java.net.SocketTimeoutException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildCheckedChangeListener;
import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildClickListener;
import org.greenrobot.eventbus.EventBus;

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
    TextView tvScanBoxCount;
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
            //发送消息，显示 “返回”按钮
           EventBus.getDefault().post(new SwitchFragmentEvent(Constant.FRAGMENT_INVENTORY));
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

           if( data.size()==0){
               rlNoData.setVisibility(View.VISIBLE);
           }else{
               rlNoData.setVisibility(View.GONE);
           }

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

        if( scanAdapter.getDatas().get(i).getStatus() !=null &&
            scanAdapter.getDatas().get(i).getStatus().equals( compoundButton.getText().toString() ) ) {
            return;
        }

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
        Toast.makeText(getActivity(), "消息="+ String.valueOf( msg.what ) +"消息内容："+ msg.obj==null ? "": msg.obj.toString()   , Toast.LENGTH_LONG).show();

        this.closeProgressDialog();
        if( msg.what== GsonResponseHandler.SUCCESS ){
            if( msg.obj instanceof InventoryLabelInfoResult ) {
                deal_data(msg.obj);
            }else {
               deal_inventory(msg.obj);
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

    private void deal_inventory(Object obj){
        BaseBean bean = (BaseBean)obj;
        if( bean==null){
            Snackbar.make(mContentView,"请求失败",Snackbar.LENGTH_LONG).show();
            return;
        }
        if( bean.getCode()==Constant.REQUEST_LOGIN ){
            EventBus.getDefault().post(new LoginEvent());
            return;
        }else if(bean.getCode()==Constant.REQUEST_FAILED){
            Snackbar.make(mContentView, bean.getMessage() ,Snackbar.LENGTH_LONG).show();
            return;
        }else if(bean.getCode()==Constant.REQUEST_SCUESS){
            Snackbar.make(mContentView,bean.getMessage(),Snackbar.LENGTH_LONG).show();
            PreferenceHelper.clean(getActivity(), Constant.INVENTORY_INFO_FILE);
            inventoryAdapter.clear();
            if (scanAdapter != null) {
                scanAdapter.clear();
            }
            if(data!=null) {
                data.clear();
            }
            rlNoData.setVisibility(View.VISIBLE);
            return;
        }
    }

    private void setScanData( InventoryLabelInfoBean bean ){
        tvScanFloor.setText(bean.getName());
        tvScanBoxCount.setText( String.valueOf( bean.getBoxCount() )+"个档案盒");
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
        if( result==null){
            Toast.makeText(getActivity(),  "服务端返回空数据" , Toast.LENGTH_LONG).show();
            return;
        }
        if(result.getCode()==Constant.REQUEST_LOGIN){
            EventBus.getDefault().post(new LoginEvent());
            return;
        }else if( result.getCode()== Constant.REQUEST_SCUESS){
            if( result.getData().getType().equals("floor")) {

                Toast.makeText(getActivity(),  "档案盒数量=" + String.valueOf( result.getData().getBoxCount()) , Toast.LENGTH_LONG).show();

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
                inventoryAdapter.notifyDataSetChanged();
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
        tvScanBoxCount = getViewById(R.id.scan_boxcount);


        inventoryLabelResponeseHandler =new GsonResponseHandler<>(getContext(),handler, InventoryLabelInfoResult.class);

        uploadInventoryResponseHandler = new GsonResponseHandler<>(getContext(),handler, BaseBean.class);



        ///
        //setRFID("E004015036FACE4D");

    }

    @Override
    public void setRFID(String rfid) {
        if(TextUtils.isEmpty(rfid))return;

        Snackbar.make(mContentView,rfid , Snackbar.LENGTH_LONG).show();

        rlContain.setVisibility(View.GONE);
        rlScan.setVisibility(View.VISIBLE);
        EventBus.getDefault().post(new SwitchFragmentEvent(Constant.FRAGMENT_INVENTORY));

        //if( !queryFloorLabelInfoByLocal(rfid) ) {
            queryFloorLabelInfoByRFID(rfid);
        //}
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
        if( !canConnect()){
            return;
        }

        this.showProgressDialog("", "正在查询信息,请稍等...");

        String url = Constant.GET_INVENTORY_LABELINFO_URL;
        RequestParams params =new RequestParams();
        params.add("rfid",rfid);

        AsyncHttpUtil.get(url, params, inventoryLabelResponeseHandler);
    }

    public void Upload(){
//        setRFID("200000001");
//        setRFID("213");
//        setRFID("216");
//        setRFID("217");
//        setRFID("218");
//        setRFID("219");

//        setRFID("200000003");
//        setRFID("300");
//        setRFID("301");
//        setRFID("302");
//        setRFID("303");
//        setRFID("304");
//        setRFID("305");
//        setRFID("306");
//        setRFID("307");
//        setRFID("308");
//        setRFID("3");

        //setRFID("E00401002916ECBC");

        UploadInventory();

    }

    protected void UploadInventory(){
        if( !canConnect()){
            return;
        }

        if( data==null|| data.size()<1 ) {
            Snackbar.make(mContentView,"请先盘点，再上传数据",Snackbar.LENGTH_LONG).show();
            return;
        }

        this.showProgressDialog("", "正在上传盘点信息,请稍等...");

        InventoryBean list = new InventoryBean();
        String username = PreferenceHelper.readString( getActivity() , Constant.USER_INFO_FILE , Constant.USER_NAME );
        int userid = PreferenceHelper.readInt( getActivity(),Constant.USER_INFO_FILE,Constant.USER_USERID);
        list.setOperateid(userid);
        list.setOperatename(username);
        SimpleDateFormat format = new SimpleDateFormat("yyy-MM-dd-HH-mm-ss", Locale.CHINA);
        String datetime =  format.format(System.currentTimeMillis());
        String title= username + "_"+datetime+"_盘点记录";
        list.setTitle(title);

        List<InventoryRecord> records = new ArrayList<>();

        for( InventoryLabelInfoBean bean : data) {

            if( bean.getBoxs()==null|| bean.getBoxs().size()<1 ){
                InventoryRecord record = new InventoryRecord();
                record.setFloorrfid( bean.getRfid());
                record.setStatus("");
                record.setBoxrfid("");
                records.add(record);
            }else {
                for (ScanBean child : bean.getBoxs()) {
                    InventoryRecord record = new InventoryRecord();
                    record.setBoxrfid(child.getRfid());
                    record.setFloorrfid(bean.getRfid());
                    record.setStatus(child.getStatus());
                    record.setBorrowstatus( String.valueOf( child.getInventoryStatus()) );
                    record.setBorrowdate(child.getBorrowDateString() );
                    records.add(record);
                }
            }
        }

        list.setRecords(records);

        JSONUtil<InventoryBean> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson(list);

        String url = Constant.UPLOAD_INVENTORY_URL;
        //RequestParams params =new RequestParams();
        //params.add("data", json);
        try {
            String para = "{data:"+json+"}";
            StringEntity stringEntity = new StringEntity(para,"UTF-8");
            //stringEntity.setContentType(new BasicHeader(HTTP.CONTENT_TYPE,));
            AsyncHttpUtil.post(url, stringEntity, "application/json" ,uploadInventoryResponseHandler);
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
    }
}

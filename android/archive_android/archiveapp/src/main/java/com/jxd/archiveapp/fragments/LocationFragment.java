package com.jxd.archiveapp.fragments;

import android.util.Log;
import android.view.View;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.TextureView;
import android.view.View;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;
import com.google.gson.reflect.TypeToken;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.GsonResponseHandler;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.LocationAdapter;
import com.jxd.archiveapp.adapters.OnRCItemClickListener;
import com.jxd.archiveapp.bean.BaseBean;
import com.jxd.archiveapp.bean.LabelInfoBean;
import com.jxd.archiveapp.bean.LabelResult;
import com.jxd.archiveapp.bean.LocationBean;
import com.jxd.archiveapp.bean.LoginEvent;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.Logger;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;

import org.apache.http.conn.ConnectTimeoutException;

import java.lang.reflect.Type;
import java.net.SocketTimeoutException;
import java.util.ArrayList;
import java.util.List;

import org.greenrobot.eventbus.EventBus;

/**
 * 标签定位
 */
public class LocationFragment extends BaseFragment implements View.OnClickListener , OnRCItemClickListener , Handler.Callback{

    RecyclerView recyclerView;
    LocationAdapter adapter;
    TextView tvFloorName;
    TextView tvInfo;
    TextView tvOperate;
    List<LocationBean> data;
    RelativeLayout rlNoData;
    TextView tvNoDataTip;
    TextView tvNoDataPic;
    GsonResponseHandler<BaseBean> gsonResponseHandler;
    GsonResponseHandler<LabelResult> labelResponeseHandler;
    Handler handler;

    public LocationFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public boolean handleMessage(Message msg) {
        this.closeProgressDialog();
        if( msg.what== GsonResponseHandler.SUCCESS ){
            if( msg.obj instanceof LabelResult ){
                deal_scan(msg.obj);
            }else {
                deal_upload(msg.obj);
            }
        }else if(msg.what==GsonResponseHandler.FAILTURE){
            if( msg.obj instanceof LabelResult ){
                LabelResult result= (LabelResult)msg.obj;
                String erro = result.getMessage();
                Snackbar.make(mContentView,erro,Snackbar.LENGTH_LONG).show();
            }else if(msg.obj instanceof BaseBean){
                BaseBean result = (BaseBean)msg.obj;
                String error = result.getMessage();
                Snackbar.make(mContentView,error,Snackbar.LENGTH_LONG).show();
            }else if( msg.obj instanceof SocketTimeoutException || msg.obj instanceof ConnectTimeoutException){
                Snackbar.make( mContentView , "连接超时，请重试", Snackbar.LENGTH_LONG).show();
                return true;
            }else{
                Snackbar.make(mContentView,"请求失败",Snackbar.LENGTH_LONG).show();
            }
        }
        return false;
    }

    protected void deal_scan(Object obj){
        LabelResult result = (LabelResult)obj;
        if( result==null)return;
        if( result.getCode() == Constant.REQUEST_LOGIN ){
            EventBus.getDefault().post(new LoginEvent());
            return;
        }else if( result.getCode() == Constant.RESULT_SUCCESS) {
            if( result.getData().getType().equals("floor")) {

                tvFloorName.setText(result.getData().getName());
                tvFloorName.setTag(result.getData());
                String floorname = result.getData().getName();
                String floorrfid = result.getData().getRfid();
                PreferenceHelper.writeString(getContext(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_FLOORNAME, floorname);
                PreferenceHelper.writeString(getContext(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_FLOORRFID, floorrfid);
            }else if( result.getData().getType().equals("box")){
                String boxname = result.getData().getName();
                String boxrfid = result.getData().getRfid();

                for( LocationBean item : data){
                    if( item.getBoxRfid().equals( boxrfid)){
                        Snackbar.make(mContentView, boxname +" 标签已经扫描过了",Snackbar.LENGTH_LONG).show();
                        return;
                    }
                }

                LocationBean bean =new LocationBean();
                bean.setBoxRfid(boxrfid);
                bean.setBoxName(boxname);
                data.add(bean);
                adapter.notifyDataSetChanged();
                JSONUtil<List<LocationBean>> jsonUtil = new JSONUtil<>();
                String json = jsonUtil.toJson( data );
                PreferenceHelper.writeString(this.getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_BOXDATA, json);
                rlNoData.setVisibility(View.GONE);
            }else{
                Snackbar.make(mContentView, "查无此标签信息",Snackbar.LENGTH_LONG).show();
            }
        }else {
            String msg = result.getMessage();
            Snackbar.make(mContentView, msg, Snackbar.LENGTH_LONG).show();
        }
    }

    protected void deal_upload( Object obj){
        BaseBean result = (BaseBean)obj;
        if(result==null) return;
        if( result.getCode()==Constant.REQUEST_LOGIN ){
            EventBus.getDefault().post(new LoginEvent());
            return;
        }else if( result.getCode() == Constant.RESULT_SUCCESS) {
            PreferenceHelper.writeString(getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_FLOORRFID, "");
            PreferenceHelper.writeString(getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_FLOORNAME, "");
            PreferenceHelper.writeString(getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_BOXDATA, "");
            data.clear();
            adapter.notifyDataSetChanged();
            tvFloorName.setText("");
            tvFloorName.setTag(null);
            rlNoData.setVisibility(View.VISIBLE);
            Snackbar.make(mContentView, "上传成功", Snackbar.LENGTH_LONG).show();
        }else{
            String msg = result.getMessage();
            Snackbar.make(mContentView,"上传失败",Snackbar.LENGTH_LONG).show();
        }
    }

    @Override
    protected void initView(Bundle savedInstanceState) {
        setContentView(R.layout.fragment_location);
        recyclerView = getViewById(R.id.location_boxs);
        LinearLayoutManager manager = new LinearLayoutManager(this.getActivity());
        recyclerView.setLayoutManager(manager);
        tvFloorName = getViewById(R.id.location_floor);
        tvInfo = getViewById(R.id.location_info);
        tvOperate =getViewById(R.id.location_operate);
        tvOperate.setTypeface(MApplication.typeface);

        rlNoData = getViewById(R.id.location_nodata);
        tvNoDataTip = getViewById(R.id.location_nodata_tip);
        tvNoDataPic = getViewById(R.id.location_nodata_pic);
        tvNoDataPic.setTypeface(MApplication.typeface);

        handler = new Handler(this);
        gsonResponseHandler = new GsonResponseHandler<>(getContext(), handler , BaseBean.class);

        labelResponeseHandler =new GsonResponseHandler<>(getContext(),handler,LabelResult.class);

    }

    @Override
    protected void setListener() {
        tvOperate.setOnClickListener(this);
    }

    @Override
    protected void processLogic(Bundle savedInstanceState) {
        loadLocalData();
    }

    @Override
    protected void onUserVisible() {
       String tt = "sss";
    }

    @Override
    public void onClick(View v) {
        if( v.getId() == R.id.location_operate ){
            upload();
            //demo();
        }
    }

    protected void upload(){
        if( !canConnect()){
            return;
        }

        String floorname = tvFloorName.getText().toString().trim();
        LabelInfoBean floor = (LabelInfoBean)tvFloorName.getTag();
        if(TextUtils.isEmpty(floorname) || floor==null ){
            Snackbar.make(mContentView,"请扫描层架标签",Snackbar.LENGTH_LONG).show();
            return;
        }
        if( data==null|| data.size()<1){
            Snackbar.make(mContentView,"请扫描档案盒标签",Snackbar.LENGTH_LONG).show();
            return;
        }
        String boxids ="";
        for(LocationBean bean : data){
            if(!TextUtils.isEmpty( boxids )){
                boxids+=",";
            }
            boxids+= bean.getBoxRfid();
        }

        showProgressDialog("","正在上传数据，请稍等...");
        RequestParams params = new RequestParams();
        params.add("floorrfid", floor.getRfid() );
        params.add("boxrfids",boxids);
        params.add("isadd","true");
        AsyncHttpUtil.get( Constant.UPLOAD_BOX_URL , params , gsonResponseHandler );
    }

    protected void demo() {
        setRFID("1");

        setRFID("213");
        //setRFID("214");
        //setRFID("215");
        setRFID("216");
        setRFID("217");
        setRFID("218");
        setRFID("219");
//        LocationBean bean = new LocationBean();
//        bean.setBoxName("一号盒");
//        bean.setBoxRfid("werw2342323222121");
//        bean.setFloorname("");
//        bean.setFloorRfid("");
//        if( data==null){
//            data=new ArrayList<>();
//        }
//        data.add(bean);
//        JSONUtil<List<LocationBean>> jsonUtil = new JSONUtil<>();
//        String json = jsonUtil.toJson( data );
//        PreferenceHelper.writeString(this.getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_BOXDATA, json);
//
//        adapter.notifyDataSetChanged();
//        rlNoData.setVisibility(View.GONE);
    }

    protected void loadLocalData(){
        String floorname = PreferenceHelper.readString(this.getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_FLOORNAME, "");
        String floorrfid = PreferenceHelper.readString(this.getActivity(),Constant.LOCATION_INFO_FILE,Constant.LOCATION_FLOORRFID,"");
        String boxdata = PreferenceHelper.readString(this.getActivity(),Constant.LOCATION_INFO_FILE,Constant.LOCATION_BOXDATA );
        LabelInfoBean floor = new LabelInfoBean();
        floor.setName(floorname);
        floor.setRfid(floorrfid);
        floor.setType("floor");
        if( !TextUtils.isEmpty(floorname)) {
            tvFloorName.setText(floorname);
            tvFloorName.setTag(floor);
        }
        JSONUtil<List<LocationBean>> jsonUtil = new JSONUtil<>();
        data = new ArrayList<LocationBean>();
        if(!TextUtils.isEmpty(boxdata)) {
            try {
                Type type = new TypeToken<ArrayList<LocationBean>>(){}.getType();
                data = jsonUtil.toListBean(boxdata, type);
            }catch (Exception ex){
                Logger.e( ex.getMessage() , ex);
            }
        }
        adapter = new LocationAdapter(data , this.getActivity());
        adapter.setOnRCItemClickListener(this);
        recyclerView.setAdapter(adapter);

        if( data.size() <1 ){
            rlNoData.setVisibility(View.VISIBLE);
        }else{
            rlNoData.setVisibility(View.GONE);
        }
    }

    @Override
    public void OnRCItemClick(View view, int postion) {
        if( postion<0 || postion >= data.size() )return;

        //Toast.makeText(getContext(), "position="+ String.valueOf( postion ),Toast.LENGTH_LONG).show();

        data.remove(postion);
        adapter.notifyDataSetChanged();

        JSONUtil<List<LocationBean>> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson( data);
        PreferenceHelper.writeString(getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_BOXDATA, json);

        rlNoData.setVisibility(data.size() < 1 ? View.VISIBLE : View.GONE);
    }

    @Override
    public String getTitle() {
        return Constant.FRAGMENT_LOCATION;
    }


    @Override
    public void setRFID(String rfid) {
        if(TextUtils.isEmpty(rfid))return;
        queryLabelInfoByRFID(rfid);
    }

    protected  void queryLabelInfoByRFID(String rfid){
        if( !canConnect()){
            return;
        }

        this.showProgressDialog("", "正在查询标签信息，请稍等...");
        String url = Constant.GETLABELINF_URL;
        RequestParams params =new RequestParams();
        params.add("rfid",rfid);

        AsyncHttpUtil.get( url , params, labelResponeseHandler);
    }
}

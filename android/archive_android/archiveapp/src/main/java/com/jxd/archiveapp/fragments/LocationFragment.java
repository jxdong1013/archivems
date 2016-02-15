package com.jxd.archiveapp.fragments;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
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
import com.jxd.archiveapp.bean.LocationBean;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.Logger;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

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
    Handler handler;

    public LocationFragment() {
    }

    public static LocationFragment newInstance() {
        LocationFragment fragment = new LocationFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public boolean handleMessage(Message msg) {
        this.closeProgressDialog();
        if( msg.what==Constant.REQUEST_SCUESS){
            BaseBean result = (BaseBean)msg.obj;
            PreferenceHelper.writeString(getActivity(),Constant.LOCATION_INFO_FILE,Constant.LOCATION_FLOORRFID,"");
            PreferenceHelper.writeString(getActivity(),Constant.LOCATION_INFO_FILE,Constant.LOCATION_FLOORNAME,"");
            PreferenceHelper.writeString(getActivity(), Constant.LOCATION_INFO_FILE, Constant.LOCATION_BOXDATA,"");
            data.clear();
            adapter.notifyDataSetChanged();
            Snackbar.make(mContentView, "上传成功",Snackbar.LENGTH_LONG).show();

        }else if(msg.what==Constant.REQUEST_FAILED){

        }
        return false;
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

        gsonResponseHandler = new GsonResponseHandler<>(getContext(), handler , BaseBean.class);
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
            update();
        }
    }

    protected void update(){
        String floorrfid = tvFloorName.getText().toString().trim();
        if(TextUtils.isEmpty(floorrfid)){
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
        params.add("floorrfid", floorrfid);
        params.add("boxrfids",boxids);
        AsyncHttpUtil.get( Constant.UPLOAD_BOX_URL , params , gsonResponseHandler );
    }

    protected void Update(){
        LocationBean bean = new LocationBean();
        bean.setBoxName("一号盒");
        bean.setBoxRfid("werw2342323222121");
        bean.setFloorname("");
        bean.setFloorRfid("");
        if( data==null){
            data=new ArrayList<>();
        }
        data.add(bean);
        JSONUtil<List<LocationBean>> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson( data );
        PreferenceHelper.writeString(this.getActivity(), Constant.LOCATION_INFO_FILE , Constant.LOCATION_BOXDATA ,  json);

        adapter.notifyDataSetChanged();
        rlNoData.setVisibility(View.GONE);
    }

    protected void loadLocalData(){
        String floorname = PreferenceHelper.readString( this.getActivity() , Constant.LOCATION_INFO_FILE , Constant.LOCATION_FLOORNAME,"");
        String floorrfid = PreferenceHelper.readString(this.getActivity(),Constant.LOCATION_INFO_FILE,Constant.LOCATION_FLOORRFID,"");
        String boxdata = PreferenceHelper.readString(this.getActivity(),Constant.LOCATION_INFO_FILE,Constant.LOCATION_BOXDATA );

        if( !TextUtils.isEmpty(floorname)) {
            tvFloorName.setText(floorname);
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

        Toast.makeText(getContext(), "position="+ String.valueOf( postion ),Toast.LENGTH_LONG).show();

        data.remove(postion);
        adapter.notifyDataSetChanged();

        JSONUtil<List<LocationBean>> jsonUtil = new JSONUtil<>();
        String json = jsonUtil.toJson( data);
        PreferenceHelper.writeString( getActivity() , Constant.LOCATION_INFO_FILE, Constant.LOCATION_BOXDATA , json );

        rlNoData.setVisibility( data.size()<1? View.VISIBLE:View.GONE );
    }

    @Override
    public String getTitle() {
        return "标签定位";
    }
}

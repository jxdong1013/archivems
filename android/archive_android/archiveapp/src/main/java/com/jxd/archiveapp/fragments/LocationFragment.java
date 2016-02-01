package com.jxd.archiveapp.fragments;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.google.gson.reflect.TypeToken;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.LocationAdapter;
import com.jxd.archiveapp.adapters.OnRCItemClickListener;
import com.jxd.archiveapp.bean.LocationBean;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.Logger;
import com.jxd.archiveapp.utils.PreferenceHelper;

import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class LocationFragment extends BaseFragment implements View.OnClickListener , OnRCItemClickListener {

    RecyclerView recyclerView;
    LocationAdapter adapter;
    TextView tvFloorName;
    TextView tvInfo;
    TextView tvOperate;
    List<LocationBean> data;
    RelativeLayout rlNoData;
    TextView tvNoDataTip;
    TextView tvNoDataPic;

    public LocationFragment() {
    }

    /**
     * @return A new instance of fragment LocationFragment.
     */
    public static LocationFragment newInstance() {
        LocationFragment fragment = new LocationFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
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
            Update();
        }
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

        rlNoData.setVisibility( data.size()<1? View.GONE:View.VISIBLE );
    }
}

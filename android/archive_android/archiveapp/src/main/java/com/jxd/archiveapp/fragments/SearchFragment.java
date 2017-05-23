package com.jxd.archiveapp.fragments;

import android.content.Context;
import android.content.SharedPreferences;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.PopupWindow;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.google.gson.Gson;
import com.jxd.archiveapp.Constant;
import com.jxd.archiveapp.GsonResponseHandler;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.ArchiveAdapter;
import com.jxd.archiveapp.adapters.SearchAdapter;
import com.jxd.archiveapp.bean.ArchiveResult;
import com.jxd.archiveapp.bean.LoginEvent;
import com.jxd.archiveapp.bean.PageArchive;
import com.jxd.archiveapp.bean.SearchEvent;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.Divider;
import com.jxd.archiveapp.utils.EventManager;
import com.jxd.archiveapp.utils.JSONUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.RequestParams;
import org.apache.http.conn.ConnectTimeoutException;
import org.w3c.dom.Text;

import java.net.SocketTimeoutException;
import java.security.spec.KeySpec;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import cn.bingoogolapple.androidcommon.adapter.BGAOnItemChildClickListener;
import cn.bingoogolapple.refreshlayout.BGANormalRefreshViewHolder;
import cn.bingoogolapple.refreshlayout.BGARefreshLayout;
import cn.bingoogolapple.refreshlayout.BGARefreshViewHolder;
import org.greenrobot.eventbus.EventBus;
import org.greenrobot.eventbus.Subscribe;

/**
 * 标签检索
 */
public class SearchFragment extends BaseFragment implements  BGARefreshLayout.BGARefreshLayoutDelegate , Handler.Callback{
    private BGARefreshLayout refreshLayout;
    private RecyclerView recyclerView;
    private ArchiveAdapter adapter;
    private int pageIdx = 0;
    private TextView search_nodata_pic;
    private RelativeLayout search_nodata;
    private EditText etKey;
    private GsonResponseHandler<ArchiveResult> gsonResponseHandler;
    private Handler handler;
    private EventManager eventManager;
//    private RecyclerView recyclerViewSearchList;
//    private List<String> keys;
//    private SearchAdapter searchAdapter;

    public SearchFragment() {
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        eventManager = new EventManager(this);
        eventManager.Register();
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        eventManager.UnRegister();
    }

    @Override
    protected void initView(Bundle savedInstanceState) {
        setContentView(R.layout.fragment_search);
        refreshLayout = getViewById(R.id.refreslayout);
        recyclerView = getViewById(R.id.recycleView);
        recyclerView.addItemDecoration(new Divider(this.getActivity()));

        search_nodata = getViewById(R.id.search_nodata);
        search_nodata_pic = getViewById(R.id.search_nodata_pic);
        search_nodata_pic.setTypeface(MApplication.typeface);

        etKey = getViewById(R.id.search_one_text);

        handler = new Handler(this);
        gsonResponseHandler = new GsonResponseHandler<>(this.getContext(), handler , ArchiveResult.class);

        //recyclerViewSearchList = getViewById(R.id.searchlist);

        //readKeys();

        //setTextView();
    }

    @Override
    public boolean handleMessage(Message msg) {
        if( msg.what== GsonResponseHandler.SUCCESS){
            refreshLayout.endLoadingMore();
            refreshLayout.endRefreshing();
            ArchiveResult result = (ArchiveResult)msg.obj;
            if( result==null){
                Snackbar.make(mContentView,"请求失败，请重试",Snackbar.LENGTH_LONG).show();
                return true;
            }
            if( result.getCode()== Constant.REQUEST_LOGIN){//重新登录
                EventBus.getDefault().post(new LoginEvent());
                return true;
            }else if( result.getCode() == Constant.REQUEST_FAILED ){
                String errorMsg = result.getMessage();
                if(TextUtils.isEmpty(errorMsg)) errorMsg="请求失败";
                Snackbar.make(mContentView , errorMsg , Snackbar.LENGTH_LONG).show();
                return true;
            }else{
                if( result.getData() ==null ) return true;

                if( result.getData().getData()==null|| result.getData().getData().size()<1 ){
                    if(adapter.getItemCount()<1){
                        search_nodata.setVisibility(View.VISIBLE);
                    }else {
                        Snackbar.make(mContentView, "已经拉到底了,歇歇吧！", Snackbar.LENGTH_LONG).show();
                    }
                    return true;
                }
                pageIdx = result.getData().getPageIdx()+1;
                PageArchive data = result.getData();
                //adapter.addNewDatas(  data.getData() );
                adapter.addMoreDatas(data.getData());
                //adapter.notifyDataSetChanged();
                return true;
            }
        }else if(msg.what==GsonResponseHandler.FAILTURE){
            refreshLayout.endLoadingMore();
            refreshLayout.endRefreshing();
            if( msg.obj instanceof SocketTimeoutException || msg.obj instanceof ConnectTimeoutException){
                Snackbar.make( mContentView , "连接超时，请重试", Snackbar.LENGTH_LONG).show();
                return  true;
            }else{
                Snackbar.make( mContentView , "请求失败", Snackbar.LENGTH_LONG).show();
                return  true;
            }
        }
        return false;
    }

    @Override
    protected void setListener() {
        refreshLayout.setDelegate(this);


        // 使用addOnScrollListener，而不是setOnScrollListener();
//        recyclerView.addOnScrollListener(new RecyclerView.OnScrollListener() {
//            @Override
//            public void onScrollStateChanged(RecyclerView recyclerView, int newState) {
//                //Logger.i(TAG, "测试自定义onScrollStateChanged被调用");
//            }
//
//            @Override
//            public void onScrolled(RecyclerView recyclerView, int dx, int dy) {
//                //Logger.i(TAG, "测试自定义onScrolled被调用");
//            }
//        });
    }

    @Override
    protected void onUserVisible() {
    }

    @Override
    protected void processLogic(Bundle savedInstanceState) {
        adapter = new ArchiveAdapter(recyclerView);
        BGARefreshViewHolder refreshViewHolder = new BGANormalRefreshViewHolder( MApplication.getApplication() ,true);
        refreshLayout.setRefreshViewHolder(refreshViewHolder);

        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity());
        recyclerView.setLayoutManager(linearLayoutManager);
        recyclerView.setAdapter(adapter);

        handler.post(new Runnable() {
            @Override
            public void run() {
                refreshLayout.beginRefreshing();
            }
        });
    }

    @Override
    public boolean onBGARefreshLayoutBeginLoadingMore(BGARefreshLayout refreshLayout) {
        go(pageIdx);
        return true;
    }

    protected void go(int index){
        if(!canConnect()){
            refreshLayout.endRefreshing();
            refreshLayout.endLoadingMore();
            return;
        }
        search_nodata.setVisibility(View.GONE);

        String key = etKey.getText().toString().trim();
        RequestParams params = new RequestParams();
        params.add("manager", key);
        params.add("title", key);
        params.add("number",key);
        params.add("floorrfid", key);
        params.add("boxrfid", key);
        params.add("pageidx", String.valueOf( pageIdx ) );
        params.add("pagesize", String.valueOf( Constant.PAGESIZE));

        AsyncHttpUtil.get(Constant.QUERY_ARCHIVE_URL, params, gsonResponseHandler);
    }

    @Override
    public void onBGARefreshLayoutBeginRefreshing(BGARefreshLayout refreshLayout) {
        pageIdx=0;
        adapter.clear();
        go(pageIdx);
    }

    @Override
    public String getTitle() {
        return Constant.FRAGMENT_SEARCH;
    }

    @Subscribe
    public void refreshData(SearchEvent event){

        refreshLayout.beginRefreshing();
    }

    @Override
    public void setRFID(String rfid) {
        if(TextUtils.isEmpty(rfid))return;
        Snackbar.make(mContentView,rfid,Snackbar.LENGTH_LONG).show();
        etKey.setText(rfid);

        refreshLayout.beginRefreshing();
    }
}

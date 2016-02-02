package com.jxd.archiveapp.fragments;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.ArchiveAdapter;
import com.jxd.archiveapp.bean.ArchiveBean;

import java.util.List;

import cn.bingoogolapple.refreshlayout.BGANormalRefreshViewHolder;
import cn.bingoogolapple.refreshlayout.BGARefreshLayout;
import cn.bingoogolapple.refreshlayout.BGARefreshViewHolder;

/**
 * A simple {@link Fragment} subclass.
 */
public class SearchFragment extends BaseFragment implements BGARefreshLayout.BGARefreshLayoutDelegate{

    private BGARefreshLayout refreshLayout;
    private RecyclerView recyclerView;
    private ArchiveAdapter adapter;
    private int mNewPageNumber = 0;
    private int mMorePageNumber = 0;
    private List<ArchiveBean> data;

    private TextView search_nodata_pic;
    private RelativeLayout search_nodata;


    public SearchFragment() {
        // Required empty public constructor
    }

    public static SearchFragment newInstance() {
        SearchFragment fragment = new SearchFragment();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
    }

    @Override
    protected void initView(Bundle savedInstanceState) {
        setContentView(R.layout.fragment_search);
        refreshLayout = getViewById(R.id.refreslayout);
        recyclerView = getViewById(R.id.recycleView);
        LinearLayoutManager linearLayoutManager=new LinearLayoutManager(getActivity());
        recyclerView.setLayoutManager(linearLayoutManager);

        search_nodata = getViewById(R.id.search_nodata);
        search_nodata_pic = getViewById(R.id.search_nodata_pic);
        search_nodata_pic.setTypeface(MApplication.typeface);
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
        //mNewPageNumber = 0;
        //mMorePageNumber = 0;
//        mEngine.loadInitDatas().enqueue(new Callback<List<RefreshModel>>() {
//            @Override
//            public void onResponse(Response<List<RefreshModel>> response) {
//                mAdapter.setDatas(response.body());
//            }
//
//            @Override
//            public void onFailure(Throwable t) {
//            }
//        });
    }


    @Override
    protected void processLogic(Bundle savedInstanceState) {
        adapter = new ArchiveAdapter(recyclerView);
        BGARefreshViewHolder refreshViewHolder = new BGANormalRefreshViewHolder( MApplication.getApplication() ,true);
        refreshViewHolder.setLoadingMoreText("sadfasdfas");
        refreshLayout.setRefreshViewHolder(refreshViewHolder);
        recyclerView.setAdapter(adapter);
    }

    @Override
    public boolean onBGARefreshLayoutBeginLoadingMore(BGARefreshLayout refreshLayout) {

        String dd="";

//        mMorePageNumber++;
//        if (mMorePageNumber > 4) {
//            refreshLayout.endLoadingMore();
//            //showToast("没有更多数据了");
//            return false;
//        }

        //showLoadingDialog();
//        mEngine.loadMoreData(mMorePageNumber).enqueue(new Callback<List<RefreshModel>>() {
//            @Override
//            public void onResponse(final Response<List<RefreshModel>> response) {
//                ThreadUtil.runInUIThread(new Runnable() {
//                    @Override
//                    public void run() {
//                        mRefreshLayout.endLoadingMore();
//                        dismissLoadingDialog();
//                        mAdapter.addMoreDatas(response.body());
//                    }
//                }, MainActivity.LOADING_DURATION);
//            }
//
//            @Override
//            public void onFailure(Throwable t) {
//                mRefreshLayout.endLoadingMore();
//                dismissLoadingDialog();
//            }
//        });

        return true;
    }

    @Override
    public void onBGARefreshLayoutBeginRefreshing(BGARefreshLayout refreshLayout) {

        String dd="";

//        mNewPageNumber++;
//        if (mNewPageNumber > 4) {
//            mRefreshLayout.endRefreshing();
//            showToast("没有最新数据了");
//            return;
//        }
//
//        showLoadingDialog();
//        mEngine.loadNewData(mNewPageNumber).enqueue(new Callback<List<RefreshModel>>() {
//            @Override
//            public void onResponse(final Response<List<RefreshModel>> response) {
//                ThreadUtil.runInUIThread(new Runnable() {
//                    @Override
//                    public void run() {
//                        mRefreshLayout.endRefreshing();
//                        dismissLoadingDialog();
//                        mAdapter.addNewDatas(response.body());
//                        mDataRv.smoothScrollToPosition(0);
//                    }
//                }, MainActivity.LOADING_DURATION);
//            }
//
//            @Override
//            public void onFailure(Throwable t) {
//                mRefreshLayout.endRefreshing();
//                dismissLoadingDialog();
//            }
//        });
    }

    @Override
    public String getTitle() {
        return "标签检索";
    }
}

package com.jxd.archiveapp.fragments;

import android.content.Context;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.jxd.archiveapp.R;
import com.jxd.archiveapp.adapters.ArchiveAdapter;

import java.nio.Buffer;
import java.util.logging.Logger;

import butterknife.ButterKnife;
import cn.bingoogolapple.refreshlayout.BGARefreshLayout;

/**
 * A simple {@link Fragment} subclass.
 * Activities that contain this fragment must implement the
 * {@link SearchFragment.OnFragmentInteractionListener} interface
 * to handle interaction events.
 * Use the {@link SearchFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class SearchFragment extends BaseFragment implements BGARefreshLayout.BGARefreshLayoutDelegate{

    private BGARefreshLayout refreshLayout;
    private RecyclerView recyclerView;
    private ArchiveAdapter adapter;
    private int mNewPageNumber = 0;
    private int mMorePageNumber = 0;


    public SearchFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment SearchFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static SearchFragment newInstance(String param1, String param2) {
        SearchFragment fragment = new SearchFragment();
        Bundle args = new Bundle();
        fragment.setArguments(args);
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
    }


    @Override
    protected void setListener() {
        refreshLayout.setDelegate(this);
        adapter = new ArchiveAdapter(recyclerView);

        // 使用addOnScrollListener，而不是setOnScrollListener();
        recyclerView.addOnScrollListener(new RecyclerView.OnScrollListener() {
            @Override
            public void onScrollStateChanged(RecyclerView recyclerView, int newState) {
                //Logger.i(TAG, "测试自定义onScrollStateChanged被调用");
            }

            @Override
            public void onScrolled(RecyclerView recyclerView, int dx, int dy) {
                //Logger.i(TAG, "测试自定义onScrolled被调用");
            }
        });
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

    }

    @Override
    public boolean onBGARefreshLayoutBeginLoadingMore(BGARefreshLayout refreshLayout) {
        mMorePageNumber++;
        if (mMorePageNumber > 4) {
            refreshLayout.endLoadingMore();
            //showToast("没有更多数据了");
            return false;
        }

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
}

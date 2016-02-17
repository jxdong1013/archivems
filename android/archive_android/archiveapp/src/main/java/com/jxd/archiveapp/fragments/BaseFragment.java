package com.jxd.archiveapp.fragments;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.support.annotation.IdRes;
import android.support.annotation.LayoutRes;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.avast.android.dialogs.fragment.ProgressDialogFragment;
import com.jxd.archiveapp.BaseActivity;
import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.utils.Logger;

/**
 * Created by 向东 on 2016-1-31.
 */
public abstract class BaseFragment extends Fragment {
    protected String TAG;
    protected View mContentView;
    protected BaseActivity mActivity;
    protected ProgressDialogFragment _progressDialog=null;
    protected ProgressDialog progressDialog;

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        TAG = this.getClass().getSimpleName();
        mActivity = (BaseActivity) context;
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {
            onUserVisible();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        // 避免多次从xml中加载布局文件
        if (mContentView == null) {
            initView(savedInstanceState);
            setListener();
            processLogic(savedInstanceState);
        } else {
            ViewGroup parent = (ViewGroup) mContentView.getParent();
            if (parent != null) {
                parent.removeView(mContentView);
            }
        }
        return mContentView;
    }

    protected void setContentView(@LayoutRes int layoutResID) {
        mContentView = LayoutInflater.from(MApplication.getApplication()).inflate(layoutResID, null);
    }
    /**
     * 初始化View控件
     */
    protected abstract void initView(Bundle savedInstanceState);

    /**
     * 给View控件添加事件监听器
     */
    protected abstract void setListener();

    /**
     * 处理业务逻辑，状态恢复等操作
     *
     * @param savedInstanceState
     */
    protected abstract void processLogic(Bundle savedInstanceState);

    /**
     * 当fragment对用户可见时，会调用该方法，可在该方法中懒加载网络数据
     */
    protected abstract void onUserVisible();
    /**
     * 查找View
     *
     * @param id   控件的id
     * @param <VT> View类型
     * @return
     */
    protected <VT extends View> VT getViewById(@IdRes int id) {
        return (VT) mContentView.findViewById(id);
    }

    public abstract String getTitle();

    public abstract void setRFID(String rfid);


    protected void showProgressDialog( String title , String message ){
//        if( _progressDialog !=null ) {
//            _progressDialog.dismiss();
//            _progressDialog=null;
//        }
//
//        ProgressDialogFragment.ProgressDialogBuilder builder = ProgressDialogFragment.createBuilder(this.getActivity() , this.getFragmentManager())
//                .setTitle(title)
//                .setMessage( message )
//                        //.setCancelable(false);
//                .setCancelableOnTouchOutside(false);
//        _progressDialog = (ProgressDialogFragment) builder.show();

        if( progressDialog !=null){
            progressDialog.dismiss();
            progressDialog=null;
        }
        progressDialog = new ProgressDialog(this.getActivity());
        progressDialog.setTitle(title);
        progressDialog.setMessage(message);
        progressDialog.setCanceledOnTouchOutside(false);
        progressDialog.show();
    }

    protected  void closeProgressDialog(){
//        if(_progressDialog!=null){
//            _progressDialog.dismiss();
//            _progressDialog=null;
//        }
        try {
            if (progressDialog != null) {
                progressDialog.dismiss();
                progressDialog = null;
            }
        }catch (Exception ex){
            Logger.e(ex.getMessage(),ex);
        }
    }
}

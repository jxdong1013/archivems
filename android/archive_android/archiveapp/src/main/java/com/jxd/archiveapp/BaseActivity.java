package com.jxd.archiveapp;

import android.app.Activity;
import android.content.Intent;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.avast.android.dialogs.fragment.ProgressDialogFragment;
import com.jxd.archiveapp.bean.CloseEvent;
import com.jxd.archiveapp.utils.NetworkUtil;

import java.io.Serializable;

public class BaseActivity extends AppCompatActivity {
    protected static final String NULL_NETWORK = "无网络或当前网络不可用!";
    ProgressDialogFragment _progressDialog=null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    public void showActivity(Activity aty, Class clazz){
        Intent i = new Intent(aty, clazz);
        aty.startActivity(i);
    }

    public void showActivity(Activity aty , Class clazz , String key , Serializable serialize ){
        Intent i = new Intent(aty, clazz);
        i.putExtra(key, serialize);
        aty.startActivity(i);
    }

    public void skipActivity(Activity aty, Class clazz){
        Intent i = new Intent(aty, clazz);
        aty.startActivity(i);
        aty.finish();
    }

    public void skipActivity(Activity aty , Intent intent){
        aty.startActivity(intent);
        aty.finish();
    }

    public void skipActivity( Activity aty , Class clazz , String key , Serializable serialize ){
        Intent i = new Intent(aty , clazz);
        i.putExtra(key, serialize);
        aty.startActivity(i);
        aty.finish();
    }

    public void showActivity(Activity aty, Intent i){
        aty.startActivity(i);
    }

    /**
     *
     * @return
     */
    protected boolean canConnect(){
        //网络访问前先检测网络是否可用
        if(!NetworkUtil.isConnect(BaseActivity.this)){
            Snackbar.make( this.getWindow().getDecorView() , NULL_NETWORK , Snackbar.LENGTH_LONG).setAction("Action", null).show();
            //ToastUtils.showLongToast(this, NULL_NETWORK);
            return false;
        }
        return true;
    }
    /**
     * 关闭 事件
     * @param event
     */
    public void onEventMainThread( CloseEvent event) {
        this.finish();
    }

    protected boolean showProgressDialog( String title , String message ){
        if( BaseActivity.this.isFinishing() ) return true;
        //网络访问前先检测网络是否可用
        if(canConnect()==false){
            return false;
        }

        if( _progressDialog !=null ) {
            _progressDialog.dismiss();
            _progressDialog=null;
        }
        ProgressDialogFragment.ProgressDialogBuilder builder = ProgressDialogFragment.createBuilder(this, getSupportFragmentManager())
                .setTitle(title)
                .setMessage( message )
                        //.setCancelable(false)
                .setCancelableOnTouchOutside(false);
        _progressDialog = (ProgressDialogFragment) builder.show();

        return true;
    }

    protected  void closeProgressDialog(){
        if( BaseActivity.this.isFinishing() )return;
        if(_progressDialog!=null){
            _progressDialog.dismiss();
            _progressDialog=null;
        }
    }

}

package com.jxd.archiveapp;

import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.design.widget.Snackbar;
import android.text.Editable;
import android.text.TextUtils;
import android.text.TextWatcher;
import android.view.KeyEvent;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import com.jxd.archiveapp.bean.CloseEvent;
import com.jxd.archiveapp.bean.UserBean;
import com.jxd.archiveapp.bean.UserResult;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.jxd.archiveapp.utils.PreferenceHelper;
import com.loopj.android.http.PersistentCookieStore;
import com.loopj.android.http.RequestParams;
import org.apache.http.conn.ConnectTimeoutException;
import org.apache.http.cookie.Cookie;

import java.net.SocketTimeoutException;
import java.util.List;

import butterknife.Bind;
import butterknife.ButterKnife;
import de.greenrobot.event.EventBus;

public class LoginActivity extends BaseActivity implements View.OnClickListener , Handler.Callback
{
    @Bind(R.id.header_back)
    public Button header_back;
    // 用户名
    @Bind(R.id.edtUserName)
    public EditText userName;
    // 密码
    @Bind(R.id.edtPwd)
    public EditText passWord;
    // 登录按钮
    @Bind(R.id.btnLogin)
    public Button loginBtn;
    // 忘记密码
    @Bind(R.id.header_operate)
    public TextView forgetPsw;
    // 界面名称
    @Bind(R.id.header_title)
    public TextView header_title;
    @Bind(R.id.login_setting)
    TextView loginSetting;
    @Bind(R.id.login_url)
    com.huotu.android.library.libedittext.EditText loginUrl;

    Handler handler = new Handler(this);
    private GsonResponseHandler<UserResult> gsonResponseHandler;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        PersistentCookieStore cookieStore = new PersistentCookieStore(MApplication.getApplication());
        List<Cookie> cookies = cookieStore.getCookies();
        if(cookies !=null && cookies.size()>0){
            this.skipActivity(this,MainActivity.class);
            return;
        }

        setContentView(R.layout.activity_login);
        initView();
    }
    public void initView(){
        ButterKnife.bind(this);
        userName.setText("");
        passWord.setText("");
        header_title.setText("用户登录");
        loginBtn.setOnClickListener(this);
        forgetPsw.setOnClickListener(this);
        forgetPsw.setText("忘记密码？");
        forgetPsw.setVisibility(View.GONE);
        header_back.setOnClickListener(this);
        loginSetting.setOnClickListener(this);
        String url = PreferenceHelper.readString(this,Constant.URL_FILE,Constant.URL_API);
        loginUrl.setText(url);
        loginUrl.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                String temp = s.toString();
                if( temp.toString().endsWith("/")==false){
                    temp +="/";
                }
                if( !temp.startsWith("http://") ){
                    temp ="http://"+temp;
                }
                PreferenceHelper.writeString(LoginActivity.this, Constant.URL_FILE, Constant.URL_API, temp);
            }

            @Override
            public void afterTextChanged(Editable s) {
                String temp = s.toString();
            }
        });

        gsonResponseHandler = new GsonResponseHandler<>(this, handler, UserResult.class );

        String username = PreferenceHelper.readString(this , Constant.USER_INFO_FILE, Constant.USER_NAME);
        String pwd = PreferenceHelper.readString(this, Constant.USER_INFO_FILE,Constant.USER_PASSWORD);
        if( !TextUtils.isEmpty(username)) {
            userName.setText(username);
        }
        if( !TextUtils.isEmpty(pwd)){
            passWord.setText(pwd);
        }
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        ButterKnife.unbind(this);
    }

    @Override
    public boolean handleMessage(Message msg) {
        this.closeProgressDialog();

        if( msg.what == GsonResponseHandler.SUCCESS ){
            if( msg.obj instanceof UserResult) {
                UserResult result = (UserResult)msg.obj;
                int code = result.getCode();
                if( code == Constant.REQUEST_SCUESS) {
                    UserBean bean = result.getData();
                    PreferenceHelper.writeInt(this, Constant.USER_INFO_FILE, Constant.USER_USERID, bean.getUserid());
                    PreferenceHelper.writeString(this, Constant.USER_INFO_FILE, Constant.USER_NAME, bean.getUsername());
                    PreferenceHelper.writeString(this , Constant.USER_INFO_FILE,Constant.USER_REALNAME,bean.getRealname());
                    PreferenceHelper.writeString(this,Constant.USER_INFO_FILE,Constant.USER_PASSWORD,bean.getPassword());
                    PreferenceHelper.writeString(this,Constant.USER_INFO_FILE,Constant.USER_PHONE,bean.getPhone());
                    PreferenceHelper.writeString(this, Constant.USER_INFO_FILE, Constant.USER_SEX, bean.getSex());

                    this.skipActivity(this, MainActivity.class);
                    return true;
                }else if( code== Constant.REQUEST_FAILED){
                    String error = result.getMessage();
                    if(TextUtils.isEmpty( error )) error="请求失败";
                    Snackbar.make(getWindow().getDecorView(), error , Snackbar.LENGTH_LONG).show();
                    return true;
                }
            }
        }else {
            if( msg.obj instanceof SocketTimeoutException || msg.obj instanceof ConnectTimeoutException){
                Snackbar.make(this.getWindow().getDecorView(), "连接超时，请重试", Snackbar.LENGTH_LONG).show();
                return  true;
            }
            else {
                Toast.makeText(this, "登录失败", Toast.LENGTH_LONG).show();
                return true;
            }
        }
        return false;
    }

    protected void login() {
        if (false == canConnect()) {
            return;
        }

        String username = userName.getText().toString();
        String password = passWord.getText().toString();
        if (TextUtils.isEmpty(username)) {
            userName.setError("请输入用户名");
            return;
        }
        if (TextUtils.isEmpty(password)) {
            passWord.setError("请输入密码");
            return;
        }

        this.showProgressDialog("", "正在登录，请稍等...");

        RequestParams params = new RequestParams();
        params.add("userName", username);
        params.add("password", password);
        AsyncHttpUtil.post( Constant.LOGIN_URL, params, gsonResponseHandler);

        //调用登录接口之前，先清空一下Token的值
        //PreferenceHelper.writeString(this.getApplicationContext(), Constant.LOGIN_USER_INFO, Constant.PRE_USER_TOKEN, "");
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.header_operate: {
                //showActivity(LoginActivity.this, ForgetActivity.class);
            }
            break;
            case R.id.btnLogin: {

                //this.skipActivity(this,MainActivity.class);

                login();
            }
            break;
            case R.id.header_back: {
                EventBus.getDefault().post(new CloseEvent());
                finish();
            }
            break;
            case R.id.login_setting:{
                loginUrl.setVisibility( loginUrl.getVisibility() == View.GONE ? View.VISIBLE : View.GONE );
                break;
            }
        }
    }

//    @Override
//    public void onNegativeButtonClicked(int requestCode) {
//
//    }
//
//    @Override
//    public void onNeutralButtonClicked(int requestCode) {
//
//    }


    public boolean onKeyDown(int keyCode, KeyEvent event){
        if (keyCode == KeyEvent.KEYCODE_BACK
                && event.getAction() == KeyEvent.ACTION_DOWN){
            EventBus.getDefault().post(new CloseEvent());
            // finish自身
            LoginActivity.this.finish();
            return true;
        }
        return super.onKeyDown(keyCode, event);
    }
}

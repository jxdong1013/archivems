package com.jxd.archiveapp;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.text.TextUtils;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import com.jxd.archiveapp.bean.CloseEvnt;
import com.jxd.archiveapp.utils.AsyncHttpUtil;
import com.loopj.android.http.RequestParams;
import butterknife.Bind;
import butterknife.ButterKnife;
import de.greenrobot.event.EventBus;

public class LoginActivity extends BaseActivity implements
        View.OnClickListener , Handler.Callback
        //, ISimpleDialogListener
{
    private final static int REQUEST_UPDATE=2045;
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

    Handler handler = new Handler(this);
    //消息的类型
    private int messageType = 0;

    private GsonResponseHandler<String> gsonResponseHandler;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
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

        if(getIntent().hasExtra("type")){
            messageType = getIntent().getIntExtra("type", 0);
        }

        gsonResponseHandler = new GsonResponseHandler<>(this, handler);
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
            this.skipActivity(this,MainActivity.class);
        }else {
            Toast.makeText(this , "登录失败",Toast.LENGTH_LONG).show();
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
        AsyncHttpUtil.post(Constant.LOGIN_URL, params, gsonResponseHandler);

        skipActivity(this , new Intent(this , MainActivity.class));

        //调用登录接口之前，先清空一下Token的值
        //PreferenceHelper.writeString(this.getApplicationContext(), Constant.LOGIN_USER_INFO, Constant.PRE_USER_TOKEN, "");

//        String url = Constant.LOGIN_URL;
//        HttpParaUtils httpUtils = new HttpParaUtils();
//        Map<String,String> paras = new HashMap<>();
//        String pwd = passWord.getText().toString();
//
//        String pwdEncy ="";
//        try {
//            pwdEncy = DigestUtils.md5DigestAsHex(pwd.getBytes("utf-8"));
//        }catch (UnsupportedEncodingException ex){
//        }
//
//        paras.put("username", userName.getText().toString().trim());
//        paras.put("password", pwdEncy);
//        url = httpUtils.getHttpGetUrl(url , paras);
//
//        GsonRequest<HTMerchantModel> loginRequest = new GsonRequest<HTMerchantModel>(
//                Request.Method.GET,
//                url ,
//                HTMerchantModel.class,
//                null,
//                loginListener,
//                new MJErrorListener(this)
//        );
//
//        VolleyRequestManager.AddRequest(loginRequest);
    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.header_operate: {
                //showActivity(LoginActivity.this, ForgetActivity.class);
            }
            break;
            case R.id.btnLogin: {
                login();
            }
            break;
            case R.id.header_back: {
                EventBus.getDefault().post(new CloseEvnt());
                finish();
            }
            break;
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

//    @Override
//    public void onPositiveButtonClicked(int requestCode) {
//        if( requestCode == REQUEST_UPDATE){
//            updateApp();
//        }
//    }

    public boolean onKeyDown(int keyCode, KeyEvent event){
        if (keyCode == KeyEvent.KEYCODE_BACK
                && event.getAction() == KeyEvent.ACTION_DOWN){
            EventBus.getDefault().post(new CloseEvnt());
            // finish自身
            LoginActivity.this.finish();
            return true;
        }
        return super.onKeyDown(keyCode, event);
    }

//    Response.Listener<HTMerchantModel> loginListener = new Response.Listener<HTMerchantModel>() {
//        @Override
//        public void onResponse(HTMerchantModel htMerchantModel) {
//            LoginActivity.this.closeProgressDialog();
//
//            if( null == htMerchantModel ){
//                SimpleDialogFragment.createBuilder( LoginActivity.this , LoginActivity.this.getSupportFragmentManager())
//                        .setTitle("错误信息")
//                        .setMessage("请求出错")
//                        .setNegativeButtonText("关闭")
//                        .show();
//                return;
//            }
//            else if( htMerchantModel.getSystemResultCode() != 1){
//                SimpleDialogFragment.createBuilder( LoginActivity.this , LoginActivity.this.getSupportFragmentManager())
//                        .setTitle("错误信息")
//                        .setMessage(htMerchantModel.getSystemResultDescription())
//                        .setNegativeButtonText("关闭")
//                        .show();
//                return;
//            }else if( htMerchantModel.getResultCode() !=1){
//                SimpleDialogFragment.createBuilder( LoginActivity.this , LoginActivity.this.getSupportFragmentManager())
//                        .setTitle("错误信息")
//                        .setMessage(htMerchantModel.getResultDescription() )
//                        .setNegativeButtonText("关闭")
//                        .show();
//                return;
//            }
//            if( htMerchantModel.getResultData() ==null ){
//                DialogUtils.showDialog( LoginActivity.this , LoginActivity.this.getSupportFragmentManager(),
//                        "错误信息","请求的数据有问题","关闭");
//                return;
//            }
//
//            MerchantModel user = htMerchantModel.getResultData().getUser();
//            if(null != user)
//            {
//                //记录token
//                SellerApplication.getInstance().writeMerchantInfo(user);
//                Intent intent = new Intent(LoginActivity.this , MainActivity.class);
//                intent.putExtra("type", messageType);
//                EventBus.getDefault().post(new RefreshSettingEvent());
//                ActivityUtils.getInstance().skipActivity(LoginActivity.this, intent );
//            }
//            else
//            {
//                ToastUtils.showShort( "未请求到数据");
//            }
//        }
//    };


}

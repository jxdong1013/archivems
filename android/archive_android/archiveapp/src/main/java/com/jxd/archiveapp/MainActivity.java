package com.jxd.archiveapp;

import android.app.PendingIntent;
import android.content.Intent;
import android.nfc.NfcAdapter;
import android.os.Bundle;
import android.support.design.widget.Snackbar;
import android.support.design.widget.TabLayout;
import android.support.v4.app.FragmentManager;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import com.jxd.archiveapp.adapters.MyFragmentViewAdapter;
import com.jxd.archiveapp.fragments.BaseFragment;
import com.jxd.archiveapp.fragments.InventoryFragment;
import com.jxd.archiveapp.fragments.LocationFragment;
import com.jxd.archiveapp.fragments.SearchFragment;
import com.jxd.archiveapp.utils.ByteUtil;
import java.util.ArrayList;
import java.util.List;
import butterknife.Bind;
import butterknife.ButterKnife;

public class MainActivity extends BaseActivity implements SearchView.OnQueryTextListener{

    @Bind(R.id.toolbar)
    Toolbar toolbar;
    //@Bind(R.id.nav_view)
    //NavigationView navigationView;
    //@Bind(R.id.main)
    //RelativeLayout rlmain;
    @Bind(R.id.mainviewPager)
    ViewPager viewPager;
    @Bind(R.id.tab)
    TabLayout tab;

    String[] searchKeys;

    InventoryFragment inventoryFragment;

    FragmentManager fragmentManager;
    SearchFragment searchFragment;
    LocationFragment locationFragment;
    MyFragmentViewAdapter fragmentViewAdapter;
    List<BaseFragment> fragmentList;

    NfcAdapter nfcAdapter;
    PendingIntent mPendingIntent;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.app_bar_main);

        ButterKnife.bind(this);

        fragmentManager = this.getSupportFragmentManager();

        setSupportActionBar(toolbar);

        toolbar.setLogo(R.mipmap.ic_launcher);

        //navigationView.setNavigationItemSelectedListener(this);

        searchFragment = new SearchFragment();
        inventoryFragment =new InventoryFragment();
        locationFragment = new LocationFragment();

        fragmentList = new ArrayList<>();
        fragmentList.add(searchFragment);
        fragmentList.add(locationFragment);
        fragmentList.add(inventoryFragment);
        fragmentViewAdapter = new MyFragmentViewAdapter(fragmentList, fragmentManager);
        viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {

            }

            @Override
            public void onPageSelected(int position) {
                toolbar.setSubtitle(fragmentList.get(position).getTitle());
                if( fragmentList.get(position).getTitle().equals(Constant.FRAGMENT_INVENTORY) ) {
                    MenuItem item = toolbar.getMenu().findItem(R.id.action_inventory);
                    if(item!=null) {
                        item.setVisible(true);
                    }
                }else{
                    MenuItem item = toolbar.getMenu().findItem(R.id.action_inventory);
                    if(item!=null) {
                        item.setVisible(false);
                    }
                }
            }

            @Override
            public void onPageScrollStateChanged(int state) {

            }
        });
        viewPager.setAdapter(fragmentViewAdapter);
        tab.setupWithViewPager(viewPager);

        toolbar.setSubtitle( fragmentList.get(0).getTitle() );
        //tab.setOnTabSelectedListener();

        initNFC();
    }

    @Override
    protected void onResume() {
        super.onResume();

        if (nfcAdapter != null) {
            if (!nfcAdapter.isEnabled()) {
                Snackbar.make( getWindow().getDecorView(), "请打开NFC功能。", Snackbar.LENGTH_LONG).show();
                return;
            }
            nfcAdapter.enableForegroundDispatch(this, mPendingIntent, null, null);
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        if (nfcAdapter != null) {
            nfcAdapter.disableForegroundDispatch(this);
            //mAdapter.disableForegroundNdefPush(this);
        }
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);


        //this.setIntent( intent);
        String rfid = resolveIntent(intent);

        int idx =viewPager.getCurrentItem();
        if( fragmentList.get(idx).getTitle().equals(Constant.FRAGMENT_LOCATION )){
            fragmentList.get(idx).setRFID(rfid);
        }else if( fragmentList.get(idx).getTitle().equals( Constant.FRAGMENT_INVENTORY )){
            fragmentList.get(idx).setRFID(rfid);
        }
    }

    private String resolveIntent(Intent intent) {
        String action = intent.getAction();
        if (NfcAdapter.ACTION_TAG_DISCOVERED.equals(action)
                || NfcAdapter.ACTION_TECH_DISCOVERED.equals(action)
                || NfcAdapter.ACTION_NDEF_DISCOVERED.equals(action)) {

            byte[] myNFCID = intent.getByteArrayExtra(NfcAdapter.EXTRA_ID);
            if (myNFCID != null) {
                String rfid = ByteUtil.Bytes2HexString(myNFCID, myNFCID.length);
                return  rfid;
            }

            //Parcelable[] rawMsgs = intent.getParcelableArrayExtra(NfcAdapter.EXTRA_NDEF_MESSAGES);
            //NdefMessage[] msgs;
            //if (rawMsgs != null) {
            //    msgs = new NdefMessage[rawMsgs.length];
            //    for (int i = 0; i < rawMsgs.length; i++) {
            //        msgs[i] = (NdefMessage) rawMsgs[i];
            //    }
            //} else {
            //    ToastUtil.Show("无法识别的标签类型。");
            //    return;
            // Unknown tag type
            //byte[] empty = new byte[0];
            //byte[] id = intent.getByteArrayExtra(NfcAdapter.EXTRA_ID);
            //Parcelable tag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
            //byte[] payload = dumpTagData(tag).getBytes();
            //NdefRecord record = new NdefRecord(NdefRecord.TNF_UNKNOWN, empty, id, payload);
            //NdefMessage msg = new NdefMessage(new NdefRecord[] { record });
            //msgs = new NdefMessage[] { msg };
        }
        // Setup the views
        //buildTagViews(msgs);
        //}
        return null;
    }


    protected void initNFC(){
        nfcAdapter = NfcAdapter.getDefaultAdapter(this);
        if (nfcAdapter == null) {
            Snackbar.make( this.getWindow().getDecorView(), "设备没有NFC功能,无法扫描标签。", Snackbar.LENGTH_LONG).show();
            return;
        }

        mPendingIntent = PendingIntent.getActivity( this , 0,
                new Intent( this , getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);
        //mNdefPushMessage = new NdefMessage(new NdefRecord[] { newTextRecord(
        //        "Message from NFC Reader :-)", Locale.ENGLISH, true) });
    }

//    @Override
//    protected void onNewIntent(Intent intent) {
//        super.onNewIntent(intent);
//
//
//        if (Intent.ACTION_SEARCH.equals(intent.getAction())) {
//            String query = intent.getStringExtra(SearchManager.QUERY);
//            //doMySearch(query);
//        }
//    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);

        //MenuItem item= menu.findItem(R.id.action_search);
        //searchView = (SearchView)MenuItemCompat.getActionView( item);
        //searchView.setOnQueryTextListener(this);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        if( id == R.id.action_inventory){
            int idx=  viewPager.getCurrentItem();
            ((InventoryFragment)fragmentViewAdapter.getItem(idx)).Upload();

        }


        return super.onOptionsItemSelected(item);
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();

        ButterKnife.unbind(this);
    }

    @Override
    public boolean onQueryTextChange(String newText) {
        //searchView.setSuggestionsAdapter();
        return false;
    }

    @Override
    public boolean onQueryTextSubmit(String query) {

        Snackbar.make( this.getWindow().getDecorView(), query, Snackbar.LENGTH_LONG).show();

        return false;
    }
}

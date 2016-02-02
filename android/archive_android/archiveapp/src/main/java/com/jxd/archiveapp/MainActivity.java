package com.jxd.archiveapp;

import android.app.SearchManager;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.design.widget.TabLayout;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.view.MenuCompat;
import android.support.v4.view.MenuItemCompat;
import android.support.v4.view.ViewPager;
import android.support.v7.widget.SearchView;
import android.view.View;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.RelativeLayout;

import com.jxd.archiveapp.adapters.MyFragmentViewAdapter;
import com.jxd.archiveapp.bean.LocationBean;
import com.jxd.archiveapp.fragments.BaseFragment;
import com.jxd.archiveapp.fragments.InventoryFragment;
import com.jxd.archiveapp.fragments.LocationFragment;
import com.jxd.archiveapp.fragments.SearchFragment;

import java.util.ArrayList;
import java.util.List;

import butterknife.Bind;
import butterknife.ButterKnife;

public class MainActivity extends BaseActivity
        implements SearchView.OnQueryTextListener{

    //SearchView searchView;
    //@Bind(R.id.drawer_layout)
    //DrawerLayout drawer;
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

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.app_bar_main);

        ButterKnife.bind(this);

        fragmentManager = this.getSupportFragmentManager();

        setSupportActionBar(toolbar);

//        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
//                this, null , toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
//        //drawer.setDrawerListener(toggle);
//        toggle.syncState();


        //navigationView.setNavigationItemSelectedListener(this);

        searchFragment = new SearchFragment();
        inventoryFragment =new InventoryFragment();
        locationFragment = new LocationFragment();

        fragmentList = new ArrayList<>();
        fragmentList.add(searchFragment);
        fragmentList.add(locationFragment);
        fragmentList.add(inventoryFragment);
        fragmentViewAdapter = new MyFragmentViewAdapter(fragmentList, fragmentManager);
        viewPager.setAdapter(fragmentViewAdapter);
        tab.setupWithViewPager(viewPager);
        //tab.setOnTabSelectedListener();
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);

        //Intent intent = getIntent();
        if (Intent.ACTION_SEARCH.equals(intent.getAction())) {
            String query = intent.getStringExtra(SearchManager.QUERY);
            //doMySearch(query);
        }
    }

    @Override
    public void onBackPressed() {

            super.onBackPressed();

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);

        MenuItem item= menu.findItem(R.id.action_search);
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

        if( id == R.id.action_search){
            //searchView.setMenuItem(item);
            //item.collapseActionView();
            //searchView = (SearchView)item.getActionView();
            //SearchManager searchManager = (SearchManager) getSystemService(Context.SEARCH_SERVICE);

            //searchView.setSearchableInfo(searchManager.getSearchableInfo(getComponentName()));


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

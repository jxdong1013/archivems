package com.jxd.archiveapp;


import android.app.SearchManager;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.view.MenuCompat;
import android.support.v4.view.MenuItemCompat;
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

import com.jxd.archiveapp.fragments.InventoryFragment;
import com.jxd.archiveapp.fragments.LocationFragment;
import com.jxd.archiveapp.fragments.SearchFragment;

import butterknife.Bind;
import butterknife.ButterKnife;

public class MainActivity extends BaseActivity
        implements NavigationView.OnNavigationItemSelectedListener,
        SearchView.OnQueryTextListener{

    //@Bind(R.id.search_view)
    SearchView searchView;
    @Bind(R.id.drawer_layout)
    DrawerLayout drawer;
    @Bind(R.id.toolbar)
    Toolbar toolbar;
    //@Bind(R.id.fab)
    //FloatingActionButton fab;
    @Bind(R.id.nav_view)
    NavigationView navigationView;
    @Bind(R.id.main)
    RelativeLayout rlmain;

    String[] searchKeys;

    InventoryFragment inventoryFragment;

    FragmentManager fragmentManager;
    SearchFragment searchFragment;
    LocationFragment locationFragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ButterKnife.bind(this);

        fragmentManager = this.getSupportFragmentManager();

        setSupportActionBar(toolbar);


//        fab.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View view) {
//                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
//                        .setAction("Action", null).show();
//            }
//        });


        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.setDrawerListener(toggle);
        toggle.syncState();


        navigationView.setNavigationItemSelectedListener(this);



    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);

        // When a user executes a search the system starts your searchable activity and sends it a ACTION_SEARCH intent

        //Intent intent = getIntent();
        if (Intent.ACTION_SEARCH.equals(intent.getAction())) {
            String query = intent.getStringExtra(SearchManager.QUERY);
            //doMySearch(query);
        }
    }

    @Override
    public void onBackPressed() {
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        }else {
            super.onBackPressed();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);

        MenuItem item= menu.findItem(R.id.action_search);
        searchView = (SearchView)MenuItemCompat.getActionView( item);
        searchView.setOnQueryTextListener(this);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }else if( id == R.id.action_search){
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



    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();

        if (id == R.id.menu_inventory) {
            // Handle the camera action
            goInventoryFragment();

        } else if (id == R.id.menu_location) {
            goLocationFragment();

        } else if (id == R.id.menu_search) {
            goSearchFragment();

        } else if (id == R.id.nav_manage) {

        } else if (id == R.id.nav_share) {

        } else if (id == R.id.nav_send) {

        }

        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }


    protected void goInventoryFragment() {
        FragmentTransaction transaction = fragmentManager.beginTransaction();

        if( inventoryFragment ==null ){
            inventoryFragment = InventoryFragment.newInstance("","");
        }

        transaction.replace( R.id.main , inventoryFragment );

        transaction.commit();
    }

    protected void goSearchFragment() {
        FragmentTransaction transaction = fragmentManager.beginTransaction();

        if( searchFragment ==null ){
            searchFragment = SearchFragment.newInstance("","");
        }

        transaction.replace( R.id.main , searchFragment );

        transaction.commit();
    }
    protected void goLocationFragment() {
        FragmentTransaction transaction = fragmentManager.beginTransaction();

        if( locationFragment ==null ){
            locationFragment = LocationFragment.newInstance("","");
        }

        transaction.replace( R.id.main , locationFragment );

        transaction.commit();
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

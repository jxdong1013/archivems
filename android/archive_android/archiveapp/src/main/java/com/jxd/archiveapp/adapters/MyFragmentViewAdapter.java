package com.jxd.archiveapp.adapters;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import com.jxd.archiveapp.fragments.BaseFragment;

import java.util.List;

/**
 * Created by Administrator on 2016/2/2.
 */
public class MyFragmentViewAdapter extends FragmentPagerAdapter {
    List<BaseFragment> fragments;

    public MyFragmentViewAdapter( List<BaseFragment> fragments , FragmentManager fm) {
        super(fm);
        this.fragments =fragments;
    }


    @Override
    public CharSequence getPageTitle(int position) {
        return fragments.get(position).getTitle();
        //return super.getPageTitle(position);
    }

    @Override
    public Fragment getItem(int position) {
        return fragments.get(position);
    }

    @Override
    public int getCount() {
        return fragments.size();
    }
}

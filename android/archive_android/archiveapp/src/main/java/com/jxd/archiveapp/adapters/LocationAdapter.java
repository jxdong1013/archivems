package com.jxd.archiveapp.adapters;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RelativeLayout;
import android.widget.TextView;

import com.jxd.archiveapp.MApplication;
import com.jxd.archiveapp.R;
import com.jxd.archiveapp.bean.LocationBean;

import org.w3c.dom.Text;

import java.util.List;

/**
 * Created by Administrator on 2016/2/1.
 */
public class LocationAdapter extends RecyclerView.Adapter<LocationAdapter.LocationViewHolder>{
    List<LocationBean> data;
    Context context;
    OnRCItemClickListener onRCItemClickListener;

    public LocationAdapter(List<LocationBean> data, Context context) {
        this.data = data;
        this.context=context;
    }
    public void setOnRCItemClickListener( OnRCItemClickListener listener){
        this.onRCItemClickListener = listener;
    }


    @Override
    public LocationViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.layout_location_item,null);
        LocationViewHolder viewHolder = new LocationViewHolder(view , onRCItemClickListener);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(LocationViewHolder holder, int position) {
        LocationBean bean = data.get(position);
        holder.tvBoxName.setText( bean.getBoxName() );
        holder.tvBoxRfid.setText(bean.getBoxRfid());
    }

    @Override
    public int getItemCount() {
        return data==null?0:data.size();
    }

    public class LocationViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener{
        TextView tvBoxName;
        TextView tvBoxRfid;
        TextView tvDelete;
        OnRCItemClickListener onRCItemClickListener;

        public LocationViewHolder(View itemView , OnRCItemClickListener listener) {
            super(itemView);

            onRCItemClickListener = listener;
            tvBoxName = (TextView)itemView.findViewById(R.id.location_item_name);
            tvBoxRfid = (TextView)itemView.findViewById(R.id.location_item_rfid);
            tvDelete = (TextView)itemView.findViewById(R.id.location_item_delete);
            tvDelete.setTypeface(MApplication.typeface);

            tvDelete.setOnClickListener(this);
        }

        @Override
        public void onClick(View v) {
            if( onRCItemClickListener!=null){
                onRCItemClickListener.OnRCItemClick(v, getAdapterPosition());
            }
        }
    }
}

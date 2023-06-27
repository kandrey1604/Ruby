package com.example.rubyapi;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class PropertyAdapter extends RecyclerView.Adapter <PropertyAdapter.PropertyViewHolder> {

    public ArrayList<Property> property;
    public Context context;

    public PropertyAdapter(ArrayList<Property> property,Context context) {
        this.property = property;
        this.context = context;
    }

    @NonNull
    @Override
    public PropertyViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater inflater = LayoutInflater.from(context);
        View view = inflater.inflate(R.layout.item_property, parent, false);
        return new PropertyViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull PropertyViewHolder holder, int position) {
        holder.bind(property.get(position));
    }

    @Override
    public int getItemCount() {
        return property.size();
    }

    class PropertyViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener    {
        private TextView textView;
        private ImageView imageView;

        //выводит данные на главную страницу каждого элемента
        public PropertyViewHolder(@NonNull View itemView) {
            super(itemView);
            itemView.setOnClickListener(this);
            textView = itemView.findViewById(R.id.name);
            imageView = itemView.findViewById(R.id.image);
        }

        //отображение элементов в каждой записи
        public void bind(Property property) {
            textView.setText(property.getProperty_Name());
            Picasso.get().load(property.getProperty_Image()).into(imageView);
        }

        //метод по смене активити
        @Override
        public void onClick(View view) {
            SwitchAct(((TextView)view.findViewById(R.id.name)).getText().toString());
        }

        //создаем новое активити на основе старого
        public void SwitchAct(String Name)
        {
            Property property1 = property.stream().filter(x -> x.getProperty_Name().equals(Name)).findFirst().orElse(null);
            Intent intent = new Intent(context, NewPropertyActivity.class);
            //intent.putExtra("name", property1.getProperty_Name());
            intent.putExtra("idProperty", property1.getId_Property());
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            context.startActivity(intent);
        }
    }
}

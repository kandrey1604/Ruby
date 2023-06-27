package com.example.rubyapi;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.squareup.picasso.Picasso;

import java.text.DecimalFormat;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class NewPropertyActivity extends AppCompatActivity {

    ApiInterface api;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_new_property);

        Intent okIntent = getIntent();
        api = RequestBuilder.buildRequest().create(ApiInterface.class);

        int id = okIntent.getIntExtra("idProperty",0 );
        ImageView imageView = findViewById(R.id._image);
        TextView name = findViewById(R.id._name);
        TextView location = findViewById(R.id._location);
        TextView square = findViewById(R.id._square);
        TextView price = findViewById(R.id._price);

        Call<Property> callGetPropertyByIdWithDetails = api.getPropertyByIdWithDetails(id);
        callGetPropertyByIdWithDetails.enqueue(new Callback<Property>() {
            @Override
            public void onResponse(Call<Property> call, Response<Property> response) {
                if (response.isSuccessful()) {
                    Property property = response.body();
                    if (property != null) {
                        name.setText(property.getProperty_Name());
                        location.setText(property.getProperty_Location());
                        square.setText(Integer.toString(property.getProperty_Square())+" м2 ");
                        DecimalFormat decimalFormat = new DecimalFormat("#");
                        price.setText(decimalFormat.format(property.getProperty_Price())+" $ ");
                        Picasso.get()
                                .load(property.getProperty_Image())
                                .into(imageView);
                    }
                } else {
                    Toast.makeText(NewPropertyActivity.this, "Error: " + response.code(), Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Property> call, Throwable t) {
                Toast.makeText(NewPropertyActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}
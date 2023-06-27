package com.example.rubyapi;

import android.os.Bundle;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    RecyclerView propertyRecycler;
    ApiInterface apiInterface;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        propertyRecycler = findViewById(R.id.list_property);
        apiInterface = RequestBuilder.buildRequest().create(ApiInterface.class);

        Call<ArrayList<Property>> getPropertyList = apiInterface.getPropertyList();

        getPropertyList.enqueue(new Callback<ArrayList<Property>>() {
            @Override
            public void onResponse(Call<ArrayList<Property>> call, Response<ArrayList<Property>> response) {
                if (response.isSuccessful()) {
                    propertyRecycler.setLayoutManager(new LinearLayoutManager(MainActivity.this));
                    propertyRecycler.setHasFixedSize(true);
                    PropertyAdapter adapter = new PropertyAdapter(response.body(), MainActivity.this);
                    propertyRecycler.setAdapter(adapter);
                }
                else {
                    Toast.makeText(MainActivity.this, "Ошибка со стороны клиента", Toast.LENGTH_LONG).show();
                }
            }

            @Override
            public void onFailure(Call<ArrayList<Property>> call, Throwable t) {
                Toast.makeText(MainActivity.this, t.getMessage(), Toast.LENGTH_LONG).show();
            }
        });
    }
}
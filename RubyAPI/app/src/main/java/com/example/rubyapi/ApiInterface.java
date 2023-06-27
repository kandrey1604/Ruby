package com.example.rubyapi;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;

public interface ApiInterface {
    @GET("properties")
    Call<ArrayList<Property>> getPropertyList();
    @GET("properties/{id}")
    Call<Property> getPropertyByIdWithDetails(@Path("id") int id);

}

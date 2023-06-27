package com.example.rubyapi;

import com.google.gson.annotations.SerializedName;

public class Property {

    @SerializedName("idProperty")
    private int id_Property;
    @SerializedName("nameProperty")
    private String property_Name;
    @SerializedName("image")
    private String property_Image;
    @SerializedName("location")
    private String property_Location;
    @SerializedName("square")
    private int property_Square;
    @SerializedName("bedroomCount")
    private int property_Bedroom_Count;
    @SerializedName("kitchenCount")
    private int property_Kitchen_Count;
    @SerializedName("bathroomCount")
    private int property_Bathroom_Count;
    @SerializedName("price")
    private float property_Price;
    @SerializedName("typePropertyId")
    private String property_Type;

    public Property(int id_Property, String property_Name, String property_Image, String property_Location, int property_Square, int property_Bedroom_Count, int property_Kitchen_Count, int property_Bathroom_Count, float property_Price, String property_Type) {
        this.id_Property = id_Property;
        this.property_Name = property_Name;
        this.property_Image = property_Image;
        this.property_Location = property_Location;
        this.property_Square = property_Square;
        this.property_Bedroom_Count = property_Bedroom_Count;
        this.property_Kitchen_Count = property_Kitchen_Count;
        this.property_Bathroom_Count = property_Bathroom_Count;
        this.property_Price = property_Price;
        this.property_Type = property_Type;
    }

    public int getId_Property() {
        return id_Property;
    }

    public void setId_Property(int id_Property) {
        this.id_Property = id_Property;
    }

    public String getProperty_Name() {
        return property_Name;
    }

    public void setProperty_Name(String property_Name) {
        this.property_Name = property_Name;
    }

    public String getProperty_Image() {
        return property_Image;
    }

    public void setProperty_Image(String property_Image) {
        this.property_Image = property_Image;
    }

    public String getProperty_Location() {
        return property_Location;
    }

    public void setProperty_Location(String property_Location) {
        this.property_Location = property_Location;
    }

    public int getProperty_Square() {
        return property_Square;
    }

    public void setProperty_Square(int property_Square) {
        this.property_Square = property_Square;
    }

    public int getProperty_Bedroom_Count() {
        return property_Bedroom_Count;
    }

    public void setProperty_Bedroom_Count(int property_Bedroom_Count) {
        this.property_Bedroom_Count = property_Bedroom_Count;
    }

    public int getProperty_Kitchen_Count() {
        return property_Kitchen_Count;
    }

    public void setProperty_Kitchen_Count(int property_Kitchen_Count) {
        this.property_Kitchen_Count = property_Kitchen_Count;
    }

    public int getProperty_Bathroom_Count() {
        return property_Bathroom_Count;
    }

    public void setProperty_Bathroom_Count(int property_Bathroom_Count) {
        this.property_Bathroom_Count = property_Bathroom_Count;
    }

    public float getProperty_Price() {
        return property_Price;
    }

    public void setProperty_Price(float property_Price) {
        this.property_Price = property_Price;
    }

    public String getProperty_Type() {
        return property_Type;
    }

    public void setProperty_Type(String property_Type) {
        this.property_Type = property_Type;
    }
}

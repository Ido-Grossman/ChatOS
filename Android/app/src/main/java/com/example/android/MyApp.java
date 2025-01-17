package com.example.android;

import android.app.Application;
import android.content.Context;
import android.content.Intent;

import com.example.android.Data.Contact;
import com.example.android.Data.Message;
import com.example.android.api.WebServiceAPI;
import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class MyApp extends Application {
    public static Context context;
    public static String url = "http://10.0.2.2:7225/api/";
    public static String token;
    public static Retrofit retrofit;
    public static WebServiceAPI webServiceAPI;
    public static List<Contact> contactList;
    public static String FirebaseToken;
    public static MessageNotify messageNotify;
    public static String userId;

    public static void configureRetrofit(){
        Gson gson = new GsonBuilder()
                .setLenient()
                .create();
        retrofit = new Retrofit.Builder()
                .baseUrl(url)
                .addConverterFactory(GsonConverterFactory.create(gson))
                .build();
        webServiceAPI = retrofit.create(WebServiceAPI.class);
    }

    public void onCreate() {
        super.onCreate();
        context = getApplicationContext();
    }

}


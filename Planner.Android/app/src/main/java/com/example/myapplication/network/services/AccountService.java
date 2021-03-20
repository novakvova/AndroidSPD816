package com.example.myapplication.network.services;


import com.example.myapplication.constants.Urls;
import com.example.myapplication.network.ApiAccount;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class AccountService {
    private static AccountService instance;
    private static final String BASE_URL = Urls.BASE;
    private Retrofit retrofit;

    public AccountService() {
        retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
    }

    public static AccountService getInstance() {
        if(instance==null)
            instance=new AccountService();
        return instance;
    }

    public ApiAccount getJSONApi()
    {
        return retrofit.create(ApiAccount.class);
    }
}

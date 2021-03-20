package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;

import com.android.volley.toolbox.NetworkImageView;
import com.example.myapplication.constants.Urls;
import com.example.myapplication.dto.LoginBadRequest;
import com.example.myapplication.dto.LoginDto;
import com.example.myapplication.dto.LoginResultDto;
import com.example.myapplication.network.ImageRequester;
import com.example.myapplication.network.services.AccountService;
import com.example.myapplication.utils.CommonUtils;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;
import com.google.gson.Gson;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LoginActivity extends AppCompatActivity {
    private ImageRequester imageRequester;
    private NetworkImageView myImage;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        String url = Urls.BASE+"/images/1.jpg";
                //"https://i.pinimg.com/564x/6f/de/85/6fde85b86c86526af5e99ce85f57432e.jpg";

        imageRequester = ImageRequester.getInstance();
        myImage = findViewById(R.id.myimg);
        imageRequester.setImageFromUrl(myImage, url);

    }

    public void OnClickBtn(View view) {
        final TextInputEditText email = findViewById(R.id.textInputEmail);
        final TextInputLayout emailLayout = findViewById(R.id.textFieldEmail);
        final TextInputEditText password = findViewById(R.id.textInputPassword);
        final TextInputLayout passwordLayout = findViewById(R.id.textFieldPassword);

        LoginDto dto = new LoginDto(email.getText().toString(),
                password.getText().toString());

//        if(dto.getEmail().isEmpty()) {
//            emailLayout.setError("Введіть пошту!");
//            return;
//        }
//        else
//            emailLayout.setError("");
//
//        if(dto.getPassword().isEmpty()) {
//            passwordLayout.setError("Введіть пароль!");
//            return;
//        }
//        else
//            passwordLayout.setError("");
        CommonUtils.showLoading(this);
        AccountService.getInstance()
                .getJSONApi()
                .login(dto)
                .enqueue(new Callback<LoginResultDto>() {
                    @Override
                    public void onResponse(Call<LoginResultDto> call, Response<LoginResultDto> response) {
                        CommonUtils.hideLoading();
                        if(response.isSuccessful()) {
                            Log.d("server", response.body().getToken());
                        }
                        else {
                            try {
                                String json = response.errorBody().string();
                                Gson gson = new Gson();
                                LoginBadRequest result = gson.fromJson(json, LoginBadRequest.class);
                                int t=3;
                                emailLayout.setError(result.getEmail());
                                passwordLayout.setError(result.getPassword());
                            } catch(Exception ex) {
                                email.setText(ex.getMessage());
                            }
                        }
                    }

                    @Override
                    public void onFailure(Call<LoginResultDto> call, Throwable t) {
                        CommonUtils.hideLoading();
                        Log.e("server", "Bad");
                    }
                });

        Log.d("Click my", email.getText().toString());
    }
}
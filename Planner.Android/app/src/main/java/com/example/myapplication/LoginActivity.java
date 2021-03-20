package com.example.myapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;

import com.android.volley.toolbox.NetworkImageView;
import com.example.myapplication.constants.Urls;
import com.example.myapplication.dto.LoginDto;
import com.example.myapplication.network.ImageRequester;
import com.google.android.material.textfield.TextInputEditText;
import com.google.android.material.textfield.TextInputLayout;

public class LoginActivity extends AppCompatActivity {
    private ImageRequester imageRequester;
    private NetworkImageView myImage;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        String url = Urls.BASE+"/images/3.jpg";
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

        if(dto.getEmail().isEmpty()) {
            emailLayout.setError("Введіть пошту!");
            return;
        }
        else
            emailLayout.setError("");

        if(dto.getPassword().isEmpty()) {
            passwordLayout.setError("Введіть пароль!");
            return;
        }
        else
            passwordLayout.setError("");

        Log.d("Click my", email.getText().toString());
    }
}
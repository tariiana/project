package com.example.requests_repair;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {
    EditText editTextText, editTextTextPassword;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        editTextText = findViewById(R.id.editTextText);
        editTextTextPassword = findViewById(R.id.editTextTextPassword);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
    }

    public void onClick_enter(View v){
        String login = editTextText.getText().toString().trim();
        String password = editTextTextPassword.getText().toString().trim();

        if ("ivan_1".equals(login) && "2222".equals(password)) {
            Intent intent = new Intent(MainActivity.this, MainActivity2.class);
            intent.putExtra("USER", "ADMIN");
            startActivity(intent);
        } else if ("diana".equals(login) && "12345".equals(password)) {
            Intent intent = new Intent(MainActivity.this, MainActivity2.class);
            intent.putExtra("USER", "USER");
            startActivity(intent);
        } else {
            Toast.makeText(MainActivity.this, "Ошибка: логин или пароль были введены неверно", Toast.LENGTH_SHORT).show();
        }
    }
}
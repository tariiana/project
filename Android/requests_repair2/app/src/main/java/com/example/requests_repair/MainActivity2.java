package com.example.requests_repair;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity2 extends AppCompatActivity {

    Button button6;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main2);
        button6 = findViewById(R.id.button6);
        Bundle arguments = getIntent().getExtras();
        String user = (String) arguments.get("USER");
        if ("ADMIN".equals(user)) button6.setVisibility(View.VISIBLE);
        else button6.setVisibility(View.INVISIBLE);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
    }

    public void onClick_Supplier(View v) {
        Intent intent = new Intent(MainActivity2.this, MainActivity3.class);
        intent.putExtra("TABLE", "Staff");
        startActivity(intent);
    }
    public void onClick_Request(View v) {
        Intent intent = new Intent(MainActivity2.this, MainActivity3.class);
        intent.putExtra("TABLE", "Request");
        startActivity(intent);
    }
    public void onClick_Report(View v) {
        Intent intent = new Intent(MainActivity2.this, MainActivity3.class);
        intent.putExtra("TABLE", "Report");
        startActivity(intent);
    }
    public void onClick_Clients(View v) {
        Intent intent = new Intent(MainActivity2.this, MainActivity3.class);
        intent.putExtra("TABLE", "Clients");
        startActivity(intent);
    }
    public void onClick_Users(View v) {
        Intent intent = new Intent(MainActivity2.this, MainActivity3.class);
        intent.putExtra("TABLE", "Users");
        startActivity(intent);
    }
    public void onClick_Back(View v) {
        Intent intent = new Intent(MainActivity2.this, MainActivity.class);
        startActivity(intent);
    }
}
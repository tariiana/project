package com.example.requests_repair;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.Button;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity3 extends AppCompatActivity {

    TextView textView3;
    EditText editTextText2;
    Button button9;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main3);
        textView3 = findViewById(R.id.textView3);
        editTextText2 = findViewById(R.id.editTextText2);
        button9 = findViewById(R.id.button9);
        Bundle arguments = getIntent().getExtras();
        String tables = (String) arguments.get("TABLE");
        switch (tables){
            case "Staff": textView3.setText("Таблица 'Сотрудники'"); break;
            case "Request": {
                textView3.setText("Таблица 'Заявки'");
                editTextText2.setVisibility(View.VISIBLE);
                button9.setVisibility(View.VISIBLE);
            } break;
            case "Report": textView3.setText("Таблица 'Отчеты'"); break;
            case "Clients": textView3.setText("Таблица 'Клиенты'"); break;
            case "Users": textView3.setText("Таблица 'Пользователи'"); break;
        }
        TableLayout tableLayout = findViewById(R.id.table);

        for(int i = 0; i < 3; i++) { // Три ряда
            TableRow row = new TableRow(this);

            for(int j = 0; j < 3; j++) { // Три колонки
                TextView cell = new TextView(this);
                cell.setGravity(Gravity.CENTER);

                row.addView(cell);
            }

            tableLayout.addView(row);
        }
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
    }

    public void onClick_Backback(View v) {
        Intent intent = new Intent(MainActivity3.this, MainActivity2.class);
        startActivity(intent);
    }
}
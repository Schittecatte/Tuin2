package com.example.hansnaert.lifecycle;

import android.os.PersistableBundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    String message="Not Set";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Log.v("Lifecycle","onCreate");

        if(savedInstanceState!=null)
            message=savedInstanceState.getString("message");

        Button buttonFinish=findViewById(R.id.buttonFinish);
        buttonFinish.setOnClickListener((View view)->finish());

        Button buttonSet=findViewById(R.id.buttonSet);
        buttonSet.setOnClickListener((View view)->
        {
            EditText editText=findViewById(R.id.editText);
            message=editText.getText().toString();
        });

        Button buttonGet=findViewById(R.id.buttonGet);
        buttonGet.setOnClickListener((View view)->
        {
            TextView textView=findViewById(R.id.textView);
            textView.setText(message);
        });
    }

    @Override
    protected void onStart() {
        super.onStart();
        Log.v("Lifecycle","onStart");
    }

    @Override
    protected void onResume() {
        super.onResume();
        Log.v("Lifecycle","onResume");
    }

    @Override
    protected void onPause() {
        super.onPause();
        Log.v("Lifecycle","onPause");
    }

    @Override
    protected void onStop() {
        super.onStop();
        Log.v("Lifecycle","onStop");
    }

    @Override
    protected void onDestroy() {
        super.onDestroy();
        Log.v("Lifecycle","onDestroy");
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        outState.putString("message", message);

        super.onSaveInstanceState(outState);
    }
}

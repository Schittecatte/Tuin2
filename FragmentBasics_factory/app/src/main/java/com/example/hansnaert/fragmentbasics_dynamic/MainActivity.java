package com.example.hansnaert.fragmentbasics_dynamic;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        BlankFragment newFragment = new BlankFragment();
        FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
        transaction.add(R.id.linearLayout,newFragment);

        transaction.commit();
    }

    public void onClick(View v)
    {
        BlankFragment_factory newFragment = BlankFragment_factory.newInstance("Hello from factory",""); //new SecondFragment();
        FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
        transaction.add(R.id.linearLayout,newFragment);

        transaction.addToBackStack(null);
        transaction.commit();

    }
}

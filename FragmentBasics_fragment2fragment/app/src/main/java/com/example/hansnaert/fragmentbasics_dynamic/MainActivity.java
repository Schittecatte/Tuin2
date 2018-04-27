package com.example.hansnaert.fragmentbasics_dynamic;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity implements BlankFragment_interface.OnFragmentInteractionListener {

    BlankFragment blankFragment;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        blankFragment = new BlankFragment();
        FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
        transaction.add(R.id.linearLayout,blankFragment);

        transaction.commit();
    }

    public void onClick(View v)
    {
        BlankFragment_interface newFragment = new BlankFragment_interface();
        FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
        transaction.add(R.id.linearLayout,newFragment);

        transaction.addToBackStack(null);
        transaction.commit();

    }

    public void SetBlankFragment(String s)
    {
        //Toast.makeText(getApplicationContext(),s, Toast.LENGTH_LONG).show();
        blankFragment.SetText(s);
    }
}

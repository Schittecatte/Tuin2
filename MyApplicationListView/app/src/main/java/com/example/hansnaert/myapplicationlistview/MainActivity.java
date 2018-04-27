package com.example.hansnaert.myapplicationlistview;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Arrays;

public class MainActivity extends AppCompatActivity {

    public class CustomType
    {
        int val;
        int val2;

        public CustomType(int i, int j)
        {
            val=i;
            val2=j;
        }

        public String toString()
        {
           return "number is :"+ Integer.toString(val);
        }
    }

    //ArrayList<String> arrayList = new ArrayList<String>(Arrays.asList("One", "Two", "Three"));
    ArrayList<CustomType> arrayList = new ArrayList<CustomType>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        arrayList.add(new CustomType(1,1));
        arrayList.add(new CustomType(2,4));
        arrayList.add(new CustomType(3,9));
        arrayList.add(new CustomType(4,16));

        ArrayAdapter<CustomType> itemsAdapter =
                new ArrayAdapter<CustomType>(this, android.R.layout.simple_list_item_1, arrayList);

        ListView listView=findViewById(R.id.listView);
        listView.setAdapter(itemsAdapter);
        listView.setOnItemClickListener((AdapterView<?> adapterView, View view, int i, long l) ->
        {
            CustomType customType=(CustomType) adapterView.getItemAtPosition(i);
            Toast.makeText(getApplicationContext(),customType.val + "  " + customType.val2,Toast.LENGTH_LONG).show();
        });
    }
}

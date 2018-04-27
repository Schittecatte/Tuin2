package com.embedonix.chronometer;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity {
    public static final String START_TIME = "START_TIME";
    public static final String CHRONO_WAS_RUNNING = "CHRONO_WAS_RUNNING";
    public static final String TV_TIMER_TEXT = "TV_TIMER_TEXT";
    public static final String ET_LAPST_TEXT = "ET_LAPST_TEXT";
    public static final String LAP_COUNTER  = "LAP_COUNTER";

    Button mBtnStart, mBtnLap, mBtnStop;
    TextView mTvTimer;
    EditText mEtLaps;
    ScrollView mSvLaps;

    int mLapCounter = 1;

    Chronometer mChrono;

    Thread mThreadChrono;

    Context mContext;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mContext = this;

        mBtnStart = (Button) findViewById(R.id.btn_start);
        mBtnLap = (Button) findViewById(R.id.btn_lap);
        mBtnStop = (Button) findViewById(R.id.btn_stop);

        mTvTimer = (TextView) findViewById(R.id.tv_timer);
        mEtLaps = (EditText) findViewById(R.id.et_laps);
        mEtLaps.setEnabled(false);

        mSvLaps = (ScrollView) findViewById(R.id.sv_lap);


        mBtnStart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(mChrono == null) {
                    mChrono = new Chronometer(mContext);
                    mThreadChrono = new Thread(mChrono);
                    mThreadChrono.start();

                    mChrono.start();

                    mEtLaps.setText("");

                    mLapCounter = 1;
                }
            }
        });

        mBtnStop.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(mChrono != null) {
                    mChrono.stop();
                    mThreadChrono.interrupt();
                    mThreadChrono = null;
                    mChrono = null;
                }
            }
        });

        mBtnLap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                if(mChrono == null) {
                    Toast.makeText(mContext
                            , R.string.warning_lap_button, Toast.LENGTH_SHORT).show();
                    return;
                }

                mEtLaps.append("LAP " + String.valueOf(mLapCounter++)
                        + "   " + mTvTimer.getText() + "\n");

                mSvLaps.post(new Runnable() {
                    @Override
                    public void run() {
                        mSvLaps.smoothScrollTo(0, mEtLaps.getBottom());
                    }
                });
            }
        });
    }

    public void updateTimerText(final String timeAsText) {
        runOnUiThread(new Runnable() {
            @Override
            public void run() {
                mTvTimer.setText(timeAsText);
            }
        });
    }

    @Override
    protected void onStart() {
        super.onStart();
        loadInstance();

        ((ChronometerApplication)getApplication()).stopBackgroundServices();
        ((ChronometerApplication)getApplication()).cancelNotification();
    }

    @Override
    protected void onPause() {
        super.onPause();
        saveInstance();

        if(mChrono != null && mChrono.isRunning()) {
            ((ChronometerApplication)getApplication())
                    .startBackgroundServices(mChrono.getStartTime());
        }
    }

    @Override
    protected void onDestroy() {

        saveInstance();

        if(mChrono == null || !mChrono.isRunning()) {
            ((ChronometerApplication) getApplication()).stopBackgroundServices();
            ((ChronometerApplication) getApplication()).cancelNotification();
        }

        super.onDestroy();
    }

    private void saveInstance() {
        SharedPreferences pref = getPreferences(MODE_PRIVATE);
        SharedPreferences.Editor editor = pref.edit();

        if(mChrono != null && mChrono.isRunning()) {
            editor.putBoolean(CHRONO_WAS_RUNNING, mChrono.isRunning());
            editor.putLong(START_TIME, mChrono.getStartTime());
            editor.putInt(LAP_COUNTER, mLapCounter);
        } else {
            editor.putBoolean(CHRONO_WAS_RUNNING, false);
            editor.putLong(START_TIME, 0);
            editor.putInt(LAP_COUNTER, 1);
        }

        editor.putString(ET_LAPST_TEXT, mEtLaps.getText().toString());

        editor.putString(TV_TIMER_TEXT, mTvTimer.getText().toString());

        editor.commit();
    }

    private void loadInstance() {

        SharedPreferences pref = getPreferences(MODE_PRIVATE);

        if(pref.getBoolean(CHRONO_WAS_RUNNING, false)) {
            long lastStartTime = pref.getLong(START_TIME, 0);
            if(lastStartTime != 0) {

                if(mChrono == null) {

                    if(mThreadChrono != null) {
                        mThreadChrono.interrupt();
                        mThreadChrono = null;
                    }

                    mChrono = new Chronometer(mContext, lastStartTime);
                    mThreadChrono = new Thread(mChrono);
                    mThreadChrono.start();
                    mChrono.start();
                }
            }
        }

        mLapCounter = pref.getInt(LAP_COUNTER, 1);

        String oldEtLapsText = pref.getString(ET_LAPST_TEXT, "");
        if(!oldEtLapsText.isEmpty()) {
            mEtLaps.setText(oldEtLapsText);
        }

        String oldTvTimerText = pref.getString(TV_TIMER_TEXT, "");
        if(!oldTvTimerText.isEmpty()){
            mTvTimer.setText(oldTvTimerText);
        }
    }
}

package com.embedonix.chronometer;
public class Helpers {
    public static String ConvertTimeToString(long timeInMillis) {

        int seconds = (int) (timeInMillis / 1000) % 60;
        int minutes = (int) ((timeInMillis / (60000)) % 60);
        int hours = (int) ((timeInMillis / (3600000)));

        return String.format("%02d:%02d:%02d"
                , hours, minutes, seconds);
    }
}


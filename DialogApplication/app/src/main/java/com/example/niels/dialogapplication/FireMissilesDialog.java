package com.example.niels.dialogapplication;

import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;

/**
 * Created by niels on 12/01/2018.
 */

public class FireMissilesDialog extends DialogFragment {

    @Overridepublic Dialog onCreateDialog(Bundle savedInstanceState) {
        // Use the Builder class for convenient dialog construction
           AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
           builder.setMessage("dialog_fire_missiles")
                   .setPositiveButton("fire", new DialogInterface.OnClickListener() {
                       public void onClick(DialogInterface dialog, int id) {
                           // FIRE ZE MISSILES!
                                          }
                   })            .setNegativeButton("cancel", new DialogInterface.OnClickListener() {
                       public void onClick(DialogInterface dialog, int id) {
                           // User cancelled the dialog
                                          }
                   });
           // Create the AlertDialog object and return it
           return builder.create();}
               }


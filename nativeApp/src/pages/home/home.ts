import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { DeviceMotion, DeviceMotionAccelerationData } from '@ionic-native/device-motion';
import { Tab1Page } from '../tab1/tab1';
import { Tab2Page } from '../tab2/tab2';
import { Tab3Page } from '../tab3/tab3';
import { Flashlight } from 'ionic-native';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  constructor(public navCtrl: NavController, public deviceMotion: DeviceMotion) {

  this.flashstatus = 'off';
  }
  tab1Page = Tab1Page;
  tab2Page = Tab2Page;
  tab3Page = Tab3Page;

  LightOn() {
    Flashlight.available((isAvailable) => {
      if(isAvailable)
      Flashlight.toggle();
      if(Flashlight.isSwitchedOn()){
        this.flashstatus = 'On';
      }
      else
      this.flashstatus = 'Off';
    })
  }

  
  getDeviceMotion(){
    this.deviceMotion.getCurrentAcceleration().then(
      (acceleration: DeviceMotionAccelerationData) => console.log(acceleration),
      (error: any) => console.log(error)    
    );
  }
}

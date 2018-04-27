import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { BatteryStatus, BatteryStatusResponse } from '@ionic-native/battery-status';


@Component({
  selector: 'page-about',
  templateUrl: 'about.html'
})
export class AboutPage {

constructor(public navCtrl: NavController, public battery: BatteryStatus) {

let subscription = this.battery.onChange().subscribe(
 (status: BatteryStatusResponse) => {
  var el: HTMLElement = document.getElementById('level');
el.innerText = status.level.toString() + '%';
 var le: HTMLElement = document.getElementById('plugged');
le.innerText = status.isPlugged.toString();
 }
);
  }

}

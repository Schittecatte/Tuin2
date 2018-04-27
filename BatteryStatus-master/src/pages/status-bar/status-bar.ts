import { Component, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BatteryStatus, BatteryStatusResponse } from '@ionic-native/battery-status';

@Component({
  selector: 'status-bar',
  templateUrl: 'status-bar.html'
})
export class StatusBarPage {

setFields(status) {
  var statusBar = document.getElementById("status");
  var isPlugged = document.getElementById("plugged");

  statusBar.innerHTML = status.level.toString() + '%';
  statusBar.style.width = status.level + '%';

  if(status.isPlugged === true) {
    isPlugged.innerHTML = "Charging...";
  } else {
    isPlugged.innerHTML = "Not Charging..."
  }
}

updateColor(status) {
  var statusBar = document.getElementById("status");
  if(status.level >= 70) {
    statusBar.className = "healthy";
  } else if(status.level < 70 && status.level >= 30) {
    statusBar.className = "danger";
  } else if(status.level < 30) {
    statusBar.className = "critical";
  }
}

  constructor(private batteryStatus: BatteryStatus) {
    let subscription = this.batteryStatus.onChange().subscribe(
     (status: BatteryStatusResponse) => {
       this.setFields(status);
       this.updateColor(status);
       console.log(status.level + "% and " + status.isPlugged);
     }
    );
  }
}

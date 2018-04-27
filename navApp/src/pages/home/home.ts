import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Tab1Page } from '../tab1/tab1';
import { Tab2Page } from '../tab2/tab2';
import { Tab3Page } from '../tab3/tab3';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  tab1Page = Tab1Page;
  tab2Page = Tab2Page;
  tab3Page = Tab3Page;

  constructor(public navCtrl: NavController) {

  }
  
}

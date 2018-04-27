import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { DeviceMotion } from '@ionic-native/device-motion';


import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { Tab1Page } from "../pages/tab1/tab1";
import { Tab2Page } from "../pages/tab2/tab2";
import { Tab3Page } from "../pages/tab3/tab3";
import { SecondPage } from "../pages/second/second";
import { FirstPage } from "../pages/first/first";

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    Tab1Page,
    Tab2Page,
    Tab3Page,
    FirstPage,
    SecondPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    Tab1Page,
    Tab2Page,
    Tab3Page,
    FirstPage,
    SecondPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
    ,DeviceMotion
  ]
})
export class AppModule {}

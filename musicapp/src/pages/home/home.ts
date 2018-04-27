import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import {FileChooser, MediaPlugin} from 'ionic-native';
 
@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  nativepath: string;
  file;
  
  constructor(public navCtrl: NavController) {
    
  }
  
  filechooser() {
    FileChooser.open()
  .then(uri => {
    (<any>window).FilePath.resolveNativePath(uri, (result) => {
      this.nativepath = result;
      this.audioplay();
    }, (err) => {
      alert(err);
    })
    
  }) 
  .catch(e => console.log(e));
  }
  
  audioplay() {
    var pathalone = this.nativepath.substring(8);
    this.file = new MediaPlugin(pathalone, (status) => {
      
    });
    
    this.file.play();
  }
  
}

import { Component } from '@angular/core';

import { AboutPage } from '../about/about';
import { ContactPage } from '../contact/contact';
import { StatusBarPage } from '../status-bar/status-bar';

@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {

  tab1Root = StatusBarPage;
  tab2Root = AboutPage;
  tab3Root = ContactPage;

  constructor() {

  }
}

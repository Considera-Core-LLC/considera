import { Component } from '@angular/core';
import {MatIconRegistry} from "@angular/material/icon";

@Component({
  selector: 'app-root',
  styleUrls: ['./app.component.scss'],
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'considera-dev';

  constructor(private _matIconRegistry: MatIconRegistry) {
    //_matIconRegistry.addSvgIcon("download2", "https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0");
  }
}

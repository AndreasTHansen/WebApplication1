import { Component, OnInit } from '@angular/core';
import { kunde } from "./kunde";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  public navn: string;
  public telefon: string;

  ngOnInit() {
    this.navn = "Ole Hansen";
    this.telefon = "92192122";
  }

  kunder: Array<kunde>
}

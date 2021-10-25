import { Component, OnInit } from '@angular/core';
import { kunde } from "./kunde";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  public Kunde: kunde;

  kunder: Array<kunde>


  ngOnInit() {
    this.Kunde.utData = "Ole Hansen, 92192122";
    this.kunder.push(this.Kunde)
  }


  slettKunde(enKunde: kunde): void {
    const indeks = this.kunder.indexOf(enKunde);
    this.kunder.splice(indeks, 1);
  }
}

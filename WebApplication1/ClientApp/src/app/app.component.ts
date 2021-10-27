import { Component, OnInit} from '@angular/core';
import { Kunde } from "./kunde";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public laster: string;
  public alleKunder: Array<Kunde>;

  constructor(private _http: HttpClient) {}



  hentAlleKunder() {
    this.laster = "Vennligst vent";
    this._http.get<Kunde[]>("api/kunde/")
      .subscribe(data => {
        this.alleKunder = data;
        this.laster = "";
      }, 
       error => console.log(error),
       () => console.log("ferdig get-api/kunde")
      );     
  };
}

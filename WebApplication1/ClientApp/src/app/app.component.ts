import { Component} from '@angular/core';
import { kunde } from "./kunde";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  public laster: string;
  public alleKunder: Array<kunde>

  constructor(private _http: HttpClient) {}



  hentAlleKunder() {
    this.laster = "Vennligst vent";
    this._http.get<Kunde[]>("api/Kunde/")
      .subscribe( data => {
        this.alleKunder = data;
        this.laster = "";
      },
        error => alert(error),
        () => console.log("ferdig get-/kunde")
      );
      
  }
}

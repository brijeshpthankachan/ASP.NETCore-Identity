import { CommonModule } from '@angular/common'
import { Component } from '@angular/core'
import { RouterOutlet } from '@angular/router'
import { HttpClientModule, HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,HttpClientModule],
  templateUrl: './app.component.html',
})
export class AppComponent {
    title = 'AngularClient';
    constructor(private readonly http:HttpClient) { }

    test() {
        //this.http.get('https://localhost:7187/api/account?provider=Google').subscribe(e => console.log(e));
        
    }
}

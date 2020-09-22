import { Component, OnInit } from '@angular/core';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private dataService: DataService) { 
  }

  ngOnInit() {
       
    this.dataService.loginEvent.subscribe((e => {
      console.log("It's work form Home");
    }))
    console.log( this.dataService.isLoggedIn)
  }

}

import { Component } from '@angular/core';
import { Event, Router, NavigationStart, NavigationEnd } from '@angular/router';
import { DataService } from './common/services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'IMSERPClient';
  showLoading: boolean = false;
  constructor(private router: Router, private dataService: DataService){
    if(localStorage.getItem('iMSToken') != undefined && localStorage.getItem('iMSToken') != null){
      this.dataService.onLoggedIn(true);
    }
    this.dataService.showProgressBarEvent.subscribe(e => {
      this.showLoading = e;
      console.log(e);
    })
    this.router.events.subscribe((event: Event)=>{
      if(event instanceof NavigationStart){
        this.dataService.onProgress(true);
      }
      if(event instanceof NavigationEnd){
        this.dataService.onProgress(false);
      }
    })
  }
}

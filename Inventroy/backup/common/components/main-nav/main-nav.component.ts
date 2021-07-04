import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { AppUserManagerService } from 'src/app/user/services/app-user-manager.service';
import { AppHost } from '../../models/app-host.model';
import { UserDetails } from 'src/app/user/models/user.model';
import { DataService } from '../../services/data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css']
})
export class MainNavComponent {

  appHost: AppHost = new AppHost();
  userDetails: UserDetails = new UserDetails();
  isLoggedIn: boolean = false;

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private appUserManagerService: AppUserManagerService,
    public dataService: DataService, private router: Router) {
  }
  ngOnInit() {
    if(localStorage.getItem('iMSToken') != undefined && localStorage.getItem('iMSToken') != null){
      this.getUserDetails();
    }
  }
  getUserDetails() {
    this.appUserManagerService.getDetails().subscribe((res: any) => {
      this.userDetails = res.obj;
    })
  }
  onLogout() {
    localStorage.removeItem('iMSToken');
    this.dataService.onLoggedIn(false);
    this.router.navigateByUrl("/user/login");
  }
}

import { Component } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  showMenu: Boolean //Biến kiểm tra trang html có xài template không và ngược lại

  logged: Boolean
  constructor(router:Router, private auth: AuthService) {
    router.events.forEach((event) => {
        if(event instanceof NavigationStart) {
            this.showMenu = event.url !== "/login";
            console.log("show menu " + this.showMenu);
        }
      });
      this.logged = this.auth.isLoggedIn;
      
      console.log("check " + this.logged);
    }
}

import { Component } from '@angular/core';
import { Router, NavigationStart } from '@angular/router';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  showLogin: Boolean //Biến kiểm tra trang html có xài template không và ngược lại
  showRegister: Boolean //Biến kiểm tra trang html có xài template không và ngược lại
  showFillInInformation: Boolean //Biến kiểm tra trang html có xài template không và ngược lại
  showTemplate: Boolean //Biến kiểm tra trang html có xài template không và ngược lại

  logged: Boolean
  constructor(router:Router, private auth: AuthService) {
    router.events.forEach((event) => {
        if(event instanceof NavigationStart) {
            // this.showTemplate = event.url !== "/";
            // this.showTemplate = event.url !== "search-hotel";
            // this.showTemplate = event.url !== "chose-hotel";
            this.showFillInInformation = event.url !== "/fill-in-information";
            this.showLogin = event.url !== "/login";
            this.showRegister = event.url !== "/register";
        }
      });
      this.logged = this.auth.isLoggedIn;
      console.log("check " + this.logged);
    }
}

import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  loggedIn: boolean;

  constructor(private auth: AuthService){
    //Kiểm tra đăng nhập
    this.hadLogin().then(data =>{
      this.loggedIn = data;
    })
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  async hadLogin() {
    var checkLogin: boolean;
    await this.auth.getUserDetails().toPromise().then(
      data => {
        if (data.success) {
          checkLogin = true;
        }
        else {
          checkLogin = false;
        }
    });
    console.log("check login in nav bar " + checkLogin);
    return checkLogin;
  }
}

import { AuthService } from '../auth.service';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  private defaultURL: String = "https://localhost:44359/api";

  isExpanded = false;
  loggedIn: boolean;
  username: String;
  fullname: String;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string,
  private auth: AuthService) {
    //Kiểm tra đăng nhập
    this.hadLogin().then(data => {
      this.loggedIn = data;
    })
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  logout(){
    //Không sử dụng biến defaultURL được
    this.http.post("https://localhost:44359/api/Common/remove-login-session", "no-value").subscribe(
      result =>{
        alert("Bạn đã đăng xuất");
        window.location.href = '/';
        console.log(result);
      },
      error =>{
        console.error("Can't logout in nav");
      }
    );
  }
  async hadLogin() {
    var checkLogin: boolean;
    //Lấy user name
    await this.auth.getUserDetails().toPromise().then(
      data => {
        if (data.success) {
          checkLogin = true;
          try {
            this.username = data.username;
            //Lấy họ tên người dùng
            this.http.get<any>(this.defaultURL + '/Customer' +
            '?customerId=' + this.username).subscribe(
              result => {
                var res: any = result;
                if (res.success) {
                  try{
                    this.fullname = res.data.lastName + " " + res.data.firstName;
                  }
                  catch{
                    console.error("Can't get fullname");
                  }
                  
                }
                else {
                  console.log("failed");
                }
              },
              error => {
                alert("Server error!!")
              });
          }
          catch{
            this.username = "";
            console.error("Can't get username");
          }
        }
        else {
          checkLogin = false;
        }
      });
    console.log("Get success username and fullname in navbar");
    return checkLogin;
  }
}

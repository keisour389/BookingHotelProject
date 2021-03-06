import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { CookieService } from 'ngx-cookie-service';
import { ActivatedRoute } from "@angular/router";


@Injectable({
  providedIn: 'root',
})

export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {
  login: boolean;
  username: String = null;
  constructor(private auth: AuthService, private router: Router, private cookieService: CookieService
    ,private route?: ActivatedRoute) {
      this.hadLogin().then(data => { //Kiểm tra đăng nhập trước khi vào
        console.log(data);
        //Nếu kết quả trả ra là false
        if(!data){
          this.login = false;
        }
        else{ 
          this.login = true; //Nếu là trạng thái true vì đã đăng nhập và trả kèm theo username
        }
      }); 
      console.log("logged " + this.login);
  }
  get getUserName(){
    console.log("username guard " + this.username);
    return this.username;
  }
  static username: String;
  static auth: AuthService;
  async hadLogin() {
    var checkLogin: boolean;
    await this.auth.getUserDetails().toPromise().then(
      data => {
        if (data.success) {
          checkLogin = true;
          this.username = data.username;
        }
        else {
          checkLogin = false;
        }
    });
    console.log("check login in auth guard " + checkLogin);
    return checkLogin;
  }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    //return true;
    //return this.auth.isLoggedIn; //Return false chặn không cho đăng nhập
    //Kiểm tra đăng nhập
    var result = this.hadLogin().then(data => {
      console.log(data);
      //Nếu kết quả trả ra là false
      if(!data){
        return this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});;
      }
      else{ 
        return true; //Nếu là trạng thái true vì đã đăng nhập
      }
    });
    //Trả ra giao diện tương ứng
    return result;
    
    // if (!this.test) { 
    //   return this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});;
    // }
    // else {
    //   return true; //Nếu là trạng thái true vì đã đăng nhập
    // }
    // if (!this.auth.isLoggedIn) { //Nếu trạng thái đăng nhập là false thì trả về trang đăng nhập
    //   //state.url là lấy trang đăng nhập, sau đó sẽ trả về 
    //   //return this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
    //   return false;
    // }
    // else {
    //   return this.auth.isLoggedIn; //Nếu là trạng thái true vì đã đăng nhập
    // }
  }
  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return true;
  }
}

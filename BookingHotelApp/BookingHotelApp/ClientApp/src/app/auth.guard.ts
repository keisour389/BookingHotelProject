import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';
import { CookieService } from 'ngx-cookie-service';
import { async, TestBed } from '@angular/core/testing';


@Injectable({
  providedIn: 'root',
})

export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {
  constructor(private auth: AuthService, private router: Router, private cookieService: CookieService) {
   
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
    console.log("check login in auth guard " + checkLogin);
    return checkLogin;
    // if(checkLogin){
    //   return checkLogin;
    // }
    // else{
    //   return this.router.navigate(['/login', {queryParams: {returnURL: this.router.url}}]);
    // }
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

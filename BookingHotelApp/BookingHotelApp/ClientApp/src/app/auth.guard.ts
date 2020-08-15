import { Injectable } from '@angular/core';
import { CanActivate, CanActivateChild, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {

  constructor(private auth: AuthService, private router: Router) { }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      //return true;
      //return this.auth.isLoggedIn; //Return false chặn không cho đăng nhập
      if(!this.auth.isLoggedIn){ //Nếu trạng thái đăng nhập là false thì trả về trang đăng nhập
        //state.url là lấy trang đăng nhập, sau đó sẽ trả về 
        //return this.router.navigate(['/login'], {queryParams: {returnUrl: state.url}});
        return false;
      }
      else{
        return this.auth.isLoggedIn; //Nếu là trạng thái true vì đã đăng nhập
      }
      
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

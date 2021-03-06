import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Title } from '@angular/platform-browser';
import { Router, ActivatedRoute } from "@angular/router";
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  //private defaultURL: String = "https://go2fun.azurewebsites.net/api";

  private defaultURL: String = "https://localhost:44359/api";

  private loggedInStatus: boolean = false;
  private paramStatus: boolean = false;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  setLoggedIn(value: boolean){
    this.loggedInStatus = value;
    console.log("set " + this.loggedInStatus);
  }

  get isLoggedIn(){
    console.log("get " + this.loggedInStatus);
    return this.loggedInStatus;
  }
  getUserDetails() {
    //Gọi API Post Login để lấy về thông tin user
    return this.http.get<any>(this.defaultURL + '/CusAccount/had-login');
  }
}

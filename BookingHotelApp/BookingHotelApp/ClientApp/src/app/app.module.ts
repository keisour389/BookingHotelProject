import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CanActivate, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomePageComponent } from './home-page/home-page.component';
import { SearchHotelComponent } from './search-hotel/search-hotel.component';
import { ChoseHotelComponent } from './chose-hotel/chose-hotel.component';
import { LoginComponent } from './login/login.component';
import {AuthGuard} from './auth.guard'
import { AuthService } from './auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HomePageComponent,
    SearchHotelComponent,
    ChoseHotelComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', component: HomeComponent, pathMatch: 'full' },
      // { path: 'counter', component: CounterComponent },
      // { path: 'fetch-data', component: FetchDataComponent },
      { path: '', component: HomePageComponent, pathMatch: 'full' },
      { path: 'search-hotel', component: SearchHotelComponent, canActivate: [AuthGuard]}, //Set Auth cho router tương ứng
      { path: 'chose-hotel', component: ChoseHotelComponent },
      { path: 'login', component: LoginComponent }
    ])
  ],
  providers: [AuthService, AuthGuard], //Khai báo auth ở đây để protection router
  bootstrap: [AppComponent]
})
export class AppModule { }

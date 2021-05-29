import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CanActivate, RouterModule } from '@angular/router';
import {AuthGuard} from './auth.guard'
import { AuthService } from './auth.service';
import {CookieService} from 'ngx-cookie-service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomePageComponent } from './home-page/home-page.component';
import { SearchHotelComponent } from './search-hotel/search-hotel.component';
import { ChoseHotelComponent } from './chose-hotel/chose-hotel.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FillInInformationComponent } from './fill-in-information/fill-in-information.component';
import { CheckBookingAgainComponent } from './check-booking-again/check-booking-again.component';
import { BookingProcessComponent } from './booking-process/booking-process.component';
import { BookingHistoryComponent } from './booking-history/booking-history.component';
import { ManagementComponent } from './admin/management/management.component';
import { EmpFunctionComponent } from './share/emp-function/emp-function.component';
import { AdminNavbarComponent } from './admin/admin-navbar/admin-navbar.component';
import { BookingComponent } from './admin/booking/booking.component';


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
    LoginComponent,
    RegisterComponent,
    FillInInformationComponent,
    CheckBookingAgainComponent,
    BookingProcessComponent,
    BookingHistoryComponent,
    ManagementComponent,
    EmpFunctionComponent,
    AdminNavbarComponent,
    BookingComponent
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
      { path: 'search-hotel', component: SearchHotelComponent},
      { path: 'chose-hotel', component: ChoseHotelComponent },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'fill-in-information', component: FillInInformationComponent, canActivate: [AuthGuard]}, //Set Auth cho router tương ứng
      { path: 'check-booking-again', component: CheckBookingAgainComponent },
      { path: 'booking-history', component: BookingHistoryComponent },
      { path: 'management', component: AppComponent, children: [
        {path: '', component: ManagementComponent, pathMatch: 'full'},
        {path: 'booking', component: BookingComponent}
      ] }
    ])
  ],
  providers: [AuthService, AuthGuard, CookieService], //Khai báo auth ở đây để protection router
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.css']
})
export class ManagementComponent implements OnInit {

  imgListData: Array<any> = ['/assets/ORDER_MANAGEMENT.png', '/assets/HOTEL_MANAGEMENT.png', '/assets/EMPLOYEE_MANAGEMENT.png'];
  tilteListData: Array<any> = ['Quản lí đơn đặt', 'Quản lí phòng', 'Quản lí nhân viên'];
  managedRouterLink = ['booking'];

  constructor() { }

  ngOnInit() {
  }

}

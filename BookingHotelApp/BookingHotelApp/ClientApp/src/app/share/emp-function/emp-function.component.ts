import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-emp-function',
  templateUrl: './emp-function.component.html',
  styleUrls: ['./emp-function.component.css']
})
export class EmpFunctionComponent implements OnInit {
  @Input() img: Array<any>;
  @Input() title: Array<any>;

  constructor() { }

  ngOnInit() {
  }

}

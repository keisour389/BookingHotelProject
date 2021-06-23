import { Component, OnInit } from '@angular/core';
import { RoomService } from 'src/app/service/room.service';

declare const $: any;

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {
  isGetOrUpdated!: boolean;
  dataResponse!: Array<any>;

  constructor(private roomService: RoomService) { }

  getRoomByHotelId(hotelId: string){
    this.roomService.getRoomByHotelId(hotelId).subscribe(
      result => {
        let res: any = result;
        if(res.success){
          this.dataResponse = res.data;
        }
        else{
          console.error('Response error.');
        }
      },
      error => {
        console.error('Server error.');
      }
    )
  }

  //option is type of modal to show
  //0: create the room
  //1: just see the room 
  //2: update the room
  openRoomInfoModal(option: number, index: number): void {
    $('#roomInfoModal').modal('show');
    if(option !== 0 ){
      this.isGetOrUpdated = true;
      console.log(this.dataResponse[0]);
    }
    else{
      this.isGetOrUpdated = false;
    } 
  }

  ngOnInit() {
    this.getRoomByHotelId('RHDL');
  }

}

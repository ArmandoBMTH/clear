import { Component, OnInit } from '@angular/core';
import { Actor, ActorDto } from 'src/app/models/actor';
import { ActorsService } from 'src/app/services/actors.service';

@Component({
  selector: 'app-actors',
  templateUrl: './actors.component.html',
  styleUrls: ['./actors.component.css']
})
export class ActorsComponent implements OnInit {

  actors: Actor[];
  popupVisible = false;

  currentActor: ActorDto = {
    date: '',
    name: ''
  }

  constructor(private actorSvc : ActorsService) {
    this.actors = [];
   }

  ngOnInit(): void {
    this.actorSvc.getAllActors().subscribe(data =>
      {
        this.actors = data;
      });
  }

  showFormActor(){
    this.popupVisible = true;
  }

  calculateCellValue(data: Actor) {
    return [data.name, data.date].join(' ');
  }

  deleteActor(actorId: number){

  }

  sendNewActor(){
    this.actorSvc.createNewActor(this.currentActor).subscribe(() => {
      this.popupVisible = false;
      this.actorSvc.getAllActors().subscribe(dataReload => {
        this.actors = dataReload;
      });
    });
  }
}

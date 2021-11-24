import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actor, ActorDto } from '../models/actor';

@Injectable({
  providedIn: 'root'
})
export class ActorsService {

  private urlBase: string;
  constructor(private http: HttpClient) {
    this.urlBase = 'http://localhost:5000/';
  }

  getAllActors(){
    return this.http.get<Actor[]>(`${this.urlBase}api/actors`);
  }

  getDetailsActor(id: number){
    return this.http.get<Actor>(`${this.urlBase}api/actors/${id}`);
  }

  createNewActor(movie: ActorDto){
    return this.http.post(`${this.urlBase}api/actors`,movie);
  }

  updateActor(movie: Actor){
    return this.http.put(`${this.urlBase}api/actors`,movie);
  }

  deleteActor(id: number){
    return this.http.delete(`${this.urlBase}api/actors/${id}`);
  }
}

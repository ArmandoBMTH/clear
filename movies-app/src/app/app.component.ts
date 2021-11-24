import { Component } from '@angular/core';
import DxPopup from 'devextreme/ui/popup';
import { MovieDto } from './models/movie';
import { MoviesService } from './services/movies.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'movies-app';
  constructor(private movieSvc: MoviesService){}
}

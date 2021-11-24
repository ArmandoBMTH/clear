import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MovieCard } from 'src/app/models/movie';
import { DxPopupModule } from 'devextreme-angular';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css'],
})
export class CardComponent implements OnInit {
  @Input() movie: MovieCard;
  @Output() detailsItemEvent = new EventEmitter<number>();

  constructor() {
    this.movie = {
      imageUrl: '',
      movieId: 0,
      title: '',
      date: '',
    };
  }

  ngOnInit(): void {

  }

  showDetailsCard(){
    this.detailsItemEvent.emit(this.movie.movieId);
  }
}

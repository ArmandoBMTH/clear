import { Component, OnInit } from '@angular/core';
import { MovieCard, MovieDetails, MovieDto } from 'src/app/models/movie';
import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit {

  currentMovie: MovieDto = {
    title: '',
    country: '',
    gender: '',
    imageUrl: '',
    date: ''
  };

  movieDetails: MovieDetails = {
    actors: [],
    country: '',
    date: '',
    gender: '',
    imageUrl: '',
    title: '',
    movieId: 0
  }

  movies : MovieCard[];
  popupVisible = false;
  popupDetailsVisible = false;

  countries: string[];
  genders: string[];

  constructor(private movieSvc: MoviesService) {
    this.movies = [];
    this.countries = [
      'EEUU',
      'MEXICO',
      'CANADA',
      'ENGLAND'
    ]
    this.genders = [
      'Action',
      'Adventure',
      'Science fiction',
      'Comedy',
      'Drama'
    ];
   }

  ngOnInit(): void {
    this.movieSvc.getAllMovies().subscribe(data => {
      this.movies = data;
    });
  }

  sendNewMovie(){
    console.log("hola mundo");
    this.movieSvc.createNewMovie(this.currentMovie).subscribe(data => {
      this.movieSvc.getAllMovies().subscribe(dataMovies =>{
        this.movies = dataMovies;
        this.popupVisible = false;
      });
    });
  }

  showFormMovie(){
    this.popupVisible = true;
  }

  searchFromText(searchText: string){
    if(searchText === ""){
      this.movieSvc.getAllMovies().subscribe(dataMovies =>{
        this.movies = dataMovies;
      });
    }
    else{
      this.movieSvc.getAllMoviesSearch(searchText).subscribe(dataMovies => {
        this.movies = dataMovies;
      });
    }
  }

  showDetailsMovie(movieId: number){
    this.movieSvc.getDetailsMovie(movieId).subscribe(data => {
      this.movieDetails = data;
      this.popupDetailsVisible = true;
    });
  }
}

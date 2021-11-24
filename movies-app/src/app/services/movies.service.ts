import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MovieCard } from '../models/movie';
import { MovieDetails } from '../models/movie';
import { MovieDto } from '../models/movie';
import { Movie } from '../models/movie';
import { ActoMovieRemoveDto, ActorMovieDto } from '../models/actor-movie-dto';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  private urlBase: string;
  constructor(private http : HttpClient) {
    this.urlBase = 'http://localhost:5000/';
  }


  getAllMovies(){
    return this.http.get<MovieCard[]>(`${this.urlBase}api/movies`)
  }

  getDetailsMovie(id: number){
    return this.http.get<MovieDetails>(`${this.urlBase}api/movies/${id}`);
  }

  getAllMoviesSearch(text: string){
    return this.http.get<MovieCard[]>(`${this.urlBase}api/movies?search=${text}`)
  }

  createNewMovie(movie: MovieDto){
    return this.http.post(`${this.urlBase}api/movies`,movie);
  }

  updateMovie(movie: Movie){
    return this.http.put(`${this.urlBase}api/movies`,movie);
  }

  deleteMovie(id: number){
    return this.http.delete(`${this.urlBase}api/movies/{id}`);
  }

  addActorToMovie(actorMovie: ActorMovieDto){
    return this.http.post(`${this.urlBase}api/movies/addactor`,actorMovie);
  }

  removeActorFromMovie(actorMovie: ActoMovieRemoveDto){
    return this.http.delete(`${this.urlBase}api/movies/addactor`, { body: actorMovie });
  }
}

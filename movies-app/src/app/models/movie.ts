export interface Movie {
  movieId: number,
  title: string,
  country: string,
  gender: string,
  imageUrl: string,
  date: string
}

export interface MovieCard extends Omit<Movie,'country'|'gender'>{

}

export interface MovieDetails extends Movie{
  actors: string[]
}

export interface MovieDto extends Omit<Movie,'movieId'>{

}

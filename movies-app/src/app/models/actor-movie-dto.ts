export interface ActorMovieDto {
  actorId: number,
  movieId: number
}

export interface ActoMovieRemoveDto extends Omit<ActorMovieDto, 'actorId'>{
  actorName:string
}

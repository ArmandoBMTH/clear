export interface Actor {
  actorId: number,
  name: string,
  date: string,
}

export interface ActorList extends Omit<Actor, 'date'>{

}

export interface ActorDto extends Omit<Actor, 'actorId'>{

}

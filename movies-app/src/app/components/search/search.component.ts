import { Component, OnInit,Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  @Output() newItemEvent = new EventEmitter<string>();

  textSearch : string;
  name: string = '';

  constructor() {
    this.textSearch = '';
  }

  ngOnInit(): void {
  }

  sendSearch(){
    this.newItemEvent.emit(this.textSearch);
  }
}

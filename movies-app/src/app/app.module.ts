import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CardComponent } from './components/card/card.component';
import { DevExtremeModule, DxPopupModule, DxSpeedDialActionModule } from 'devextreme-angular';
import { ActorsService } from './services/actors.service';
import { MoviesService } from './services/movies.service';
import { MoviesComponent } from './components/movies/movies.component';
import { ActorsComponent } from './components/actors/actors.component';
import { SearchComponent } from './components/search/search.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CardComponent,
    MoviesComponent,
    ActorsComponent,
    SearchComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    FlexLayoutModule,
    DxSpeedDialActionModule,
    DxPopupModule,
    DevExtremeModule
  ],
  providers: [
    ActorsService,
    MoviesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { GameBoardComponent } from './components/game-board/game-board.component';
import { GameSquareComponent } from './components/game-square/game-square.component';
import {HttpClientModule} from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { MainPageComponent } from './pages/main-page/main-page.component';
import { GamePageComponent } from './pages/game-page/game-page.component';
import {FormsModule} from "@angular/forms";
import { StartGamePageComponent } from './pages/start-game-page/start-game-page.component';

@NgModule({
  declarations: [
    AppComponent,
    GameBoardComponent,
    GameSquareComponent,
    MainPageComponent,
    GamePageComponent,
    StartGamePageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

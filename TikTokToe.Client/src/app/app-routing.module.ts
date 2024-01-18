import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainPageComponent} from "./pages/main-page/main-page.component";
import {GamePageComponent} from "./pages/game-page/game-page.component";
import {StartGamePageComponent} from "./pages/start-game-page/start-game-page.component";

const appRoutes: Routes = [
  { path: 'game/start', component: StartGamePageComponent },
  { path: 'game', component: GamePageComponent },
  { path: '**', component: MainPageComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}

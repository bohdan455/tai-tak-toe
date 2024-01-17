import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {GameService} from "../../services/game.service";

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  boardId: string = '';

  constructor(
    private router : Router,
    private gameService: GameService) { }

  ngOnInit(): void {
  }

  async startGame(){
    await this.gameService.joinGame(this.boardId);
    await this.router.navigate(['/game']);
  }

}

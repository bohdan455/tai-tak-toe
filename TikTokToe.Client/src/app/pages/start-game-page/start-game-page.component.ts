import { Component, OnInit } from '@angular/core';
import {GameService} from "../../services/game.service";

@Component({
  selector: 'app-start-game-page',
  templateUrl: './start-game-page.component.html',
  styleUrls: ['./start-game-page.component.css']
})
export class StartGamePageComponent implements OnInit {

  constructor(private gameService: GameService) { }

  boardId: string = '';

  ngOnInit(): void {
  }

  startGame(){
    this.gameService.startGame().then((boardId) => {
      this.boardId = boardId;
    });
  }

}

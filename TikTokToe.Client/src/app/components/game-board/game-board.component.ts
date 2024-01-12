import {Component, OnInit} from '@angular/core';
import {GameService} from "../../services/game.service";

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.css']
})
export class GameBoardComponent implements OnInit {
  public board: number[][]
  constructor(private gameService : GameService) { }

  ngOnInit(): void {
    this.board = this.gameService.Board;
  }

}
import {Component, OnInit} from '@angular/core';
import {GameService} from "../../services/game.service";
import {map} from "rxjs/operators";

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.css']
})
export class GameBoardComponent implements OnInit {
  public board: number[][] = []
  constructor(private gameService : GameService) { }

  async ngOnInit(): Promise<void> {
    await this.RefreshBoard();
  }

  public async RefreshBoard() {
    let board = await this.gameService.Board.toPromise();

    const boardSize = Math.sqrt(board.cells.length);

    this.board = Array.from({ length: boardSize }, () => Array(boardSize).fill(0));

    for (let cell of board.cells) {
      this.board[cell.row][cell.column] = cell.value;
    }
  }
}

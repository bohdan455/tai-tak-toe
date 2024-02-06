import {Component, EventEmitter, OnDestroy, OnInit, Output} from '@angular/core';
import {GameService} from "../../services/game.service";
import {map} from "rxjs/operators";
import {GameLiveService} from "../../services/gameLive.service";

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.css']
})
export class GameBoardComponent implements OnInit, OnDestroy {

  @Output() public currentPlayerMove: EventEmitter<string> = new EventEmitter<string>();

  public board: number[][] = []
  constructor(
    private gameService : GameService,
    private gameLiveService : GameLiveService
  ) { }

  async ngOnInit(): Promise<void> {
    await this.refreshBoard();
    await this.gameLiveService.addToGroup(this.gameService.BoardId);
    await this.gameLiveService.startReceivingUpdates(this.refreshLocalBoard.bind(this));
  }

  ngOnDestroy(): void {
    this.gameLiveService.stopConnection();
  }

  public async refreshBoard() {
    await this.refreshLocalBoard();
    await this.gameLiveService.refreshBoard(this.gameService.BoardId);
  }

  private async refreshLocalBoard() {
    let board = await this.gameService.Board.toPromise();

    const boardSize = Math.sqrt(board.cells.length);

    this.board = Array.from({ length: boardSize }, () => Array(boardSize).fill(0));

    for (let cell of board.cells) {
      this.board[cell.row][cell.column] = cell.value;
    }

    this.currentPlayerMove.emit(board.nextPlayerMove);
  }
}

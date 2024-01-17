import {Injectable} from "@angular/core";
import {BaseService} from "./base.service";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Configuration} from "../../environments/configuration";
import {Board} from "../models/board.model";
import {StorageService} from "./storage.service";

@Injectable({
  providedIn: 'root'
})
export class GameService extends BaseService {
  private readonly boardSize: number = 3;
  private readonly emptyCell: number = 0;
  private readonly redPlayer: number = 1;
  private readonly bluePlayer: number = 2

  private currentPlayer: number = this.redPlayer;

  private board: number[][] = [];

  constructor(
    protected httpClient: HttpClient,
    protected storageService: StorageService) {
    super(httpClient);
    this.initBoard();
  }

  get Board() : Observable<Board>{
    let boardId = this.storageService.getInline("board");
    return this.get<Board>(`${Configuration.getBoard}?boardId=${boardId}`);
  }

  makeMove(x: number, y: number) : Observable<void> {
    console.log(`Making move x: ${x} y: ${y}`);
    let boardId = this.storageService.getInline("board");
    let playerId = this.storageService.getInline("player");
    let body = {
      boardId: boardId,
      playerId: playerId,
      x: x,
      y: y
    };
    return this.put(`${Configuration.makeMove}`, body);
  }

  async joinGame(boardId: string) : Promise<void> {
    let body = {
      boardId: boardId
    }
    let result = await this.post<{boardId: string}, { playerId:string }>(Configuration.joinGame, body).toPromise();
    this.storageService.set("player", result.playerId);
    this.storageService.set("board", boardId);
  }

  checkWin(player: number): boolean {
    return this.checkRowWin(player) || this.checkColumnWin(player) || this.checkDiagonalWin(player) || this.checkAntiDiagonalWin(player)
  }

  private checkRowWin(player: number): boolean {
    for (let i = 0; i < this.boardSize; i++) {
      let row = this.board[i];
      console.log(`Row ${row}`);
      if (row.every(cell => cell === player)) {
        return true;
      }
    }

    return false;
  }

  private checkColumnWin(player: number): boolean {
    for (let i = 0; i < this.boardSize; i++) {
      let column = this.board.map(row => row[i]);
      console.log(`Column ${column}`);
      if (column.every(cell => cell === player)) {
        return true;
      }
    }

    return false;
  }

  private checkDiagonalWin(player: number): boolean {
    let diagonal: number[] = []
    for(let i = 0; i < this.boardSize; i++){
      diagonal.push(this.board[i][i]);
    }
    console.log(`Diagonal ${diagonal}`);
    return diagonal.every(cell => cell === player);
  }

  private checkAntiDiagonalWin(player: Number): boolean {
    let antiDiagonal: number[] = []
    for(let i = 0; i < this.boardSize; i++){
      antiDiagonal.push(this.board[i][this.boardSize - i - 1]);
    }

    console.log(`AntiDiagonal ${antiDiagonal}`);
    return antiDiagonal.every(cell => cell === player);
  }

  private initBoard() {
    console.log("Board initialized");
    for (let i = 0; i < this.boardSize; i++) {
      let row: number[] = [];
      for (let j = 0; j < this.boardSize; j++) {
        row.push(this.emptyCell);
      }
      this.board.push([...row]);  // Create a new array for each row
    }
  }
}

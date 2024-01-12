import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private readonly boardSize: number = 3;
  private readonly emptyCell: number = 0;
  private readonly redPlayer: number = 1;
  private readonly bluePlayer: number = 2

  private currentPlayer: number = this.redPlayer;

  private board: number[][] = [];

  constructor() {
    this.initBoard();
  }

  makeMove(x: number, y: number) : number {
    console.log(`move: ${x} ${y}`);
    let player = this.currentPlayer;
    this.board = this.board.map((rowArray, rowIndex) =>
      rowIndex === x ? [...rowArray.slice(0, y), player, ...rowArray.slice(y + 1)] : rowArray
    );

    this.currentPlayer = player === this.redPlayer ? this.bluePlayer : this.redPlayer;
    return player;
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

  get Board(): number[][] {
    return this.board;
  }
}

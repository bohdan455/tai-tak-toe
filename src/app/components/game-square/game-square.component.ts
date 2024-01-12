import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {GameService} from "../../services/game.service";

@Component({
  selector: 'app-game-square',
  templateUrl: './game-square.component.html',
  styleUrls: ['./game-square.component.css']
})
export class GameSquareComponent implements OnInit {


  @Input() public cellFiller: number;
  @Input() public x: number;
  @Input() public y: number;
  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    console.log(`cellFiller: ${this.cellFiller} x: ${this.x} y: ${this.y}`)
  }

  public FillCell() {
    if(this.cellFiller === 0){
      this.cellFiller = this.gameService.makeMove(this.x, this.y)
    }
    if(this.gameService.checkWin(this.cellFiller)){
      alert(`Player ${this.cellFiller == 1 ? "red" : "blue"} won!`)
    }
  }

}

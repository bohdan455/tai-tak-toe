import {Component, Input, OnInit} from '@angular/core';
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

  public async FillCell() {
    if(this.cellFiller === 0){
      await this.gameService.makeMove(this.x, this.y).toPromise();
    }
  }

}

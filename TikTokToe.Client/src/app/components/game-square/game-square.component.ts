import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {GameService} from "../../services/game.service";
import {Task} from "@angular/compiler-cli/ngcc/src/execution/tasks/api";

@Component({
  selector: 'app-game-square',
  templateUrl: './game-square.component.html',
  styleUrls: ['./game-square.component.css']
})
export class GameSquareComponent implements OnInit {


  @Input() public cellFiller: number;
  @Input() public x: number;
  @Input() public y: number;

  @Output() public refreshBoard: EventEmitter<Task> = new EventEmitter<Task>()
  constructor(private gameService: GameService) { }

  ngOnInit(): void {
    console.log(`cellFiller: ${this.cellFiller} x: ${this.x} y: ${this.y}`)
  }

  public async FillCell() {
    if(this.cellFiller === 0){
      await this.gameService.makeMove(this.x, this.y).toPromise();
    }

    await this.refreshBoard.emit();
  }

}

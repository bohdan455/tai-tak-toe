import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.css']
})
export class GamePageComponent implements OnInit {



  public currentPlayer: string = "Waiting for player to join...:";

  constructor() { }

  ngOnInit(): void {
  }

  setCurrentPlayer(player: string) {
    this.currentPlayer = player;
  }

}

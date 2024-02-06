import * as signalR from '@microsoft/signalr';
import {Configuration} from "../../environments/configuration";
import {Injectable} from "@angular/core";

type refreshBoard = () => void;

@Injectable({
  providedIn: 'root'
})
export class GameLiveService{
  private hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl(Configuration.baseUrl + Configuration.liveGame)
    .build();

  public startReceivingUpdates = async (func: refreshBoard) => {
    await this.startConnectionIfNotStarted();
    this.hubConnection.on('RefreshBoard', func);
  }

  public stopConnection = () => {
    this.hubConnection
      .stop()
      .then(() => console.log('Connection stopped'))
      .catch(err => console.log('Error while stopping connection: ' + err))
  }

  public addToGroup = async (boardId: string) => {
    await this.startConnectionIfNotStarted();
    this.hubConnection
      .invoke('AddPlayer', boardId)
      .catch(err => console.error(err));
  }

  public refreshBoard = async (boardId : string) => {
    await this.startConnectionIfNotStarted();
    this.hubConnection
      .invoke('RefreshBoard', boardId)
      .catch(err => console.error(err));
  }

  private startConnectionIfNotStarted = async () => {
    if (this.hubConnection.state === signalR.HubConnectionState.Disconnected) {
      await this.hubConnection.start();
      console.log('Connection started')
    }
  }
}

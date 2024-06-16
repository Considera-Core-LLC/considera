import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {HttpGamesService} from "../../http/http-games/http-games.service";
import {IdleResearch} from "../../../models/app/games/idle-research.model";

@Injectable({
  providedIn: 'root'
})
export class GamesService {
  private readonly GET_ACTION = '';

  constructor(private httpService: HttpGamesService) {}

  public get(): Observable<IdleResearch[]> {
    return this.httpService.get(this.GET_ACTION, new HttpParams()) as Observable<IdleResearch[]>;
  }
}

import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {HttpGamesService} from "../../http/http-games/http-games.service";
import {IdleResearch} from "../../../models/app/games/idle-research.model";
import {HttpMusiqueUserService} from "../../http/http-musique/http-musique-user/http-musique-user.service";
import {User} from "../../../models/app/musique/user.model";

@Injectable({
  providedIn: 'root'
})
export class MusiqueService {
  private readonly GET_ACTION = '';
  private readonly GET_USERS_ACTION = 'getUsers';
  private readonly GET_USER_ACTION = 'getUser';
  private readonly LOGIN_ACTION = 'login';

  constructor(private httpMusiqueService: HttpMusiqueUserService) {}

  public getUsers(): Observable<User[]> {
    return this.httpMusiqueService.get(this.GET_USERS_ACTION, new HttpParams()) as Observable<User[]>;
  }

  public login(username: string, password: string): Observable<boolean> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);
    return this.httpMusiqueService.get(this.LOGIN_ACTION, params) as Observable<boolean>;
  }
}

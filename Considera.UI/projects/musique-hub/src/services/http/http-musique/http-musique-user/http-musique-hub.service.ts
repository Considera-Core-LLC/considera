import {Injectable} from "@angular/core";
import {HttpMusiqueService} from "../http-musique.service";
import {HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "../../../../models/app/musique/user.model";

@Injectable({
  providedIn: 'root'
})
export class HttpMusiqueHubService {
  private readonly BASE_URL = 'music/';

  constructor(private httpService: HttpMusiqueService) {}

  public get(endpoint: string, params?: HttpParams): Observable<unknown> {
    return this.httpService.get(this.BASE_URL + endpoint, params) as Observable<unknown>;
  }

  public post(endpoint: string, body: any, params?: HttpParams): Observable<unknown> {
    return this.httpService.post(this.BASE_URL + endpoint, body, params) as Observable<unknown>;
  }
}

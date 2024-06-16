import {Injectable} from "@angular/core";
import {HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {HttpService} from "../http.service";

@Injectable({
  providedIn: 'root'
})
export class HttpGamesService {
  private readonly BASE_URL = 'idleResearch/';

  constructor(private httpService: HttpService) {}

  public get(endpoint: string, params?: HttpParams): Observable<unknown> {
    return this.httpService.get(this.BASE_URL + endpoint, params);
  }
}

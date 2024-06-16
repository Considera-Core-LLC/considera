import {Injectable} from "@angular/core";
import {HttpMusiqueService} from "../http-musique.service";
import {HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "../../../../models/app/musique/user.model";

@Injectable({
  providedIn: 'root'
})
export class HttpMusiqueUserService {
  private readonly BASE_URL = 'user/';

  constructor(private httpService: HttpMusiqueService) {}

  public get(endpoint: string, params?: HttpParams): Observable<unknown> {
    return this.httpService.get(this.BASE_URL + endpoint, params) as Observable<unknown>;
  }
}

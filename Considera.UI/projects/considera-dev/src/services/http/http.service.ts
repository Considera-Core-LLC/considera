import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  private readonly BASE_URL = 'http://localhost:5206/api/';

  constructor(private httpClient: HttpClient) {}

  public get(endpoint: string, params?: HttpParams): Observable<unknown> {
    if (!params) params = new HttpParams();
    return this.httpClient.get(this.BASE_URL + endpoint, {params});
  }
}

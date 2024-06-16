import {Injectable} from "@angular/core";
import {HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {HttpMusiqueUserService} from "../../http/http-musique/http-musique-user/http-musique-user.service";
import {User} from "../../../models/app/musique/user.model";
import {HttpMusiqueHubService} from "../../http/http-musique/http-musique-user/http-musique-hub.service";
import {Artist} from "../../../models/app/musique/artist.model";
import {Genre} from "../../../models/app/musique/genre.model";
import {MusiqueCache} from "./musique.cache";
import {Album} from "../../../models/app/musique/album.model";
import {ArtistAlbum} from "../../../models/app/musique/artist-album.model";
import {GenreAlbum} from "../../../models/app/musique/genre-album.model";

@Injectable({
  providedIn: 'root'
})
export class MusiqueArtistsService {
  private readonly GetArtists = 'getartists';
  private readonly AddArtist = 'addartist';

  constructor(private _httpMusiqueHubService: HttpMusiqueHubService) {}

  public getArtists(): Observable<Artist[]> {
    const request = this._httpMusiqueHubService
      .get(this.GetArtists, new HttpParams()) as Observable<Artist[]>;
    request.subscribe(MusiqueCache.SetArtists);
    return request;
  }

  public addArtist(artist: Artist): Observable<any> {
    return this._httpMusiqueHubService.post(this.AddArtist, artist) as Observable<any>;
  }
}

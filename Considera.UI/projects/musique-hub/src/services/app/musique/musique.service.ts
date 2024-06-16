import {Injectable} from "@angular/core";
import {HttpParams} from "@angular/common/http";
import {forkJoin, map, Observable, switchMap} from "rxjs";
import {HttpMusiqueUserService} from "../../http/http-musique/http-musique-user/http-musique-user.service";
import {User} from "../../../models/app/musique/user.model";
import {HttpMusiqueHubService} from "../../http/http-musique/http-musique-user/http-musique-hub.service";
import {MusiqueCache} from "./musique.cache";
import {ArtistAlbum} from "../../../models/app/musique/artist-album.model";
import {GenreAlbum} from "../../../models/app/musique/genre-album.model";
import {Album} from "../../../models/app/musique/album.model";
import {MusiqueAlbumsService} from "./musique-albums.service";
import {MusiqueGenresService} from "./musique-genres.service";
import {Genre} from "../../../models/app/musique/genre.model";

@Injectable({
  providedIn: 'root'
})
export class MusiqueService {
  private readonly GET_USERS_ACTION = 'getUsers';
  private readonly GET_GENRE_ALBUMS_ACTION = 'getGenreAlbums';
  private readonly GetGenreAlbumsFromGenres = 'getgenrealbumsfromgenres';
  private readonly GET_ARTIST_ALBUMS_ACTION = 'getArtistAlbums';
  private readonly LOGIN_ACTION = 'login';
  private readonly REGISTER_ACTION = 'register';

  constructor(private _httpMusiqueUserService: HttpMusiqueUserService,
              private _httpMusiqueHubService: HttpMusiqueHubService,
              private _musicAlbumsService: MusiqueAlbumsService,
              private _musicGenresService: MusiqueGenresService) {}

  public getGenresWithAlbums(): Observable<Genre[]> {
    return this._musicGenresService.getAllGenresWithAlbums();
  }

  // Users
  public getUsers(): Observable<User[]> {
    return this._httpMusiqueUserService
      .get(this.GET_USERS_ACTION, new HttpParams()) as Observable<User[]>;
  }

  public login(username: string, password: string): Observable<User> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);
    return this._httpMusiqueUserService.get(this.LOGIN_ACTION, params) as Observable<User>;
  }

  public register(username: string, password: string): Observable<User> {
    const params = new HttpParams()
      .set('username', username)
      .set('password', password);
    return this._httpMusiqueUserService.get(this.REGISTER_ACTION, params) as Observable<User>;
  }

  // Mappers
  public getGenreAlbums(): Observable<GenreAlbum[]> {
    const request = this._httpMusiqueHubService
      .get(this.GET_GENRE_ALBUMS_ACTION, new HttpParams()) as Observable<GenreAlbum[]>;
    request.subscribe(MusiqueCache.SetGenreAlbums);
    return request;
  }

  public getGenreAlbumsFromGenres(genreIds: string[]): Observable<GenreAlbum[]> {
    const request = this._httpMusiqueHubService
      .get(this.GetGenreAlbumsFromGenres, new HttpParams()
        .append('genreIds', genreIds.join(','))) as Observable<GenreAlbum[]>;
    request.subscribe(MusiqueCache.SetGenreAlbums);
    return request;
  }

  public getArtistAlbums(): Observable<ArtistAlbum[]> {
    const request = this._httpMusiqueHubService
      .get(this.GET_ARTIST_ALBUMS_ACTION, new HttpParams()) as Observable<ArtistAlbum[]>;
    request.subscribe(MusiqueCache.SetArtistAlbums);
    return request;
  }
}

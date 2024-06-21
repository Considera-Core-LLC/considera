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
export class MusiqueAlbumsService {
  private readonly GetAllAlbums = 'getallalbums';
  private readonly GetAlbumsByIds = 'getalbumsbyids';
  private readonly GetAlbumsByGenreId = 'getalbumsbygenreid';
  private readonly GetAlbumsByGenreIds = 'getalbumsbygenreids';
  private readonly GetAlbumsFromGenreAlbums = 'getalbumsfromgenrealbums';
  private readonly AddAlbum = 'addalbum';

  constructor(private _httpMusiqueUserService: HttpMusiqueUserService,
              private _httpMusiqueHubService: HttpMusiqueHubService) {}

  // Albums
  public getAlbums(): Observable<Album[]> {
    const request = this._httpMusiqueHubService
      .get(this.GetAllAlbums, new HttpParams()) as Observable<Album[]>;
    request.subscribe(MusiqueCache.SetAlbums);
    return request;
  }

  public addAlbum(album: Album): Observable<any> {
    return this._httpMusiqueHubService
      .post(this.AddAlbum, album) as Observable<any>;
  }

  public getAlbumsByIds(albumIds: string[]): Observable<Album[]> {
    return this._httpMusiqueHubService
      .get(this.GetAlbumsByIds, new HttpParams()
        .append('albumIds', albumIds.join(','))) as Observable<Album[]>;
  }

  public getAlbumsByGenreId(genreId: string): Observable<Album[]> {
    return this._httpMusiqueHubService
      .get(this.GetAlbumsByGenreId, new HttpParams()
        .append('genreId', genreId)) as Observable<Album[]>;
  }

  public getAlbumsByGenreIds(genreIds: string[]): Observable<Album[]> {
      return this._httpMusiqueHubService
        .get(this.GetAlbumsByGenreIds, new HttpParams()
          .append('genreIds', genreIds.join(','))) as Observable<Album[]>;
  }

  public getAlbumsFromGenreAlbums(genreAlbumIds: string[]): Observable<Album[]> {
    const request = this._httpMusiqueHubService
      .get(this.GetAlbumsFromGenreAlbums, new HttpParams()
        .append('genreAlbumIds', genreAlbumIds.join(','))) as Observable<Album[]>;
    request.subscribe(MusiqueCache.SetAlbums);
    return request;
  }
}

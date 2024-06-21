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
export class MusiqueGenresService {
  private readonly GetGenre = 'getgenre';
  private readonly GetGenres = 'getgenres';
  private readonly GetAllGenres = 'getallgenres';
  private readonly GetAllGenresWithAlbums = 'getallgenreswithalbums';
  private readonly AddGenres = 'addgenres';
  private readonly ModifyGenre = 'modifygenre';
  private readonly AssignSubgenres = 'assignsubgenres'; // modify genre instead?

  constructor(private _httpMusiqueUserService: HttpMusiqueUserService,
              private _httpMusiqueHubService: HttpMusiqueHubService) {}

  // Genres
  public getGenre(genreId: string): Observable<Genre> {
    const genreRequest = (this._httpMusiqueHubService
      .get(this.GetGenre, new HttpParams()
        .append('genreId', genreId)) as Observable<Genre>);
    genreRequest.subscribe(MusiqueCache.AddGenre);
    return genreRequest;
  }

  public getGenres(genreIds: string[]): Observable<Genre[]> {
    const request = this._httpMusiqueHubService
      .get(this.GetAllGenres, new HttpParams()
        .append('genreIds', genreIds.join(','))) as Observable<Genre[]>;
    request.subscribe(MusiqueCache.SetGenres);
    return request;
  }

  public getAllGenres(
    withAlbums: boolean = false,
    withArtists: boolean = false): Observable<Genre[]> {
    const request = this._httpMusiqueHubService
      .get(this.GetAllGenres, new HttpParams()
        .append('withAlbums', withAlbums)
        .append('withArtists', withArtists)) as Observable<Genre[]>;
    request.subscribe(MusiqueCache.SetGenres);
    return request;
  }

  public addGenres(genres: Genre[]): Observable<Genre[]> {
    const genreNames: string = genres.map((genre: Genre) => genre.name).join(',');
    return this._httpMusiqueHubService.get(this.AddGenres, new HttpParams()
      .append('genres', genreNames)
    ) as Observable<Genre[]>;
  }

  public assignSubgenres(author: User, genre: Genre[], subgenres: Genre[]): Observable<Genre[]> {
    const genreNames: string = genre
      .map(x => x.name)
      .join(',');
    const subgenreNames: string = subgenres
      .map(x => x.name)
      .join(',');
    return this._httpMusiqueHubService
      .get(this.AssignSubgenres, new HttpParams()
        .append('authorId', author.id)
        .append('genres', genreNames)
        .append('subgenres', subgenreNames)
      ) as Observable<Genre[]>;
  }

  public modifyGenre(genre: Genre): Observable<Genre> {
    return this._httpMusiqueHubService
      .get(this.ModifyGenre, new HttpParams() // todo: add authorid
        .append('genreId', genre.id)
        .append('name', genre.name)
        .append('desc', genre.description)
      ) as Observable<Genre>;
  }
}

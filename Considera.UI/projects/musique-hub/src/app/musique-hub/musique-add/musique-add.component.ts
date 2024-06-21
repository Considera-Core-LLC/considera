import {Component} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {MusiqueService} from "../../../services/app/musique/musique.service";
import {MuhLoginDialogComponent} from "../../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {Genre} from "../../../models/app/musique/genre.model";
import {Subscription} from "rxjs";
import {Artist} from "../../../models/app/musique/artist.model";
import {Album} from "../../../models/app/musique/album.model";
import {MusiqueArtistsService} from "../../../services/app/musique/musique-artists.service";
import {MusiqueAlbumsService} from "../../../services/app/musique/musique-albums.service";
import {MusiqueGenresService} from "../../../services/app/musique/musique-genres.service";

@Component({
  selector: 'app-musique-add',
  templateUrl: './musique-add.component.html',
  styleUrls: ['./musique-add.component.scss']
})
export class MusiqueAddComponent {
  // todo: reference the cache static class?
  private _genreCache: Genre[] = [];
  private _albumCache: Album[] = [];
  private _artistCache: Artist[] = [];

  public constructor(private _snack: MatSnackBar,
                     private _musicService: MusiqueService,
                     private _musicArtistsService: MusiqueArtistsService,
                     private _musicAlbumsService: MusiqueAlbumsService,
                     private _musicGenresService: MusiqueGenresService) {
    this.loadGenres();
    this.loadArtists();
    this.loadAlbums();
  }

  public get genreOptions(): Genre[] {
    return this._genreCache;
  }

  public get albumOptions(): Album[] {
    return this._albumCache;
  }

  public get artistOptions(): Artist[] {
    return this._artistCache;
  }

  public loadGenres(): void {
    this._musicGenresService.getAllGenres().subscribe((genres: Genre[]) => {
      this._genreCache = genres;
    });
  }

  public loadArtists(): void {
    this._musicArtistsService.getArtists().subscribe((artists: Artist[]) => {
      this._artistCache = artists;
    });
  }

  public loadAlbums(): void {
    this._musicAlbumsService.getAlbums().subscribe((albums: Album[]) => {
      this._albumCache = albums;
    });
  }

  protected readonly MuhLoginDialogComponent = MuhLoginDialogComponent;
}

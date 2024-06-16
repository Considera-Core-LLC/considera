import {Component, Input} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {MuhLoginDialogComponent} from "../../../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {Artist} from "../../../../models/app/musique/artist.model";
import {Genre} from "../../../../models/app/musique/genre.model";
import {Album} from "../../../../models/app/musique/album.model";
import {MusiqueAlbumsService} from "../../../../services/app/musique/musique-albums.service";

@Component({
  selector: 'app-musique-add-album',
  templateUrl: './musique-add-album.component.html',
  styleUrl: './musique-add-album.component.scss'
})
export class MusiqueAddAlbumComponent {
  // Inputs
  @Input() artistOptions: Artist[] = [];
  @Input() genreOptions: Genre[] = [];

  // Fields
  public albumToAdd : Album = new Album();

  public constructor(private _snack: MatSnackBar,
                     private _musicService: MusiqueService,
                     private _musicAlbumsService: MusiqueAlbumsService) {}

  public setName(name: string): void {
    this.albumToAdd.name = name;
  }

  public setArtists(artistNames: string[]): void {
    this.albumToAdd.artistIds = this.artistOptions
      .filter(x => artistNames.includes(x.name))
      .map(x => x.id);
  }

  public setGenres(genreNames: string[]): void {
    this.albumToAdd.genreIds = this.genreOptions
      .filter(x => genreNames.includes(x.name))
      .map(x => x.id);
  }

  public setReleaseDate(date: string): void {
    this.albumToAdd.releaseDate = new Date(date);
  }

  public setDescription(value: string): void {
    this.albumToAdd.description = value;
  }

  public getArtistOptions(): string[] {
    return this.artistOptions.map(x => x.name);
  }

  public getGenreOptions(): string[] {
    return this.genreOptions.map(x => x.name);
  }

  public add(): void {
    if (!this._try()) return;

    if (this.albumToAdd.name === '' ||
      this.albumToAdd.description === '' ||
      this.albumToAdd.releaseDate === undefined ||
      this.albumToAdd.artistIds.length === 0 ||
      this.albumToAdd.genreIds.length === 0) {
      this._snack.open('Please fill out all fields!', 'Close');
      return;
    }

    this.albumToAdd.authorId = MuhLoginDialogComponent.getId();
    this.albumToAdd.verifierId = '0';

    this._musicAlbumsService.addAlbum(this.albumToAdd).subscribe(
      x => {
        this._snack.open('Album added!', 'Close', {duration: 5000}); // todo: add a refresh option
      },
      error => {
        this._snack.open('Error!', 'Close');
      }
    );
  }

  public clear(): void {
    this.albumToAdd = new Album();
  }

  private _try(): boolean {
    if (!MuhLoginDialogComponent.loggedIn()) {
      this._snack.open('Please login first!', 'Close');
      return false;
    }
    return true;
  }
}

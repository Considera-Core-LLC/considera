import {Component, Input} from '@angular/core';
import {Artist} from "../../../../models/app/musique/artist.model";
import {MuhLoginDialogComponent} from "../../../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {Genre} from "../../../../models/app/musique/genre.model";
import {MusiqueArtistsService} from "../../../../services/app/musique/musique-artists.service";

@Component({
  selector: 'musique-add-artist',
  templateUrl: './musique-add-artist.component.html',
  styleUrl: './musique-add-artist.component.scss'
})
export class MusiqueAddArtistComponent {
  public artistInput: string = '';
  public originInput: string = '';
  public formDateInput: string = '';
  public bioInput: string = '';
  public addArtistGenreInput: string[] = [];
  @Input() genreOptions: Genre[] = [];

  public constructor(private _snack: MatSnackBar,
                     private _musicService: MusiqueService,
                     private _musicArtistsService: MusiqueArtistsService) {}

  public setArtistInput(value: string): void {
    this.artistInput = value;
  }

  public setOriginInput(value: string): void {
    this.originInput = value;
  }

  public setFormDateInput(value: string): void {
    this.formDateInput = value;
  }

  public setBioInput(value: string): void {
    this.bioInput = value;
  }

  public setGenresInput(genres: string[]): void {
    this.addArtistGenreInput = genres;
  }

  public getGenreOptions(): string[] {
    return this.genreOptions.map(x => x.name);
  }

  public addArtist(): void {
    if (!MuhLoginDialogComponent.loggedIn()) {
      this._snack.open('Please login to add an artist!', 'Close');
      return;
    }

    this.formDateInput = '05/10/2021'
    console.log(this.artistInput, this.originInput, this.formDateInput, this.bioInput, this.addArtistGenreInput);

    if (this.artistInput === '' || this.originInput === '' || this.formDateInput === '') {
      this._snack.open('Please fill out all fields!', 'Close');
      return;
    }

    const artist = new Artist();
    artist.name = this.artistInput;
    artist.origin = this.originInput;
    artist.formedDate = new Date(this.formDateInput);
    artist.bio = this.bioInput;
    artist.authorId = MuhLoginDialogComponent.getId();
    artist.verifierId = '0';
    console.log(MuhLoginDialogComponent.currentUser);
    console.log(artist);

    this._musicArtistsService.addArtist(artist).subscribe(
      x => {
        console.log('Result: ' + x)
        this._snack.open('Artist added!', 'Close', {duration: 5000});
      },
      error => {
        console.log('Error: ' + error);
        this._snack.open('Error!', 'Close', {duration: 5000});
      }
    );

  }

  private _try(): boolean {
    if (!MuhLoginDialogComponent.loggedIn()) {
      this._snack.open('Please login first!', 'Close');
      return false;
    }
    return true;
  }
}

import {Component, Input} from '@angular/core';
import {MatSnackBar} from "@angular/material/snack-bar";
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {MuhLoginDialogComponent} from "../../../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {Artist} from "../../../../models/app/musique/artist.model";
import {Genre} from "../../../../models/app/musique/genre.model";
import {MusiqueArtistsService} from "../../../../services/app/musique/musique-artists.service";

@Component({
  selector: 'app-musique-add-catalog',
  templateUrl: './musique-add-catalog.component.html',
  styleUrl: './musique-add-catalog.component.scss'
})
export class MusiqueAddCatalogComponent {
  public artistInput: string = '';
  public originInput: string = '';
  public formDateInput: string = '';
  public bioInput: string = '';
  public addArtistGenreInput: string[] = [];
  @Input() genreOptions: Genre[] = [];

  public constructor(private _snack: MatSnackBar,
                     private _musiqueArtistsService: MusiqueArtistsService) {}

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

  public setGenreInput(value: string[]): void {
    this.addArtistGenreInput = value;
  }

  public addArtist(): void {
    if (!MuhLoginDialogComponent.loggedIn()) {
      this._snack.open('Please login to add an artist!', 'Close');
      return;
    }

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

    this._musiqueArtistsService.addArtist(artist).subscribe(
      (result: boolean) => {
        console.log('Result: ' + result)
        this._snack.open('Artist added!', 'Close', {duration: 5000});
      },
      error => {
        console.log('Error: ' + error);
        this._snack.open('Error!', 'Close');
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

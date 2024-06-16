import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {Genre} from "../../../../models/app/musique/genre.model";
import {MuhLoginDialogComponent} from "../../../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {
  MuhSingleTextInputComponent
} from "../../../_templates/muh-inputs/muh-text-inputs/muh-single-text-input/muh-single-text-input.component";
import {MusiqueGenresService} from "../../../../services/app/musique/musique-genres.service";

@Component({
  selector: 'app-musique-modify-genre',
  templateUrl: './musique-modify-genre.component.html',
  styleUrl: './musique-modify-genre.component.scss'
})
export class MusiqueModifyGenreComponent {
  public loadedGenre : Genre = new Genre();
  public selectedGenre: Genre = new Genre();
  @Input() genreOptions: Genre[] = [];
  @Output() public genreDataChanged: EventEmitter<void> =
    new EventEmitter<void>();
  @ViewChild('nameInput') public nameInput =
    new MuhSingleTextInputComponent();
  @ViewChild('descriptionInput') public descriptionInput =
    new MuhSingleTextInputComponent();

  public constructor(private _snack: MatSnackBar,
                     private _musicGenresService: MusiqueGenresService) {}

  public getGenreOptions(): string[] {
    return this.genreOptions.map(x => x.name);
  }

  public onGenreSelect(): void {
    this._musicGenresService
      .getGenre(this.selectedGenre.id)
      .subscribe(genre => {
        this.loadedGenre = genre;
        this.nameInput.input = genre.name;
        this.descriptionInput.input = genre.description;
      });
  }

  public setGenreQuery(name: string): void {
    this.selectedGenre = this.genreOptions
      .find(x => x.name === name) || new Genre();
    this.onGenreSelect();
  }

  public setGenreName(value: string): void {
    this.loadedGenre.name = value;
  }

  public setGenreDesc(value: string): void {
    console.log(value);
    this.loadedGenre.description = value;
  }

  public clear(): void {
    this.loadedGenre = new Genre();
    this.selectedGenre = new Genre();
    this.nameInput.clear();
    this.descriptionInput.clear();
  }

  public save(): void {
    console.log('Saving genre')
    this._musicGenresService.modifyGenre(this.loadedGenre).subscribe(x => {
      console.log('Genre modified')
    });
  }

  private _try(): boolean {
    if (!MuhLoginDialogComponent.loggedIn()) {
      return this._throwSnack(0);
    }
    return true;
  }

  private _throwSnack(id: number): boolean { // todo replace with enum
    switch (id) {
      case 0:
        this._snack.open('Please login first!', 'Close');
        break;
      case 1:
        this._snack.open('No genres added! They likely exist already.', 'Close');
        break;
      case 2:
        this._snack.open('No subgenres assigned! They likely exist already.', 'Close');
        break;
    }
    return false;
  }
}

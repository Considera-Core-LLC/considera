import {Component, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {
  MuhAutoTextInputComponent
} from "../../../_templates/muh-inputs/muh-text-inputs/muh-auto-text-input/muh-auto-text-input.component";
import {Genre} from "../../../../models/app/musique/genre.model";
import {MuhLoginDialogComponent} from "../../../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {MatSnackBar} from "@angular/material/snack-bar";
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {MusiqueGenresService} from "../../../../services/app/musique/musique-genres.service";

@Component({
  selector: 'app-musique-add-genre',
  templateUrl: './musique-add-genre.component.html',
  styleUrl: './musique-add-genre.component.scss'
})
export class MusiqueAddGenreComponent {
  public genresToAdd: string[] = [];
  public genresToAssign: string[] = [];
  public subgenresToAssign: string[] = [];
  @Input() genreOptions: Genre[] = [];
  @Output() public genreDataChanged: EventEmitter<void> = new EventEmitter<void>();
  @ViewChild('genresToAddInput') public genresToAddInput = new MuhAutoTextInputComponent();
  @ViewChild('genresToAssignInput') public genresToAssignInput = new MuhAutoTextInputComponent();
  @ViewChild('subgenresToAssignInput') public subgenresToAssignInput = new MuhAutoTextInputComponent();

  public constructor(private _snack: MatSnackBar,
                     private _musicGenresService: MusiqueGenresService) {}

  public setGenresToAdd(value: string[]): void {
    this.genresToAdd = value;
  }

  public setGenresToAssign(value: string[]): void {
    this.genresToAssign = value;
  }

  public setSubgenresToAssign(value: string[]): void {
    this.subgenresToAssign = value;
  }

  public getGenreOptions(): string[] {
    return this.genreOptions.map(x => x.name);
  }

  public addGenres(): void {
    if (!this._try())
      return;

    const genres: Genre[] = [];
    this.genresToAdd.forEach((genre: string) =>
      genres.push(new Genre(genre)));

    console.log(this.genresToAdd);

    this._musicGenresService.addGenres(genres).subscribe(
      (result: Genre[]) => {
        if (result.length == 0)
          this._throwSnack(1);
        else
          result.forEach((genre: Genre) => this._snack.open(`${genre.name} added!`, 'Close', {duration: 5000}));

        this.genresToAddInput.clear();
        this.genreDataChanged.emit();
      },
      error => {
        console.log('Error: ' + error);
        this._snack.open('Error!', 'Close');
      }
    );
  }

  public assignSubgenres(): void {
    if (!this._try() || MuhLoginDialogComponent.currentUser === undefined)
      return;

    const genres: Genre[] = [];
    const subgenres: Genre[] = [];

    this.genresToAssign.forEach((genre: string) =>
      genres.push(new Genre(genre)));

    this.subgenresToAssign.forEach((genre: string) =>
      subgenres.push(new Genre(genre)));

    this._musicGenresService.assignSubgenres(MuhLoginDialogComponent.currentUser, genres, subgenres).subscribe(
      (result: Genre[]) => {
        if (result.length == 0)
          this._throwSnack(2);
        else
          result.forEach((genre: Genre) => this._snack.open(`${genre.name} assigned!`, 'Close', {duration: 5000}));

        this.genresToAssignInput.clear();
        this.subgenresToAssignInput.clear();
        this.genreDataChanged.emit();

        // todo: next moves; prevent users from reassigning subgenres, either produce an error or show a snack and remove the chip
        // genreCache only changes on first load, or when the user adds a genre, or when the user assigns a subgenre. figure out a design pattern for this
      },
      error => {
        console.log('Error: ' + error);
        this._snack.open('Error!', 'Close');
      },
    );

  }

  public clear(): void {
    this.genresToAddInput.clear();
    this.genresToAssignInput.clear();
    this.subgenresToAssignInput.clear();
    this.genresToAdd = [];
    this.genresToAssign = [];
    this.subgenresToAssign = [];
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

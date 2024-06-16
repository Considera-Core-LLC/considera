import {Genre} from "../../../../models/app/musique/genre.model";
import {Album} from "../../../../models/app/musique/album.model";

export class GenreTreeModel {
  public genre: Genre = new Genre();
  public childGenres: GenreTreeModel[] = [];
  public albums: Album[] = [];

  public constructor(genre: Genre = new Genre()) {
    this.genre = genre;
    this.childGenres = [];
    this.albums = genre.albums || [];
  }
}

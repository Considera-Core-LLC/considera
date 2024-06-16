import {Base} from "./base.model";
import {Genre} from "./genre.model";
import {Album} from "./album.model";

export class GenreAlbum extends Base {
  public albumId: string = '';
  public genreId: string = '';

  public album: Album = new Album();
  public genre: Genre = new Genre();
}

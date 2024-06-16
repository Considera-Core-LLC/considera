import {Base} from "./base.model";
import {Genre} from "./genre.model";

export class Album extends Base {
  public artistIds: string[] = [];
  public genreIds: string[] = [];
  public description: string = '';
  public releaseDate: Date = new Date();

  public genres: Genre[] = [];
}

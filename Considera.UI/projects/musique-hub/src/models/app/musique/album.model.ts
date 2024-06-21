import {Base} from "./base.model";
import {Genre} from "./genre.model";
import {Artist} from "./artist.model";
import {DateService} from "../../../services/date.service";

export class Album extends Base {
  public artistIds: string[] = [];
  public genreIds: string[] = [];
  public description: string = '';
  public releaseDate: Date = new Date();

  public genres: Genre[] = [];
  public artists: Artist[] = [];

  public static getArtistList(album : Album): string {
    return album.artists.map((artist: Artist) => artist.name).join(', ');
  }

  public static getFormattedReleaseDate(album: Album): string {
    return DateService.getWordedDate(album.releaseDate);
  }
}

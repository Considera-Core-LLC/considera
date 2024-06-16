import {Genre} from "../../../models/app/musique/genre.model";
import {Artist} from "../../../models/app/musique/artist.model";
import {Album} from "../../../models/app/musique/album.model";
import {ArtistAlbum} from "../../../models/app/musique/artist-album.model";
import {GenreAlbum} from "../../../models/app/musique/genre-album.model";

export class MusiqueCache {
  public static Genres: Genre[] = [];
  public static Artists: Artist[] = [];
  public static Albums: Album[] = [];
  public static GenreAlbums: GenreAlbum[] = [];
  public static ArtistAlbums: ArtistAlbum[] = [];

  public static AddGenre(genre: Genre): void {
    let genreIndex = this.Genres.findIndex(x => x.id === genre.id);
    if (genreIndex !== -1)
      this.Genres[genreIndex] = genre;
     else
      this.Genres.push(genre);
  }

  public static SetGenres(genres: Genre[]): void {
    this.Genres = [];
    genres.forEach(x => this.Genres.push(x));
  }

  public static SetArtists(artists: Artist[]): void {
    this.Artists = [];
    artists.forEach(x => this.Artists.push(x));
  }

  public static SetAlbums(albums: Album[]): void {
    this.Albums = [];
    albums.forEach(x => this.Albums.push(x));
  }

  public static SetGenreAlbums(genreAlbums: GenreAlbum[]): void {
    this.GenreAlbums = [];
    genreAlbums.forEach(x => this.GenreAlbums.push(x));
  }

  public static SetArtistAlbums(artistAlbums: ArtistAlbum[]): void {
    this.ArtistAlbums = [];
    artistAlbums.forEach(x => this.ArtistAlbums.push(x));
  }
}

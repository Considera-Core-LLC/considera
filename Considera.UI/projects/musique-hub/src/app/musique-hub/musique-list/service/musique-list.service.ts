import {Injectable} from "@angular/core";
import {GenreTreeModel} from "../model/genre-tree.model";
import {Genre} from "../../../../models/app/musique/genre.model";
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {Album} from "../../../../models/app/musique/album.model";
import {MusiqueAlbumsService} from "../../../../services/app/musique/musique-albums.service";

@Injectable({
  providedIn: 'root'
})
export class MusiqueListService {
  public constructor(private _musicService: MusiqueService,
                     private _musicAlbumsService: MusiqueAlbumsService) {}

  // a lot of this logic can prob be done in the service, just get it done and over with rather than all here

  public makeGenresTree(genres: Genre[]): GenreTreeModel[] {
    const genreTree: GenreTreeModel[] = [];
    genres = this.mapParentGenres(genres);
    this.makeParentTree(genres).forEach(x => genreTree.push(x));
    return genreTree;



    this._musicService
      .getGenreAlbumsFromGenres(genres.map(x => x.id))
      .subscribe(x => {
        genres = this.mapParentGenres(genres);

        if (x.length === 0) {
          this.makeParentTree(genres).forEach(x => genreTree.push(x));
          return;
        }

        this._musicAlbumsService
          .getAlbumsByIds(x.map(y => y.albumId))
          .subscribe(y => {
            genres.map(z => {
              console.log("x: ", x);
              console.log("y: ", y);
              console.log("z: ", z);
              let gas = x.filter(a => a.genreId === z.id).map(a => {
                a.album = y.find(b => b.id === a.albumId) || new Album();
                a.genre = z;
                return a;
              });

              console.log("gas: ", gas);
              console.log("gasmap: ", gas.map(a => a.album).filter(a => y.map(z => z.id).includes(a.id)));

              z.albums = gas.length === 0
                ? []
                : gas.map(a => a.album).filter(a => y.map(z => z.id).includes(a.id));

              return z;
            });

            this.makeParentTree(genres).forEach(x => genreTree.push(x));
          });

      });

    console.log(genreTree);

    return genreTree;
  }

  private mapParentGenres(genres: Genre[]): Genre[] {
    return genres.map(y => {
      y.parentGenre = genres.find(x => x.id === y.parentId);
      return y;
    })
  }

  private makeParentTree(genres: Genre[]): GenreTreeModel[] {
    const genreTree: GenreTreeModel[] = [];
    genres.forEach(y => {
      const model = new GenreTreeModel(y);
      if (y.parentGenre !== undefined) {
        const parentModel =
          genreTree.find(x => Genre.equals(x.genre, y.parentGenre)) ||
          new GenreTreeModel(y.parentGenre);
        parentModel.childGenres.push(model);
        return;
      }
      genreTree.push(model);
    });
    return genreTree;
  }
}

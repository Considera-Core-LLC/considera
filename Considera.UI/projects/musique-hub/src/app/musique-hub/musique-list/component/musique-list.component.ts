import {Component, NgZone} from '@angular/core';
import {MusiqueService} from "../../../../services/app/musique/musique.service";
import {GenreTreeModel} from "../model/genre-tree.model";
import {MusiqueListService} from "../service/musique-list.service";
import {NestedTreeControl} from "@angular/cdk/tree";
import {MatTreeNestedDataSource} from "@angular/material/tree";

@Component({
  selector: 'app-musique-list',
  templateUrl: './musique-list.component.html',
  styleUrls: ['./musique-list.component.scss']
})
export class MusiqueListComponent {
  public genresDataSource: MatTreeNestedDataSource<GenreTreeModel> =
    new MatTreeNestedDataSource<GenreTreeModel>();

  public treeControl : NestedTreeControl<GenreTreeModel> =
    new NestedTreeControl<GenreTreeModel>(node => node.childGenres);

  public hasChild = (_: number, node: GenreTreeModel) =>
    !!node.childGenres && node.childGenres.length > 0

  public constructor(private _musicService: MusiqueService,
                     private _musicListService: MusiqueListService,
                     private _zone: NgZone) {}

  public grabGenres(): void {
    this._musicService
      .getGenresWithAlbums()
      .subscribe(
        x => this.genresDataSource.data = this._musicListService.makeGenresTree(x),
        e => console.log('Error: ' + e)
      );
  }

  public onView(): void {
    this.grabGenres();
  }
}

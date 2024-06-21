import {Component, Input} from '@angular/core';
import {Album} from "../../../../models/app/musique/album.model";

@Component({
  selector: 'muh-card-album',
  templateUrl: './muh-card-album.component.html',
  styleUrl: './muh-card-album.component.scss'
})
export class MuhCardAlbumComponent {
  public imageSrc: string = 'assets/images/grace.jpg';
  @Input() public album: Album = new Album();
// todo this muh-cards folder needs to be moved out of the _templates
//  folder, as it is not a template, but a component
  public constructor() {}

  protected readonly Album = Album;
}

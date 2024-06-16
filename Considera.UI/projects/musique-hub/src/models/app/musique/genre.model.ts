import {Base} from "./base.model";
import {Album} from "./album.model";

export class Genre extends Base {
  public parentId: string | undefined = undefined;
  public parentGenre: Genre | undefined = undefined;
  public description: string = '';

  public albums: Album[] = [];

  public constructor(name: string = '', description: string = '') {
    super(name);
    this.description = description;
  }

  public static equals(left: Genre | undefined, right: Genre | undefined): boolean {
    return left !== undefined && right !== undefined && left.id === right.id;
  }
}

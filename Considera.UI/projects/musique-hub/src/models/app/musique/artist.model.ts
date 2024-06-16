import {Base} from "./base.model";

export class Artist extends Base {
  public bio: string = '';
  public origin: string = '';
  public formedDate: Date = new Date();
}

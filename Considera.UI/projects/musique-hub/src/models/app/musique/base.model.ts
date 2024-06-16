export class Base {
  public id: string = '';
  public authorId: string = '';
  public verifierId: string = '';
  public name: string = '';

  public constructor(name: string = '') {
    this.name = name;
  }
}

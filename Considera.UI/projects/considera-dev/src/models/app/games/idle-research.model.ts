export class IdleResearch {
  public id = '';
  public energyLog = 0;

  public getId(): string {
    return this.id;
  }

  public setId(id: string): void {
    this.id = id;
  }

  public getEnergyLog(): number {
    return this.energyLog;
  }

  public setEnergyLog(energyLog: number): void {
    this.energyLog = energyLog;
  }
}

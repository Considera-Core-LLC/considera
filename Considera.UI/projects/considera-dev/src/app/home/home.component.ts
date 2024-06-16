import {Component, OnInit} from '@angular/core';
import {GamesService} from "../../services/app/games/games.service";
import {IdleResearch} from "../../models/app/games/idle-research.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  public displayedColumns: string[] = ['id', 'energyLog'];
  public idleResearchModels : IdleResearch[] = [];

  public constructor(private _gamesService: GamesService) {
  }

  public ngOnInit(): void {
    this._gamesService.get().subscribe((data: IdleResearch[]) => {
      this.idleResearchModels = data;
    });

  }
}

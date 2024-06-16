import {Component, ViewChild} from '@angular/core';
import {MusiqueService} from "../../services/app/musique/musique.service";
import {MuhLoginDialogComponent} from "../_dialogs/muh-login-dialog/muh-login-dialog.component";
import {MatDialog, MatDialogRef} from "@angular/material/dialog";
import {
  MusiqueListComponent
} from "./musique-list/component/musique-list.component";
import {PageEnum} from "./enum/page.enum";

@Component({
  selector: 'musique-hub',
  templateUrl: './musique-hub.component.html',
  styleUrls: ['./musique-hub.component.scss']
})
export class MusiqueHubComponent {

  public currentPage: PageEnum = PageEnum.HOME;
  public usernameInput: string = '';
  public passwordInput: string = '';
  public lastLoginStatus: string = '';

  @ViewChild(MusiqueListComponent) private listPage! : MusiqueListComponent;

  public constructor(private _dialog: MatDialog,
                     private _musiqueService: MusiqueService) {
    this.getUsers();
    this.currentPage = PageEnum.ADD;
  }

  public getUsers(): void {
    this._musiqueService.getUsers().subscribe((user) => {
      console.log(user);
    });
  }

  public openLogin(): void {
    // Opening the dialog without custom configuration for simplicity
    let dialogRef: MatDialogRef<MuhLoginDialogComponent> =
      this._dialog.open(MuhLoginDialogComponent);

    // Assign cancelLogin function with preserved context
    dialogRef.componentInstance.cancelLogin = dialogRef.close.bind(dialogRef);
  }

  public isCurrentPage(page: PageEnum): boolean {
    return this.currentPage == page;
  }

  public setCurrentPage(page: PageEnum): void {
    this.currentPage = page;
    if (page === PageEnum.LIST && this.listPage) {
      this.listPage.onView();
    }
  }

  protected readonly MuhLoginDialogComponent = MuhLoginDialogComponent;
  protected readonly PageEnum = PageEnum;
}

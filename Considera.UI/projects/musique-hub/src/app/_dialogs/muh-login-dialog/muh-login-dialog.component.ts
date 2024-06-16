import {Component, Inject, Input} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {User} from "../../../models/app/musique/user.model";
import {MusiqueService} from "../../../services/app/musique/musique.service";
import {MatSnackBar} from "@angular/material/snack-bar";

@Component({
  selector: 'app-muh-login-dialog',
  templateUrl: './muh-login-dialog.component.html',
  styleUrls: ['./muh-login-dialog.component.scss']
})
export class MuhLoginDialogComponent {
  public static currentUser: User | undefined = undefined;
  public loggingIn: boolean = false;
  public registering: boolean = false;
  public usernameInput: string = '';
  public passwordInput: string = '';
  @Input() public cancelLogin: () => void = () => {};

  public constructor(private _loginDialogRef: MatDialogRef<MuhLoginDialogComponent>,
                     private _musiqueService: MusiqueService,
                     private _snackBar: MatSnackBar,
                     @Inject(MAT_DIALOG_DATA) public data: User) {

    // todo tmp
    this.usernameInput = 'test';
    this.passwordInput = 'bob';
    this.login();
  }

  public static loggedIn(): boolean {
    return MuhLoginDialogComponent.currentUser !== undefined;
  }

  public static getId(): string {
    return MuhLoginDialogComponent.currentUser?.id || '';
  }

  public static getUsername(): string {
    return MuhLoginDialogComponent.currentUser?.username || '';
  }

  public login(): void {
    this.loggingIn = true;
    this._musiqueService.login(this.usernameInput, this.passwordInput).subscribe(
      (user: User) => {
        if (user.isLoggedIn) {
          MuhLoginDialogComponent.currentUser = user;
          this.openSnackBar('Login successful!');
          this._loginDialogRef.close();
        } else {
          this.openSnackBar('Login failed!');
        }
      },
      error => this.openSnackBar('Login failed!'))
      .add(() => {
        this.loggingIn = false;
      });
  }

  public register(): void {
    this.registering = true;
    this._musiqueService.register(this.usernameInput, this.passwordInput).subscribe(
      (user: User) => {
        if (user.isLoggedIn) {
          MuhLoginDialogComponent.currentUser = new User();
          MuhLoginDialogComponent.currentUser.username = this.usernameInput;
          this.openSnackBar('Register and Login successful!');
          this._loginDialogRef.close();
        } else {
          this.openSnackBar('Register failed!');
        }
      },
      (error: any) => {
        this.openSnackBar('Register failed!');
        console.error(error);
      })
      .add(() : void => {
        this.registering = false;
      });
  }



  public openSnackBar(message: string): void {
    this._snackBar.open(message, "Close", {
      duration: 2000,
    });
  }
}

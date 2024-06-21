import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxGoogleAnalyticsModule } from 'ngx-google-analytics';
import {MatDividerModule} from "@angular/material/divider";
import {MatCardModule} from "@angular/material/card";
import {MatInputModule} from "@angular/material/input";
import {MatIconModule} from "@angular/material/icon";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatButtonModule} from "@angular/material/button";
import {AppComponent} from "./app.component";
import {MusiqueHubComponent} from "./musique-hub/musique-hub.component";
import {MusiqueHomeComponent} from "./musique-hub/musique-home/musique-home.component";
import {MusiqueAddComponent} from "./musique-hub/musique-add/musique-add.component";
import {AppRoutingModule} from "./app-routing.module";
import {HttpServiceModule} from "../../../considera-dev/src/services/http/http.service.module";
import {MatNativeDateModule} from "@angular/material/core";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MatAutocompleteModule} from "@angular/material/autocomplete";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatSnackBarModule} from "@angular/material/snack-bar";
import {MatExpansionModule} from "@angular/material/expansion";
import { MuhExpansionPanelComponent } from './_templates/muh-expansion-panel/muh-expansion-panel.component';
import { MuhInputRowComponent } from './_templates/muh-inputs/muh-input-row/muh-input-row.component';
import { MuhInputSectionComponent } from './_templates/muh-inputs/muh-input-section/muh-input-section.component';
import { MuhLoginDialogComponent } from './_dialogs/muh-login-dialog/muh-login-dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatProgressSpinnerModule} from "@angular/material/progress-spinner";
import { MusiqueListComponent } from './musique-hub/musique-list/component/musique-list.component';
import {MatGridListModule} from "@angular/material/grid-list";
import { MuhSingleTextInputComponent } from './_templates/muh-inputs/muh-text-inputs/muh-single-text-input/muh-single-text-input.component';
import { MuhDateInputComponent } from './_templates/muh-inputs/muh-date-input/muh-date-input.component';
import { MuhMultiTextInputComponent } from './_templates/muh-inputs/muh-text-inputs/muh-multi-text-input/muh-multi-text-input.component';
import { MuhAutoTextInputComponent } from './_templates/muh-inputs/muh-text-inputs/muh-auto-text-input/muh-auto-text-input.component';
import {MatChipsModule} from "@angular/material/chips";
import {MatButtonToggleModule} from "@angular/material/button-toggle";
import { MusiqueAddArtistComponent } from './musique-hub/musique-add/musique-add-artist/musique-add-artist.component';
import { MusiqueAddGenreComponent } from './musique-hub/musique-add/musique-add-genre/musique-add-genre.component';
import { MusiqueAddAlbumComponent } from './musique-hub/musique-add/musique-add-album/musique-add-album.component';
import { MusiqueAddSongComponent } from './musique-hub/musique-add/musique-add-song/musique-add-song.component';
import { MusiqueAddCatalogComponent } from './musique-hub/musique-add/musique-add-catalog/musique-add-catalog.component';
import {
  MatNestedTreeNode,
  MatTree, MatTreeModule,
  MatTreeNode,
  MatTreeNodeDef,
  MatTreeNodePadding,
  MatTreeNodeToggle
} from "@angular/material/tree";
import {MatList, MatListItem, MatNavList} from "@angular/material/list";
import {
  MusiqueModifyGenreComponent
} from "./musique-hub/musique-add/musique-modify-genre/musique-modify-genre.component";
import { MuhCardAlbumComponent } from './_templates/muh-cards/muh-card-album/muh-card-album.component';

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    MusiqueHubComponent,
    MusiqueHomeComponent,
    MusiqueAddComponent,
    MuhExpansionPanelComponent,
    MuhInputRowComponent,
    MuhInputSectionComponent,
    MuhExpansionPanelComponent,
    MuhInputRowComponent,
    MuhLoginDialogComponent,
    MusiqueListComponent,
    MuhSingleTextInputComponent,
    MuhDateInputComponent,
    MuhMultiTextInputComponent,
    MuhAutoTextInputComponent,
    MusiqueAddArtistComponent,
    MusiqueAddGenreComponent,
    MusiqueModifyGenreComponent,
    MusiqueAddAlbumComponent,
    MusiqueAddSongComponent,
    MusiqueAddCatalogComponent,
    MuhCardAlbumComponent
  ],
  exports: [
    AppComponent,
    MusiqueHubComponent,
    MusiqueHomeComponent,
    MusiqueListComponent,
    MusiqueAddComponent,
    MuhExpansionPanelComponent,
    MuhInputRowComponent,
    MuhLoginDialogComponent
  ],
  imports: [
    NgxGoogleAnalyticsModule.forRoot('G-HJS5QC16FG'),
    BrowserModule,
    AppRoutingModule,
    MatDividerModule,
    MatCardModule,
    MatInputModule,
    MatIconModule,
    MatDatepickerModule,
    MatCheckboxModule,
    MatToolbarModule,
    MatButtonModule,
    HttpServiceModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    FormsModule,
    MatExpansionModule,
    MatDialogModule, MatFormFieldModule, MatProgressSpinnerModule, MatGridListModule, MatChipsModule, MatButtonToggleModule, MatTreeModule, MatTreeNode, MatTreeNodePadding, MatNestedTreeNode, MatTreeNodeDef, MatListItem, MatTreeNodeToggle, MatNavList, MatList,
  ],
  providers: []
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';

// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './home/footer/footer.component';
import { HeaderComponent } from './home/header/header.component';
import { ProjectsComponent } from './home/projects/projects.component';
import { ProjectCardComponent } from './home/projects/project-card/project-card.component';
import { RoadmapComponent } from './home/roadmap/roadmap.component';
import { BadgeComponent } from './badge/badge.component';

// Services
import { HttpServiceModule } from '../services/http/http.service.module';

// Analytics
import { NgxGoogleAnalyticsModule } from 'ngx-google-analytics';

// Angular Material Modules
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import {MatTableModule} from "@angular/material/table";
import {
  MatSidenavModule
} from "@angular/material/sidenav";
import {FormsModule} from "@angular/forms";
import {MatNativeDateModule} from "@angular/material/core";
import {MatDividerModule} from "@angular/material/divider";

@NgModule({
  bootstrap: [AppComponent],
  declarations: [
    AppComponent,
    HomeComponent,
    FooterComponent,
    HeaderComponent,
    ProjectsComponent,
    ProjectCardComponent,
    RoadmapComponent,
    BadgeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    BrowserAnimationsModule, // Import BrowserAnimationsModule to enable animations
    HttpServiceModule,
    NgxGoogleAnalyticsModule.forRoot('G-HJS5QC16FG'),
    // Import all required Angular Material modules here
    MatCheckboxModule, // This module exports the 'mat-checkbox' component
    MatIconModule,
    MatExpansionModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule,
    MatMenuModule,
    MatTableModule,
    FormsModule,
    MatNativeDateModule,
    MatSidenavModule,
    MatDividerModule,
  ],
  providers: [],
})
export class AppModule {}

//Angular Modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRouterModule } from './app-router.module';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//Components
import { AppComponent } from './app.component';
import { AuthorsComponent } from './authors/authors.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { PostAuthorsComponent } from './post-authors/post-authors.component';
import { BooksComponent } from './books/books.component';
import { AuthorsByBookComponent } from './authors-by-book/authors-by-book.component';
import { ActivitiesComponent } from './activities/activities.component';
import { ActivitiesTableComponent } from './activities-table/activities-table.component';
import { PostActivitiesComponent } from './post-activities/post-activities.component';
import { LoginComponent } from './login/login.component';
import { FormLoginComponent } from './form-login/form-login.component';

//endpoints WebAPI Services
import { AuthorsService } from './services/authors.service';
import { BooksService } from './services/books.service';
import { ActivitiesService } from './services/activities.service';
import { UsersService } from './services/users.service';

//Material Modules
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatTooltipModule } from '@angular/material/tooltip';




@NgModule({
  declarations: [
    AppComponent,
    AuthorsComponent,
    SidebarComponent,
    FooterComponent,
    PostAuthorsComponent,
    BooksComponent,
    AuthorsByBookComponent,
    ActivitiesComponent,
    ActivitiesTableComponent,
    PostActivitiesComponent,
    LoginComponent,
    FormLoginComponent
  ],
  imports: [
    BrowserModule,
    AppRouterModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule, 
    MatTableModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatDialogModule,
    MatPaginatorModule,
    MatGridListModule,
    FormsModule,
    MatTooltipModule
  ],
  entryComponents:[AuthorsByBookComponent, ActivitiesTableComponent, PostActivitiesComponent],
  providers: [AuthorsService, BooksService, ActivitiesService, UsersService], //service inyectado para todos los componentes
  bootstrap: [AppComponent]
})
export class AppModule { }

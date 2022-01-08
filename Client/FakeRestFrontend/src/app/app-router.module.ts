import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ActivitiesComponent } from "./activities/activities.component";
import { AuthorsComponent } from "./authors/authors.component";
import { BooksComponent } from "./books/books.component";
import { LoginComponent } from "./login/login.component";

const routes:Routes = [
    {path:'', component: LoginComponent},
    {path:'login', component: LoginComponent},
    {path:'authors', component: AuthorsComponent},
    {path:'books', component: BooksComponent},
    {path:'activities', component: ActivitiesComponent}


]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRouterModule{}
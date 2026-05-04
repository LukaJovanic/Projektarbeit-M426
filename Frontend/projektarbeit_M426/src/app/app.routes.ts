import { Routes } from '@angular/router';
import {LoginComponent} from './login.component/login.component';
import {RegisterComponent} from './register.component/register.component';
import {Startseite} from './startseite/startseite';

export const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'startseite', component: Startseite},
  {path: '', component: LoginComponent},
  {path: '**', component: LoginComponent}
];

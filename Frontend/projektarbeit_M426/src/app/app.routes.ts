import { Routes } from '@angular/router';
import {LoginComponent} from './login.component/login.component';
import {RegisterComponent} from './register.component/register.component';
import {Startseite} from './startseite/startseite';
import {MotorradUebersichtComponent} from './motorrad-uebersicht.component/motorrad-uebersicht.component';

export const routes: Routes = [
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'startseite', component: Startseite},
  { path: 'uebersicht', component: MotorradUebersichtComponent },
  {path: '', component: LoginComponent},
  {path: '**', component: LoginComponent}
];

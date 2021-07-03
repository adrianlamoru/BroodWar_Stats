import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { LoginComponent } from './components/login/login.component';
import { PlayerformComponent } from './components/playerform/playerform.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'playeradmin', component: PlayerformComponent , canLoad: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

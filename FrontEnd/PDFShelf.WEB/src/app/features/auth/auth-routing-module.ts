import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login';
// Importaremos o RegisterComponent aqui quando o criarmos

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  // 2. Redireciona o caminho vazio (ex: /auth) para /auth/login
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
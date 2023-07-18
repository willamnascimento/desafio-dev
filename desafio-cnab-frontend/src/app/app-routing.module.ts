import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./pages/formulario/formulario.module').then((m) => m.FormularioModule),
        
    },
    {
      path: 'lista-operacoes',
      loadChildren: () => import('./pages/operacoes/operacoes.module').then((m) => m.OperacoesModule),
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListProductsComponent } from './products/components/list-products/list-products.component';

export const routes: Routes = [
  { 
    path:'', 
    redirectTo: 'listarProdutos',
    pathMatch: 'full' 
  },
  {
    path:'listarProdutos',
    component: ListProductsComponent
  }

];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

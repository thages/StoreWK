import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './products/components/add-product/add-product.component';
import { ListProductsComponent } from './products/components/list-products/list-products.component';

export const routes: Routes = [
  { 
    path:'', 
    redirectTo: 'produtos/lista',
    pathMatch: 'full' 
  },
  {
    path:'produtos/lista',
    component: ListProductsComponent
  },
  {
    path:'produtos/adicionar',
    component: AddProductComponent
  }

];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

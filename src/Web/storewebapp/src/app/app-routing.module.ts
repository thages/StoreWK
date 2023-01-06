import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './pages/products/components/add-product/add-product.component';
import { ListProductsComponent } from './pages/products/components/list-products/list-products.component';
import { EditProductComponent } from './pages/products/components/edit-product/edit-product.component';
import { ListCategoriesComponent } from './pages/categories/list-categories/list-categories.component';
import { AddCategoryComponent } from './pages/categories/add-category/add-category.component';
import { EditCategoryComponent } from './pages/categories/edit-category/edit-category.component';

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
  },
  {
    path:'produtos/editar/:id',
    component: EditProductComponent
  },
  {
    path:'categorias/lista',
    component: ListCategoriesComponent
  },
  {
    path:'categorias/adicionar',
    component: AddCategoryComponent
  },
  {
    path:'categorias/editar/:id',
    component: EditCategoryComponent
  }

];



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PoModule } from '@po-ui/ng-components';
import { PoTemplatesModule } from '@po-ui/ng-templates';
import { ProductComponent } from './pages/products/components/product/product.component';
import { ListProductsComponent } from './pages/products/components/list-products/list-products.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { AddProductComponent } from './pages/products/components/add-product/add-product.component';
import { EditProductComponent } from './pages/products/components/edit-product/edit-product.component';
import { ListCategoriesComponent } from './pages/categories/list-categories/list-categories.component';
import { AddCategoryComponent } from './pages/categories/add-category/add-category.component';
import { EditCategoryComponent } from './pages/categories/edit-category/edit-category.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    ListProductsComponent,
    SidenavComponent,
    AddProductComponent,
    EditProductComponent,
    ListCategoriesComponent,
    AddCategoryComponent,
    EditCategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PoModule,
    PoTemplatesModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

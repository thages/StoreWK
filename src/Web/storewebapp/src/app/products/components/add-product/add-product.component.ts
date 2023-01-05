import { Component, OnInit, ViewChild } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {  PoModalComponent, PoSelectOption } from '@po-ui/ng-components';
import { Subscription } from 'rxjs';
import { CategoriesService } from 'src/app/categories/categories.service';
import { ProductsService } from '../../products.service';
import { IProductNew } from '../../utils/products.types';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent  implements OnInit {
  
  @ViewChild('reactiveFormData', { static: true }) reactiveFormModal: PoModalComponent;
  
  reactiveForm: UntypedFormGroup;
  private categoriesSubscription: Subscription;
  
  categoryOptions: Array<PoSelectOption>;
  
  constructor(
    private fb: UntypedFormBuilder,
    private categoriesService: CategoriesService,
    private productsService: ProductsService,
    private router: Router
  ) {
    this.createReactiveForm();
  }
  ngOnDestroy() {
    this.categoriesSubscription?.unsubscribe();
  }

  ngOnInit(){
    
    this.categoriesSubscription = this.categoriesService
    .listAll()
    .subscribe((list) => {
      
      this.categoryOptions = list.map((category) => {
        
        const items: PoSelectOption = {label: '', value: 0};
        
        items.label = category.name;
        items.value = category.id;
        
        return items;
      });
      
    });
  }

  createReactiveForm() {
    this.reactiveForm = this.fb.group({
      name: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.minLength(0), Validators.maxLength(150)])],
      price: ['', Validators.compose([Validators.required, Validators.min(1), Validators.max(999999)])],
      categoryId: [''],
    });
  }


  saveForm() {
    const newProduct: IProductNew = this.reactiveForm.value;
    this.productsService.createProduct(newProduct).subscribe(() => {
      this.router.navigate(['/produtos/lista'])
    });
  }

}

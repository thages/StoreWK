import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PoSelectOption } from '@po-ui/ng-components';
import { Subscription } from 'rxjs';
import { CategoriesService } from 'src/app/pages/categories/categories.service';
import { ProductsService } from '../../products.service';
import { IProductEntity } from '../../utils/products.types';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {

  reactiveForm: UntypedFormGroup;
  private categoriesSubscription: Subscription;
  private productsSubscription: Subscription;
  isLoading: boolean = false;
  categoryOptions: Array<PoSelectOption>;
  
  constructor(
    private fb: UntypedFormBuilder,
    private categoriesService: CategoriesService,
    private productsService: ProductsService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.createReactiveForm();
  }
  ngOnDestroy() {
    this.categoriesSubscription?.unsubscribe();
    this.productsSubscription?.unsubscribe();
  }

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get('id');
    this.isLoading = true;
    this.productsSubscription = this.productsService
      .getProductById(parseInt(id!))
      .subscribe((product) => {
        this.populateForm(product);
        this.isLoading = false;
      })

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
      id: [''],
      name: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.minLength(0), Validators.maxLength(150)])],
      price: ['', Validators.compose([Validators.required, Validators.min(1), Validators.max(999999)])],
      categoryId: ['',Validators.required],
    });
  }

  populateForm(product: IProductEntity): void {
    this.reactiveForm = this.fb.group({
        id: [product.id],
        name: [product.name],
        description: [product.description],
        price: [product.price],
        categoryId: [product.categoryId]
    })
  }

  saveForm() {
    this.isLoading = true;
    const productToUpdate: IProductEntity = this.reactiveForm.value;
    this.productsService.editProduct(productToUpdate).subscribe(() => {
      this.isLoading = false;
      this.router.navigate(['/produtos/lista'])
    });
  }

}

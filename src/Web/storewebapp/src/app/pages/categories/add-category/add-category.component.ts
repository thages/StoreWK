import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService } from '../categories.service';
import { ICategory } from '../utils/categories.types';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {

  reactiveForm: UntypedFormGroup;
  isLoading: boolean = false;
  
  
  constructor(
    private fb: UntypedFormBuilder,
    private categoriesService: CategoriesService,
    private router: Router
  ) {
    this.createReactiveForm();
  }

  ngOnInit() {}

  createReactiveForm() {
    this.reactiveForm = this.fb.group({
      name: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.minLength(0), Validators.maxLength(150)])],
    });
  }
  
  saveForm() {
    this.isLoading = true;
    const newCategory: ICategory = this.reactiveForm.value;
    this.categoriesService.createCategory(newCategory).subscribe(() => {
      this.isLoading = false;
      this.router.navigate(['/categorias/lista'])
    });
  }

}

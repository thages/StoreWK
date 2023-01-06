import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { CategoriesService } from '../categories.service';
import { ICategory } from '../utils/categories.types';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {

  reactiveForm: UntypedFormGroup;
  private categoriesSubscription: Subscription;
  isLoading: boolean = false;

  constructor(
    private fb: UntypedFormBuilder,
    private categoriesService: CategoriesService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.createReactiveForm();
  }
  ngOnDestroy() {
    this.categoriesSubscription?.unsubscribe();
  }

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get('id');
    this.isLoading = true;
    this.categoriesSubscription = this.categoriesService
      .getCategoryById(parseInt(id!))
      .subscribe((category) => {
        this.populateForm(category);
        this.isLoading = false;
      })
  }

  createReactiveForm() {
    this.reactiveForm = this.fb.group({
      id: [''],
      name: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(50)])],
      description: ['', Validators.compose([Validators.minLength(0), Validators.maxLength(150)])],
    });
  }

  populateForm(category: ICategory): void {
    this.reactiveForm = this.fb.group({
        id: [category.id],
        name: [category.name],
        description: [category.description]
    })
  }

  saveForm() {
    this.isLoading = true;
    const categoryToUpdate: ICategory = this.reactiveForm.value;
    this.categoriesService.editCategory(categoryToUpdate).subscribe(() => {
      this.isLoading = false;
      this.router.navigate(['/categorias/lista'])
    });
  }

}

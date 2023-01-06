import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PoTableColumn, PoTableComponent } from '@po-ui/ng-components';
import { Subscription } from 'rxjs';
import { CategoriesService } from '../categories.service';
import { ICategory } from '../utils/categories.types';

@Component({
  selector: 'app-list-categories',
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.scss']
})
export class ListCategoriesComponent implements OnInit {
  @ViewChild('POItemsOri', { static: true }) poItemsOri: PoTableComponent | undefined;
  private categoriesSubscription: Subscription;
  columns: Array<PoTableColumn> = [];
  items: Array<any> = [];
  showMoreDisabled: boolean = false;
  isLoading: boolean = false;
  isSelected: boolean = false;
  selectedCategory?: ICategory | null;
  categoriesList: ICategory[];
  
  constructor(
    private service: CategoriesService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnDestroy(): void {
    this.categoriesSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.columns = this.service.getColumns();

    this.loadCategoriesList();
  }
  
  loadCategoriesList(): void {
    this.categoriesSubscription = this.service.listAll().subscribe((list) => {
      this.categoriesList = list
      this.items = this.categoriesList;
      this.isLoading = false;
    });
  }

  onDelete(): void {
    this.isLoading = true;
    this.service.deleteCategory(this.selectedCategory!.id).subscribe(() => {
      this.isLoading = false;
      this.loadCategoriesList();
      this.hideButtons();
    });
  }

  changeOptions(event: any): void {
    this.isSelected = true;
    this.selectedCategory = event;
  }

  hideButtons(): void {
    this.isSelected = false;
    this.selectedCategory = null;
  }

}

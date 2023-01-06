import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPageableResult } from 'src/app/api/common.types';
import { ProductsService } from '../../products.service';
import { IProduct, IProductsListFilter, ProductOrderBy } from '../../utils/products.types';
import { PoSelectOption, PoTableColumnSort, PoTableComponent } from '@po-ui/ng-components';
import { PoTableColumn } from '@po-ui/ng-components';
import { Observable, BehaviorSubject, switchMap, map, Subscription } from 'rxjs';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.scss']
})
export class ListProductsComponent implements OnInit {
  @ViewChild('POItemsOri', { static: true }) poItemsOri: PoTableComponent | undefined;
  private productsSubscription: Subscription;
  columns: Array<PoTableColumn> = [];
  items: Array<any> = [];
  showMoreDisabled: boolean = false;
  isLoading: boolean = false;
  isSelected: boolean = false;
  selectedProduct?: IProduct | null;
  productsList: IProduct[];
  filter: IProductsListFilter = {
    pageSize: 5,
    currentPage: 1,
    orderBy: ProductOrderBy.NAME_ASC
  }
  constructor(
    private service: ProductsService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnDestroy(): void {
    this.productsSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this.isLoading = true;
    this.columns = this.service.getColumns();

    this.loadProductsList();
  }
  
  loadProductsList(): void {
    this.productsSubscription = this.service.listAll().subscribe((list) => {
      this.productsList = list
      this.items = this.productsList;
      this.isLoading = false;
    });
  }

  onDelete(): void {
    this.isLoading = true;
    this.service.deleteProduct(this.selectedProduct!.id).subscribe(() => {
      this.isLoading = false;
      this.loadProductsList();
    });
    
  }

  changeOptions(event: any): void {
    this.isSelected = true;
    this.selectedProduct = event;
  }

  hideButtons(): void {
    this.isSelected = false;
  }
}

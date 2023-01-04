import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPageableResult } from 'src/app/api/common.types';
import { ProductsService } from '../../products.service';
import { IProduct, IProductsListFilter, ProductOrderBy } from '../../utils/products.types';
import { PoSelectOption } from '@po-ui/ng-components';
import { PoTableColumn } from '@po-ui/ng-components';

@Component({
  selector: 'app-list-products',
  templateUrl: './list-products.component.html',
  styleUrls: ['./list-products.component.scss']
})
export class ListProductsComponent implements OnInit {

  columns: Array<PoTableColumn> = [];
  items: Array<any> = [];
  productsList: IProduct[] = [];
  filter: IProductsListFilter = {
    pageSize: 5,
    currentPage: 1,
    orderBy: ProductOrderBy.NAME_ASC
  }
  constructor(
    private service: ProductsService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.service.pageableList(this.filter).subscribe((productsList) => {
      this.productsList = productsList.results
    });
    this.columns = this.service.getColumns();
    this.items = this.productsList;

    console.log("productsList: ",this.productsList);
  }

}

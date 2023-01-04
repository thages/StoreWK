import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct, IProductsListFilter } from './utils/products.types';
import { CommonApiService } from '../api/common-api.service';
import { PoTableColumn } from '@po-ui/ng-components';
import { IPageableResult } from '../api/common.types';

@Injectable({
  providedIn: 'root'
})
export class ProductsService extends CommonApiService {

  constructor(httpClient: HttpClient) {
    super('http://localhost:5070/api/v1/Products', httpClient)
   }

  pageableList(filter: IProductsListFilter ): Observable<IPageableResult<IProduct>> {
    console.log('ilter: ',filter)
    return this.list<IProductsListFilter>(filter);
  }

  getById(id: number): Observable<IProduct> {
    const url = `${this.path}/${id}`
    return this.httpClient.get<IProduct>(url)
  }

  getColumns(): Array<PoTableColumn> {
    return [
      { property: 'Código', type: 'number', width: '8%' },
      { property: 'Produto' },
      { property: 'Descrição' },
      { property: 'Preço', type: 'currency', format: 'BRL' },
      { property: 'Categoria' }
    ]
  }

}

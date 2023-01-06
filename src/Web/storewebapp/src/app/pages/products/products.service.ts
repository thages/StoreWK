import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProduct, IProductsListFilter, IProductEntity } from './utils/products.types';
import { CommonApiService } from '../../api/common-api.service';
import { PoTableColumn } from '@po-ui/ng-components';
import { IPageableResult } from '../../api/common.types';

@Injectable({
  providedIn: 'root'
})
export class ProductsService extends CommonApiService {

  constructor(httpClient: HttpClient) {
    super('http://localhost:5070/api/v1/Products', httpClient)
   }

   
  getProductById(id: number): Observable<IProductEntity> {
    return this.findById<IProductEntity>(id)
  }
  
  createProduct(entity: IProductEntity): Observable<any> {
    return this.insert<IProductEntity, any>(entity);
  }

  editProduct(entity: IProductEntity): Observable<any> {
    return this.update<IProductEntity, any>(entity);
  }

  deleteProduct(id: number): Observable<any> {
    return this.delete<any>(id);
  }

  listAll(): Observable<IProduct[]>{
    return this.list<IProduct[]>();
  }
  
  paginable(filter: IProductsListFilter ): Observable<IPageableResult<IProduct>> {
    return this.pageableList<IProductsListFilter,IPageableResult<IProduct>>(filter);
  }

  getColumns(): Array<PoTableColumn> {
    return [
      { property: 'id', label: 'Código', type: 'number', width: '8%' },
      { property: 'name', label: 'Produto' },
      { property: 'description', label: 'Descrição' },
      { property: 'price', label: 'Preço', type: 'currency', format: 'BRL' },
      { property: 'category', label: 'Categoria' },
    ]
  }

}

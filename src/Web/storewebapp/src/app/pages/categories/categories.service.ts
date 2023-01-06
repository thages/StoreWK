import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PoTableColumn } from '@po-ui/ng-components';
import { Observable } from 'rxjs';
import { CommonApiService } from '../../api/common-api.service';
import { ICategory } from './utils/categories.types';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService extends CommonApiService {

  constructor(httpClient: HttpClient) {
    super('http://localhost:5070/api/v1/Categories', httpClient)
   }

  getCategoryById(id: number): Observable<ICategory> {
    return this.findById<ICategory>(id)
  }
  
  createCategory(entity: ICategory): Observable<any> {
    return this.insert<ICategory, any>(entity);
  }

  editCategory(entity: ICategory): Observable<any> {
    return this.update<ICategory, any>(entity);
  }

  deleteCategory(id: number): Observable<any> {
    return this.delete<any>(id);
  }

  listAll(): Observable<ICategory[]>{
    return this.list<ICategory[]>();
  }
  
  getColumns(): Array<PoTableColumn> {
    return [
      { property: 'id', label: 'Código', type: 'number', width: '8%' },
      { property: 'name', label: 'Produto' },
      { property: 'description', label: 'Descrição' }
    ]
  }
}

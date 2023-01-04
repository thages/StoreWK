import { HttpClient } from '@angular/common/http';
import {  Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonApiService {
  protected path: string;
  
  constructor(@Inject(String) path: string, protected httpClient: HttpClient) {
    this.path = path;
  }

  list<T>(filter: T): Observable<any> {
    try {
      return this.httpClient.post(`${this.path}/pageable-list`, filter);
    } catch (e: any) {
      return handleErrors(e);
    }
  }

}

const handleErrors = (e: any) => {
  const errors = Object.keys(e.errors);

  errors.forEach((error) => {
    console.error(error);
  })

  throw new Error(e as any);
}



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

  protected findById<T>(id: number): Observable<T> {
    try {
      return this.httpClient.get<T>(`${this.path}/${id}`);
    } catch (e: any) {
      return handleErrors(e);
    }
  }

  protected insert<T, U>(entity: T): Observable<U> {
    try {
      return this.httpClient.post<U>(`${this.path}/create`, entity);
    } catch (e: any) {
      return handleErrors(e);
    }
  }

  protected update<T, U>(entity: T): Observable<U> {
    try {
      return this.httpClient.put<U>(`${this.path}/update`, entity);
    } catch (e: any) {
      return handleErrors(e);
    }
  }

  protected delete<T>(id: number): Observable<T> {
    try {
      return this.httpClient.delete<T>(`${this.path}/${id}`);
    } catch (e: any) {
      return handleErrors(e);
    }
  }

  protected list<T>(): Observable<T> {
    try {
      return this.httpClient.get<T>(`${this.path}/list`);
    } catch (e: any) {
      return handleErrors(e);
    }
  }

  protected pageableList<T, U>(filter: T): Observable<U> {
    try {
      return this.httpClient.post<U>(`${this.path}/pageable-list`, filter);
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



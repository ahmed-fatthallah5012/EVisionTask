import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerFilter } from '../models/customer-filter.model';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  readonly baseUrl = 'https://localhost:5001/Customer';
  list: Customer[] = [];

  constructor(private http: HttpClient) { }

  refreshList(): void {
    this.http.get(this.baseUrl).toPromise().then(res => this.list = res as Customer[]);
  }
}

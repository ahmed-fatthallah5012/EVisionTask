import { Component, OnInit } from '@angular/core';
import { CustomerFilter } from 'src/shared/models/customer-filter.model';
import { Customer } from 'src/shared/models/customer.model';
import { CustomerService } from 'src/shared/services/customer-service.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  status = false;
  searchText = '';
  list: Customer[] = [];
  constructor(public service: CustomerService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  onChangeEvent(searchValue: string): void {
    this.searchText = searchValue;
  }
  onRefresh(): void{
    this.service.refreshList();
  }
}

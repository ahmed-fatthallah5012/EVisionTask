import { Component, Input, OnInit } from '@angular/core';
import { Customer } from 'src/shared/models/customer.model';

@Component({
  selector: 'app-customer-card',
  templateUrl: './customer-card.component.html',
  styleUrls: ['./customer-card.component.css']
})
export class CustomerCardComponent implements OnInit {

  displayedColumns: string[] = ['vehicleId', 'registerNumber', 'showStatus'];
  @Input() customer: Customer = new Customer();
  @Input() status = false;
  constructor() { }

  ngOnInit(): void {
  }

}

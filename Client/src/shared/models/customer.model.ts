import { Vehicle } from './vehicle.model';

export class Customer {
    cutomerId = 0;
    customerName = '';
    address = '';
    vehicles: Vehicle[] = [];
}

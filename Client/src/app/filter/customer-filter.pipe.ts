import { Pipe, PipeTransform } from '@angular/core';
import { Customer } from 'src/shared/models/customer.model';

@Pipe({
  name: 'customerFilter'
})
export class CustomerFilterPipe implements PipeTransform {

  transform(items: Customer[], searchText: string): Customer[] {
    if (!items) {
      return [];
    }
    if (!searchText) {
      return items;
    }
    searchText = searchText.toLocaleLowerCase();

    return items.filter(it => {
      return it.customerName.toLocaleLowerCase().includes(searchText);
    });
  }

}

import { Pipe, PipeTransform } from '@angular/core';
import { Vehicle } from 'src/shared/models/vehicle.model';

@Pipe({
  name: 'vehicleFilter'
})
export class VehicleFilterPipe implements PipeTransform {

  transform(items: Vehicle[], hasStatus: boolean): Vehicle[] {
    if (!items) {
      return [];
    }
    if (!hasStatus) {
      return items;
    }

    return items.filter(it => {
      return it.showStatus === hasStatus;
    });
  }

}

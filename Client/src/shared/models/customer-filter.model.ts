export class CustomerFilter {
    customerId = 0;
    customerName = '';
    hasVehicleStatus = false;
    constructor(customerId?: number , customerName?: string , hasVehicle?: boolean) {
        if (customerId) {
            this.customerId = customerId;
        }
        if (customerName) {
            this.customerName = customerName;
        }
        if (hasVehicle) {
            this.hasVehicleStatus = hasVehicle;
        }
    }

}

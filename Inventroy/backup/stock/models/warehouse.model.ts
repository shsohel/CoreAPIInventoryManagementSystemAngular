export class Warehouse {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public warehouseNo: string;
    public name: string;    
    public description: string;
    public address: string;
    public contactPerson: string;
    public mobileNo: string;
    public email: string;
    public isDefault: boolean;
    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
    public status: number;
}      
export class WarehouseDetails extends Warehouse {    
    public createdByName: string;
    public createdDateString: string;
    public updatedByName: string;
    public updatedDateString: string;
}
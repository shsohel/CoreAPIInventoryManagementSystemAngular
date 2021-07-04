export class Supplier {
    public id: number;    
    public organizationId: number;
    public shopId: number;    
    public supplierNo: string;
    public name: string;   
    public email : string;
    public contactPerson: string;
    public contactNumber: string;
    public description: string;
    public createdBy: string;
    public createdDate: Date;
    public modifiedBy: string;
    public modifiedDate: Date;
    public status: number;
}
export class SupplierDetails extends Supplier {
    public modifiedByName: string;
    public createdByName: string;
    public createdDateString: string;
    public modifiedDateString: string;
}
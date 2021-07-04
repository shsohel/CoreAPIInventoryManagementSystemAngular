export class Vendor {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public vendorNo: number;
    public name: string;
    public email:string;
    public guarantorId: number;
    public mobileNo: string;
    public address: string;
    public registrationNo: string;
    public tin: string;
    public creditLimit: number;
    public discountPercent: number;
    public dayOfPayment: string;
    public picture: string;
    public createdBy: string;
    public createdDate: Date;
    public modifiedBy: string;
    public modifiedDate: Date;
    public status: number;
}
export class VendorDetails extends Vendor {
    public gurantorName: string;
    public createdByName: string;
    public modifiedByName: string;
    public modifiedDateString: string;
    public createdDateString: string;
}
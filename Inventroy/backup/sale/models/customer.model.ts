export class Customer {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public customerNo: string;
    public name: string;
    public mobile: string;
    public address: string;
    public createdBy: string;
    public createdDate: Date;
    public modifiedBy: string;
    public modifiedDate: Date;
    public status: number;
}
export class CustomerDetails extends Customer{
    public createdByName: string;
    public modifiedByName: string;
    public modifiedDateString: string;
    public createdDateString: string;
}
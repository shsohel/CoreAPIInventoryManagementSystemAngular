export class Shop {
    public id: number;
    public organizationId: number;
    public code: string;
    public name: string;
    public owner: string;
    public designation: string;
    public address1: string;
    public address2: string;
    public phone: string;
    public vatRegNo: string;
    public emailForSystemGeneratedMail: string;
    public passwordForSystemGeneratedMail: string;
    public createdBy: string;
    public createdDate: Date;
    public modifiedBy: string;
    public modifiedDate: Date;
    public status: number;
    
}
export class ShopDetails extends Shop{
    public modifiedByName: string;
    public createdByName: string;
    public createdDateString: string;
    public modifiedDateString: string;
}
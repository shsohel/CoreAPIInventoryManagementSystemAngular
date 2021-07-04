export class BusinessRelative {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public businessRelativeNo: string;
    public name: string;
    public relationshipId: string;
    public description: string;
    public address : string;
    public mobileNo : string;
    public email: string;
    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
    public status: number;
}
export class BusinessRelativeDetails extends BusinessRelative {
    public relationshipName: string;
    public createdByName: string;
    public createdDateString: string;
    public updatedByName: string;
    public updatedDateString: string;
}
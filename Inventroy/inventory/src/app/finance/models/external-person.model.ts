export class ExternalPerson {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public externalPersonNo: string;
    public name: string;
    public fathersName: string;
    public mobileNo: string;
    public email: string;
    public relationshipId: number;
    public address: string;
    public capturedBy: string;
    public capturedDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
    public status: number;
}
export class ExternalPersonDetails extends ExternalPerson {
    public relationshipName: string;
    public capturedByName: string;
    public capturedDateString: string;
    public updatedByName: string;
    public updatedDateString: string;
}
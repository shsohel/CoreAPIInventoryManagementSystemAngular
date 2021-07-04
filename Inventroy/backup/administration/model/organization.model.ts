export class Organization {
    public id: number;
    public organizationNo: string;
    public organizationTypeId: number;
    public name: string;
    public founderName: string;
    public establishedOn: Date;
    public telephoneNo: string;
    public mobileNo: string;
    public email: string;
    public webAddress: string;
    public registrationNo: string;
    public registeredDate: Date;
    public addressVillageHouse: string;
    public addressRoadBlockSector: string;
    public addressPostOffice: number;
    public addressPostCode: string;
    public addressUpazila: number;
    public addressDistrict: number;
    public addressCountry: number;
    public logoImage: string;
    public nameCardImage: string;
    public logoImageName: string;
    public nameCardImageName: string;
    public status: number;
}
export class OrganizationDetails extends Organization {
    public capturedBy: number;
    public capturedDate: string;
    public updatedBy: number;
    public updatedDate: string
}
export class OrgImageDocumentDetails{
    public logoImage: string;
    public nameCardImage: string;
    public logoImageName: string;
    public nameCardImageName: string;
}

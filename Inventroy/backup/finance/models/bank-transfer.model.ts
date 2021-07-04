export class BankTransfer {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public bankTransferNo: string;
    public bankAccountId: number;
    public responsiblePersonId: number;
    public transferPurpose : number;
    public amount: number;
    public requestedBy: string;
    public requestedDate: Date;
    public note: string;
    public withdraw: number;
    public deposit: number;
    public rejectedBy: string;
    public rejectedDate: Date;
    public rejectedReason: string;
    public approvedBy: string;
    public approvedDate: Date;
    public capturedBy: string;
    public capturedDate: Date;
    public canceledBy: string;
    public canceledDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
    public status: number;
}  
export class BankTransferDetails extends BankTransfer {
    public responsiblePersonName: string;
    public approvedByName: string;
    public capturedByName: string;
    public canceledByName: string;
    public updatedByName: string;
    public rejectedByName: string;
    public rejectedDateString: string;
    public requestedByName: string;
    public requestedDateString: string;
    public approvedDateString: string;
    public capturedDateString: string;
    public canceledDateString: string;
    public updatedDateString: string;
}
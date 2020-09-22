export class InternalTransfer {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public internalTransferNo : string;
    public sentBy: string;
    public sentDate: Date;
    public sentTo: string;
    public amount: number;
    public note: string;
    public rejectReason: string;
    public approvedBy: string;
    public approveDate: Date;
    public capturedBy: string;
    public capturedDate: Date;
    public updatedBy: string;
    public updateDate: Date;
    public canceledBy: string;
    public canceledDate: Date;
    public status: number;
}
export class InternalTransferDetails extends InternalTransfer {
    public sentByName: string;
    public sentToName: string;
    public sentDateString: string;
    public approveByName: string;
    public capturedByName: string;
    public cancelByName: string;
    public updateByName: string;
    public approveDateString: string;
    public capturedDateString: string;
    public cancelDateString: string;
    public updateDateString: string;
}
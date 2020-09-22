export class BankAccount {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public bankAccountNo: string;
    public bankName: string;
    public branchName: string;
    public accountName : string;
    public accountNo : string;
    public accountType: number;
    public transectionType: number;
    public capturedBy: string;
    public capturedDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
    public status: number;
}
export class BankAccountDetails extends BankAccount {
    public accountTypeName: string;
    public transectionTypeName: string;
    public updatedByName: string;
    public capturedByName: string;
    public capturedDateString: string;
    public updatedDateString: string;
}
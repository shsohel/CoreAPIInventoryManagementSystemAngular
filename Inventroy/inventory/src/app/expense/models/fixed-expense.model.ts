export class FixedExpense {
    public id: number;
    public organizationId: number;
    public shopId: number;    
    public fixedExpenseNo: string;
    public serviceProviderId : number;
    public expenseHeadId: number;    
    public voucherId: number;
    public fixedExpenseDate: Date;
    public note: string;
    public amount: number;
    public updatedBy: string;
    public capturedDate: Date;
    public capturedBy: string;
    public updatedDate: Date;
    public status: number;
}  
export class FixedExpenseDetails extends FixedExpense {
    public serviceProviderName: string;
    public expenseHeadName: string;
    public createdByName: string;
    public createdDateString: string;    
    public updatedByName: string;
    public updatedDateString: string;
}
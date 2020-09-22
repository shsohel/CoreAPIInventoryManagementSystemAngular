export class GeneralExpense {
    public id: number;
    public organizationId: number;
    public shopId: number;    
    public generalExpenseNo: string;
    public expenseHeadId: number;    
    public voucherId: number;
    public generalExpenseDate: Date;
    public note: string;
    public amount: number;
    public updatedBy: string;
    public captureDate: Date;
    public captureBy: string;
    public updatedDate: Date;
    public status: number;
}  
export class GeneralExpenseDetails extends GeneralExpense {
    public expenseDateString :string;
    public expenseHeadName: string;
    public createdByName: string;
    public createdDateString: string;    
    public updatedByName: string;
    public updatedDateString: string;
}
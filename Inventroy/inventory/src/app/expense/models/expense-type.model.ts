export class ExpenseType {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public expenseTypeNo: string;
    public name: string;
    public description: string;
    public isFixed: boolean;
    public createdBy: string;
    public createdDate: Date;
    public modifiedBy: string;
    public modifiedDate: Date;
    public status: number;
    
}
export class ExpenseTypeDetails extends ExpenseType{
    public createdByName: string;
    public createdDateString: string;
    public modifiedByName: string;
    public modifiedDateString: string;
}
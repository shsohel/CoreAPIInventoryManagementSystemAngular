export class ExpenseHead {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public expenseHeadNo: string;
    public expenseTypeId: number;
    public parentId: number;
    public name: string;
    public description: string;
    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedByDate: Date;
    public status: number;
    
}
export class ExpenseHeadDetails extends ExpenseHead{
    public expenseTypeName: string;
    public parentTypeName: string;
    public createdByName: string;
    public createdDateString: string;
    public updatedByName: string;
    public updatedDateString: string;
}
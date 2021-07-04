export class FixedExpenseSetting {
    public id: number;
    public organizationId: number;
    public shopId: number;    
    public fixedExpenseSettingNo: string;
    public serviceProviderId : number;
    public expenseHeadId: number;    
    public validFrom: Date;
    public validTo: Date;
    public amount: number;
    public payableType: number;
    public note: string;    
    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedDate: Date;
    public status: number;
}  
export class FixedExpenseSettingDetails extends FixedExpenseSetting {
    public serviceProviderName: string;
    public expenseHeadName: string;
    public validFromString: string;
    public validToString: string;
    public paybleTypeName: string;
    public createdByName: string;
    public createdDateString: string;    
    public updatedByName: string;
    public updatedDateString: string;
}
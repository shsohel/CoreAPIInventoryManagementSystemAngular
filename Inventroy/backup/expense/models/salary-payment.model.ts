export class SalaryPayment {
    public id: number;
    public organizationId: number;
    public shopId: number;    
    public salaryPaymentNo: string;
    public employeeId: number;
    public expenseHeadId: number;    
    public voucherId: number;
    public salaryPaymentDate: Date;
    public note: string;
    public paidAmount: number;
    public updatedBy: string;
    public capturedDate: Date;
    public capturedBy: string;
    public updatedDate: Date;
    public status: number;
}  
export class SalaryPaymentDetails extends SalaryPayment {
    public employeeName : string;
    public salaryPaymentDateString :string;
    public expenseHeadName: string;
    public createdByName: string;
    public createdDateString: string;    
    public updatedByName: string;
    public updatedDateString: string;
}
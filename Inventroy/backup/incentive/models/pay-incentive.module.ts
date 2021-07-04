export class PayIncentive {
    public id: number;
    public organizationId: number;
    public shopId: number;
    public payIncentiveNo: string;
    public incentiveType: number;
    public paidToId: number;
    public paymentType: number;
    public responsibleEmpId: number;
    public paymentDate: Date;
    public amount: number;
    public createdBy: string;
    public createdDate: Date;
    public updatedBy: string;
    public updatedByDate: Date;
    public status: number;
}
export class PayIncentiveDetails extends PayIncentive {
    public paymentTypeName: string;
    public incentiveTypeName: string;
    public paidToName: string;
    public paymentDateString: string;
    public responsibleEmpName: string;
    public createdByName: string;
    public createdDateString: string;
    public updatedByName: string;
    public updatedDateString: string;
}
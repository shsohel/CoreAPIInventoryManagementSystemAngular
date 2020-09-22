export class Purchase {
    public id: number;    
    public organizationId: number;
    public shopId: number;    
    public purchaseOrderId: number;
    public purchaseNo: string;   
    public wareHouseId : number;
    public systemDate: Date;
    public supplierId: number;
    public paidByEmpId: number;
    public responsibleEmpId: number;
    public date: Date;   
    public note : string;    
    public paidAmount: number;
    public amount: number;
    public transportCost: number;   
    public labourCost : number;
    public vat:number ;
    public othersCost : number;
    public isLocked:boolean ;
    public isWarehoused: boolean;
    public createdBy: string;
    public createdDate: Date;
    public modifiedBy: string;
    public modifiedDate: Date;
    public status: number;
}
export class PurchaseDetails extends Purchase {    
    public supplierName: string;
    public paidByEmpName: string;
    public responsibleEmpName: string;
    public dateString: string;
    public createdByName: string;
    public createdDateString: string;
    public modifiedByName: string;
    public modifiedDateString: string;
}
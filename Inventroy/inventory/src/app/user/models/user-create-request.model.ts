export class UserCreateRequest {
    requestId: number;
    employeeId: number;
    userType: number;
    status: number;
    requestBy: string;
    requestDate: Date;
    shopId: number;
    shopName:string;
    userTypeName:string;
    userName:string;
    updatedBy: string;
    updatedDate: Date;
    url: string;
    varificationCode: string;
    email: string;
    mobileNo: string;
}
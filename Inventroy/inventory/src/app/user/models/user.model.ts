export class User {
    public phoneNumber: string;
    public password: string;
    public email: string;
    public userName: string;
}
export class UserDetails extends User {
    public shopId: number;
    public organizationId: number;
    public employeeId: number;
    public userType: number;
    public profilePicture: string;
}
import { UserType } from './user-type.model';
import { User } from './user.model';
import { Shop } from 'src/app/administration/model/shop.model';
import { Employee } from 'src/app/administration/model/employee.model';

export class UserCreateData{
    userTypes: Array<UserType> = new Array<UserType>();
    shops: Array<Shop> = new Array<Shop>();
    employees: Array<Employee> = new Array<Employee>();
}
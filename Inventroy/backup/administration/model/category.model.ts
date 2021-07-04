export class Category {
    public id: number;
    public parentId: number;
    public categoryNo:string;
    public priority: number;
    public name: string;
    public description: string;
}
export class CategoryDetails extends Category {
    public createdBy: number;
    public createdDate: string;
    public modifiedBy: number;
    public modifiedDate: string;
    public status: number
}


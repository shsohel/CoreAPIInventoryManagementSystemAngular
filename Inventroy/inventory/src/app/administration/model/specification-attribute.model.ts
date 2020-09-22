export class SpecificationAttribute {
    public id: number;
    public name: string;
    public attributeNo: string;
    public sequence: number;
    public status: number;
}
export class SpecificationAttributeValue {
    public id: number;
    public specificationAttrId: number;
    public attributeValueNo: string;
    public attrValue: string;
    public status: number;
}
export class CreateAttrValue {
    public specificationAttrValueViewModels: Array<SpecificationAttributeValue>;
}
export class AttributeDetails{
    public specificationAttribute:any;
    public specificationAttrValues:any;
}

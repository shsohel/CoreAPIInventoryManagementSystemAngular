export class ProductAttribute {
    public id: number;
    public productItemId: number;
    public specificationAttrId: number;
    public specificationAttrValueId: number;
    public sequenceNo: number;
    public priceAdjustment: number;
    public weightAdjustment: number;
    public status: number;
}
export class CreateProductAttr {
    public mappingViewModels: Array<ProductAttribute>;
}

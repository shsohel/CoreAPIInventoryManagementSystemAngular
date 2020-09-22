using CommonDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonDAL
{
    public class OnlineContextDb : DbContext
    {
        public OnlineContextDb(DbContextOptions<OnlineContextDb> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BankAccount> BankAccount { get; set; }
        public virtual DbSet<ExternalPerson> ExternalPerson { get; set; }
        public virtual DbSet<BankTransfer> BankTransfer { get; set; }
        public virtual DbSet<UserCreateRequest> UserCreateRequest { get; set; }
        public virtual DbSet<BusinessRelative> BusinessRelative { get; set; }
        public virtual DbSet<ButtonAccess> ButtonAccess { get; set; }
        public virtual DbSet<Capital> Capital { get; set; }
        public virtual DbSet<CashCollection> CashCollection { get; set; }
        public virtual DbSet<CashPay> CashPay { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CheckInfo> CheckInfo { get; set; }
        public virtual DbSet<ContactPerson> ContactPerson { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<DeductionType> DeductionType { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DistrictUpazila> DistrictUpazila { get; set; }
        public virtual DbSet<DistrictPostOffice> DistrictPostOffice { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<DiscountAppliedToCategories> DiscountAppliedToCategories { get; set; }
        public virtual DbSet<DiscountAppliedToProductItems> DiscountAppliedToProductItems { get; set; }
        public virtual DbSet<DiscountAppliedToProducts> DiscountAppliedToProducts { get; set; }
        public virtual DbSet<DiscountDesOnPurchasAmount> DiscountDesOnPurchasAmount { get; set; }
        public virtual DbSet<DiscountDesProductSpecific> DiscountDesProductSpecific { get; set; }
        public virtual DbSet<DiscountUsageHistory> DiscountUsageHistory { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAddress> EmployeeAddress { get; set; }
        public virtual DbSet<EmployeeBasicInfo> EmployeeBasicInfo { get; set; }
        public virtual DbSet<EmployeeEduQual> EmployeeEduQual { get; set; }
        public virtual DbSet<EmployeeDocument> EmployeeDocument { get; set; }
        public virtual DbSet<EmployeeRefPersonDetails> EmployeeRefPersonDetails { get; set; }
        public virtual DbSet<EmployeeAllowance> EmployeeAllowance { get; set; }
        public virtual DbSet<EmployeeAttendance> EmployeeAttendance { get; set; }
        public virtual DbSet<ShiftSection> ShiftSection { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<ClassType> ClassType { get; set; }
        public virtual DbSet<Profession> Profession { get; set; }
        public virtual DbSet<RelationShip> RelationShip { get; set; }
        public virtual DbSet<Nationality> Nationality { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<ExpenseHead> ExpenseHead { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseType { get; set; }
        public virtual DbSet<ExternalTransfer> ExternalTransfer { get; set; }
        public virtual DbSet<ExtraServices> ExtraServices { get; set; }
        public virtual DbSet<FixedExpense> FixedExpense { get; set; }
        public virtual DbSet<FixedExpenseSetting> FixedExpenseSetting { get; set; }
        public virtual DbSet<GeneralExpense> GeneralExpense { get; set; }
        public virtual DbSet<FormAccess> FormAccess { get; set; }
        public virtual DbSet<FormGroup> FormGroup { get; set; }
        public virtual DbSet<IncentivePay> IncentivePay { get; set; }
        public virtual DbSet<IncentiveSettings> IncentiveSettings { get; set; }
        public virtual DbSet<InitialProductStock> InitialProductStock { get; set; }
        public virtual DbSet<InitialValues> InitialValues { get; set; }
        public virtual DbSet<InternalTransfer> InternalTransfer { get; set; }
        public virtual DbSet<Journal> Journal { get; set; }
        public virtual DbSet<Ledger> Ledger { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<MonthlyFixedExpenseSettings> MonthlyFixedExpenseSettings { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<PayIncentive> PayIncentive { get; set; }
        public virtual DbSet<PriceType> PriceType { get; set; }
        public virtual DbSet<ProducedReceived> ProducedReceived { get; set; }
        public virtual DbSet<ProducedReceivedItem> ProducedReceivedItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductAttributeMapping> ProductAttributeMapping { get; set; }
        public virtual DbSet<Production> Production { get; set; }
        public virtual DbSet<ProductionExpense> ProductionExpense { get; set; }
        public virtual DbSet<ProductionExpenseAndExpenseMapping> ProductionExpenseAndExpenseMapping { get; set; }
       public virtual DbSet<ProductionExpenseSettings> ProductionExpenseSettings { get; set; }
        public virtual DbSet<ProductionProduct> ProductionProduct { get; set; }
        public virtual DbSet<ProductionProductSettings> ProductionProductSettings { get; set; }
        public virtual DbSet<ProductionRawProduct> ProductionRawProduct { get; set; }
        public virtual DbSet<ProductionRawSettings> ProductionRawSettings { get; set; }
        public virtual DbSet<ProductionType> ProductionType { get; set; }
        public virtual DbSet<ProductItem> ProductItem { get; set; }
        public virtual DbSet<VAT> VAT { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseItem> PurchaseItem { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderItem> PurchaseOrderItem { get; set; }
        public virtual DbSet<PurchasePrice> PurchasePrice { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<SalaryGeneration> SalaryGeneration { get; set; }
        public virtual DbSet<SalaryGenerationDetail> SalaryGenerationDetail { get; set; }
        public virtual DbSet<SalarySettings> SalarySettings { get; set; }
        public virtual DbSet<SalaryPayment> SalaryPayment { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesItem> SalesItem { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<SalesOrderItem> SalesOrderItem { get; set; }
        public virtual DbSet<SalesPrice> SalesPrice { get; set; }
        public virtual DbSet<SalesReturn> SalesReturn { get; set; }
        public virtual DbSet<SalesReturnItem> SalesReturnItem { get; set; }
        public virtual DbSet<SalesSalesServiceMapping> SalesSalesServiceMapping { get; set; }
        public virtual DbSet<SalesServiceType> SalesServiceType { get; set; }
        public virtual DbSet<SerialProductItem> SerialProductItem { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<SpecificationAttribute> SpecificationAttribute { get; set; }
        public virtual DbSet<SpecificationAttrValue> SpecificationAttrValue { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<StockDeduction> StockDeduction { get; set; }
        public virtual DbSet<StockDeductionItem> StockDeductionItem { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        // public virtual DbSet<Tax> Tax { get; set; }
        public virtual DbSet<TaxAmount> TaxAmount { get; set; }
        public virtual DbSet<Thana> Thana { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UserDefinedInfo> UserDefinedInfo { get; set; }
        public virtual DbSet<UserDefinedInfoMapping> UserDefinedInfoMapping { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<UserTypeButtonNotAccess> UserTypeButtonNotAccess { get; set; }
        public virtual DbSet<UserTypeFormAccess> UserTypeFormAccess { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehouseAdjustment> WarehouseAdjustment { get; set; }
        public virtual DbSet<WarehouseAdjustmentDetail> WarehouseAdjustmentDetail { get; set; }
        public virtual DbSet<WareHouseProductItem> WareHouseProductItem { get; set; }
        public virtual DbSet<WarehouseTransaction> WarehouseTransaction { get; set; }
        public virtual DbSet<WarehouseTransactionDetail> WarehouseTransactionDetail { get; set; }
        public virtual DbSet<WareHouseTransfer> WareHouseTransfer { get; set; }
        public virtual DbSet<WarehouseTransferDetail> WarehouseTransferDetail { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IMSERP.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShopId = table.Column<int>(nullable: false),
                    ReferenceType = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<int>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    BankAccountNo = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: true),
                    AccountName = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    AccountType = table.Column<byte>(nullable: true),
                    TransectionType = table.Column<byte>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    BankTransferNo = table.Column<string>(nullable: true),
                    BankAccountId = table.Column<int>(nullable: false),
                    TransferPurpose = table.Column<byte>(nullable: true),
                    ResponsiblePersonId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Deposit = table.Column<decimal>(nullable: true),
                    Withdraw = table.Column<decimal>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: true),
                    RequestedDate = table.Column<DateTime>(nullable: true),
                    CanceledBy = table.Column<string>(nullable: true),
                    CanceledDate = table.Column<DateTime>(nullable: true),
                    RejectedBy = table.Column<string>(nullable: true),
                    RejectedDate = table.Column<DateTime>(nullable: true),
                    RejectReason = table.Column<string>(nullable: true),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessRelative",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    BusinessRelativeNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RelationshipId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessRelative", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ButtonAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormAccessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyOfButton = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ButtonAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capital",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    IsInitial = table.Column<bool>(nullable: false),
                    Deposite = table.Column<decimal>(nullable: false),
                    Withdraw = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashCollection",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalesId = table.Column<long>(nullable: false),
                    SalesReturnId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CustomerId = table.Column<long>(nullable: false),
                    CollectionPersonId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CheckInfoId = table.Column<long>(nullable: false),
                    BankTransferId = table.Column<long>(nullable: true),
                    Instrument = table.Column<string>(nullable: true),
                    IsAdjustment = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashPay",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    PurchasId = table.Column<long>(nullable: false),
                    PurchasReturnId = table.Column<long>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    SupplierId = table.Column<int>(nullable: false),
                    PaidByEmpId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CheckInfoId = table.Column<long>(nullable: false),
                    BankTransferId = table.Column<long>(nullable: true),
                    IsAdjustment = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashPay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    CategoryNo = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    CheckNo = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    CheckDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassTypeName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactPerson",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ReferenceType = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<int>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPerson", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    CustomerNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeductionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DesignationName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DiscountType = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    DiscountTkamountLimit = table.Column<decimal>(nullable: false),
                    DiscountProuductLimit = table.Column<decimal>(nullable: false),
                    ProductUnitType = table.Column<int>(nullable: false),
                    IsRunningOrPostPont = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountAppliedToCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    PriceTypeId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountAppliedToCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountAppliedToProductItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountId = table.Column<long>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    PriceType = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountAppliedToProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountAppliedToProducts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    PriceTypeId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountAppliedToProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountDesOnPurchasAmount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountId = table.Column<long>(nullable: false),
                    PurchasedAmountToBe = table.Column<decimal>(nullable: false),
                    IsPercent = table.Column<bool>(nullable: false),
                    FreeAmount = table.Column<decimal>(nullable: false),
                    TotalFreedAmount = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountDesOnPurchasAmount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountDesProductSpecific",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountId = table.Column<long>(nullable: false),
                    PurchasAmountToBe = table.Column<decimal>(nullable: false),
                    PurchasAmountToBeType = table.Column<int>(nullable: false),
                    FreeType = table.Column<int>(nullable: false),
                    DiscountTkamount = table.Column<decimal>(nullable: false),
                    DiscountProductAmount = table.Column<decimal>(nullable: false),
                    DiscountProductUnit = table.Column<int>(nullable: false),
                    FreedProductItemId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountDesProductSpecific", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountUsageHistory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountId = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    SalesId = table.Column<long>(nullable: false),
                    FreeType = table.Column<int>(nullable: false),
                    DiscountedTkamount = table.Column<decimal>(nullable: false),
                    DiscountedProductAmount = table.Column<decimal>(nullable: false),
                    DiscountedProductUnit = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountUsageHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DivisionId = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistrictPostOffice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictId = table.Column<int>(nullable: true),
                    UpazilaName = table.Column<string>(nullable: true),
                    PostOfficeName = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictPostOffice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistrictUpazila",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DistrictId = table.Column<int>(nullable: false),
                    UpazilaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictUpazila", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeNo = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    IsOwner = table.Column<bool>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Designation = table.Column<int>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    ResidanceMobileNo = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    JoiningDate = table.Column<DateTime>(nullable: true),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    SalaryTypeId = table.Column<byte>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<long>(nullable: true),
                    PresentVillageHouse = table.Column<string>(nullable: true),
                    PresentRoadBlockSector = table.Column<string>(nullable: true),
                    PresentPostOffice = table.Column<int>(nullable: true),
                    PresentPostCode = table.Column<string>(nullable: true),
                    PresentUpazila = table.Column<int>(nullable: true),
                    PresentDistrict = table.Column<int>(nullable: true),
                    PermanentVillageHouse = table.Column<string>(nullable: true),
                    PermanentRoadBlockSector = table.Column<string>(nullable: true),
                    PermanentPostOffice = table.Column<int>(nullable: true),
                    PermanentPostCode = table.Column<string>(nullable: true),
                    PermanentUpazila = table.Column<int>(nullable: true),
                    PermanentDistrict = table.Column<int>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAllowance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowanceNo = table.Column<string>(nullable: true),
                    AllowanceName = table.Column<string>(nullable: true),
                    PayableTypeId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAllowance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendance",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<long>(nullable: true),
                    SequenceId = table.Column<byte>(nullable: true),
                    ShiftSectionId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBasicInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<long>(nullable: true),
                    FathersName = table.Column<string>(nullable: true),
                    FathersProfession = table.Column<byte>(nullable: true),
                    MothersName = table.Column<string>(nullable: true),
                    MothersProfession = table.Column<byte>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    ReligionId = table.Column<byte>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    CitizenShipStatusId = table.Column<byte>(nullable: true),
                    CountryOfBirthId = table.Column<int>(nullable: true),
                    DistictOfBirthId = table.Column<int>(nullable: true),
                    GenderId = table.Column<byte>(nullable: true),
                    BirthRegNo = table.Column<string>(nullable: true),
                    NationalIdno = table.Column<string>(nullable: true),
                    PassportNo = table.Column<string>(nullable: true),
                    Hight = table.Column<int>(nullable: true),
                    BloodGroupId = table.Column<byte>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBasicInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocument",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<long>(nullable: true),
                    DocumentName = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEduQual",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<long>(nullable: false),
                    RegistrationNo = table.Column<string>(nullable: true),
                    RollNo = table.Column<string>(nullable: true),
                    BoardorUniversity = table.Column<byte>(nullable: true),
                    SubjectId = table.Column<byte>(nullable: true),
                    ClassTypeId = table.Column<int>(nullable: true),
                    PassingYear = table.Column<DateTime>(nullable: false),
                    Result = table.Column<byte>(nullable: true),
                    ResultCgpa = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEduQual", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRefPersonDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<long>(nullable: false),
                    ReletionShipId = table.Column<byte>(nullable: false),
                    RefPersonName = table.Column<string>(nullable: true),
                    ProfessionId = table.Column<byte>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: true),
                    DistictId = table.Column<int>(nullable: true),
                    PoliceStationId = table.Column<int>(nullable: true),
                    PostOffice = table.Column<int>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    RoadBlockSector = table.Column<string>(nullable: true),
                    HouseVillage = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRefPersonDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseHead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ExpenseHeadNo = table.Column<string>(nullable: true),
                    ExpenseTypeId = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseHead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpenseTypeId = table.Column<int>(nullable: false),
                    ExpenseHeadId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Responsible = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsAdjustmentPayment = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ExpenseTypeNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsFixed = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalPerson",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    ExternalPersonNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FathersName = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RelationshipId = table.Column<byte>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalPerson", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ExternalTransferNo = table.Column<string>(nullable: true),
                    BusinessRelativeId = table.Column<int>(nullable: true),
                    ExternalPersonId = table.Column<int>(nullable: true),
                    Received = table.Column<decimal>(nullable: true),
                    Paid = table.Column<decimal>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RejectedBy = table.Column<string>(nullable: true),
                    RejectedDate = table.Column<DateTime>(nullable: true),
                    RejectReason = table.Column<string>(nullable: true),
                    RequestedBy = table.Column<string>(nullable: true),
                    RequestedDate = table.Column<DateTime>(nullable: true),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: false),
                    CanceledBy = table.Column<string>(nullable: true),
                    CanceledDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraServices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceType = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsMendatory = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FixedExpense",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    FixedExpenseNo = table.Column<string>(nullable: true),
                    FixedExpenseDate = table.Column<DateTime>(nullable: true),
                    ServiceProviderId = table.Column<long>(nullable: true),
                    ExpenseHeadId = table.Column<int>(nullable: true),
                    VoucherId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FixedExpenseSetting",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    FixedExpenseSettingNo = table.Column<string>(nullable: true),
                    ExpenseHeadId = table.Column<int>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PayableType = table.Column<byte>(nullable: true),
                    ServiceProviderId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedExpenseSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FormGroupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyOfForm = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountHolderId = table.Column<int>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralExpense",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    GeneralExpenseNo = table.Column<string>(nullable: true),
                    GeneralExpenseDate = table.Column<DateTime>(nullable: false),
                    ExpenseHeadId = table.Column<int>(nullable: false),
                    VoucherId = table.Column<long>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncentivePay",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    DateForPaying = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Responsible = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncentivePay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncentiveSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SlabName = table.Column<string>(nullable: true),
                    SoldAmountMin = table.Column<decimal>(nullable: false),
                    SoldAmountMax = table.Column<decimal>(nullable: false),
                    UnitIdsold = table.Column<int>(nullable: false),
                    IncentiveAmount = table.Column<decimal>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CustomerType = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncentiveSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InitialProductStock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialProductStock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InitialValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<long>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsNegative = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    InternalTransferNo = table.Column<string>(nullable: true),
                    SentBy = table.Column<string>(nullable: true),
                    SentDate = table.Column<DateTime>(nullable: false),
                    SentTo = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RejectReason = table.Column<string>(nullable: true),
                    ApprovedBy = table.Column<string>(nullable: true),
                    ApproveDate = table.Column<DateTime>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    CanceledBy = table.Column<string>(nullable: true),
                    CanceledDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsShopBalanceEffected = table.Column<bool>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    TransactionTypeType = table.Column<int>(nullable: true),
                    TransactionTypeTypeSub = table.Column<int>(nullable: true),
                    PartyId = table.Column<long>(nullable: false),
                    PartyType = table.Column<int>(nullable: false),
                    PartyIdsecond = table.Column<long>(nullable: true),
                    PartyTypeSecond = table.Column<int>(nullable: true),
                    Paid = table.Column<decimal>(nullable: false),
                    Receive = table.Column<decimal>(nullable: false),
                    Particular = table.Column<string>(nullable: true),
                    TransactionBy = table.Column<string>(nullable: true),
                    TransactionByCode = table.Column<string>(nullable: true),
                    EventFrom = table.Column<int>(nullable: true),
                    IsAdjustment = table.Column<bool>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ledger",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LedgerNo = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ResponsibleEmpId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    TransactionById = table.Column<long>(nullable: false),
                    TransactionByCode = table.Column<string>(nullable: true),
                    IsDebit = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Particulars = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShopId = table.Column<int>(nullable: false),
                    SessionKey = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    LoginDateTime = table.Column<DateTime>(nullable: true),
                    LogoutDate = table.Column<DateTime>(nullable: true),
                    Ipaddress = table.Column<string>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Macaddress = table.Column<string>(nullable: true),
                    HostName = table.Column<string>(nullable: true),
                    InterfaceName = table.Column<string>(nullable: true),
                    Protocol = table.Column<string>(nullable: true),
                    PublicIp = table.Column<string>(nullable: true),
                    InterfaceDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ManufacturerNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyFixedExpenseSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ExpenseTypeId = table.Column<int>(nullable: false),
                    ExpenseHeadId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyFixedExpenseSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alpha2Code = table.Column<string>(nullable: true),
                    Alpha3Code = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    NationalityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationNo = table.Column<string>(nullable: true),
                    OrganizationTypeId = table.Column<byte>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FounderName = table.Column<string>(nullable: true),
                    EstablishedOn = table.Column<DateTime>(nullable: true),
                    TelephoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebAddress = table.Column<string>(nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: true),
                    AddressVillageHouse = table.Column<string>(nullable: true),
                    AddressRoadBlockSector = table.Column<string>(nullable: true),
                    AddressPostOffice = table.Column<int>(nullable: true),
                    AddressPostCode = table.Column<string>(nullable: true),
                    AddressUpazila = table.Column<int>(nullable: true),
                    AddressDistrict = table.Column<int>(nullable: true),
                    AddressCountry = table.Column<int>(nullable: true),
                    LogoImage = table.Column<string>(nullable: true),
                    NameCardImage = table.Column<string>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CapturedBy = table.Column<long>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayIncentive",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    PayIncentiveNo = table.Column<string>(nullable: true),
                    IncentiveType = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: true),
                    PaidToId = table.Column<long>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ResponsibleEmpId = table.Column<long>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayIncentive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducedReceived",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ResponsibleEmployeeId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducedReceived", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducedReceivedItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProducedReceivedId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducedReceivedItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeMapping",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    SpecificationAttrId = table.Column<int>(nullable: false),
                    SpecificationAttrValueId = table.Column<int>(nullable: false),
                    SequenceNo = table.Column<int>(nullable: true),
                    PriceAdjustment = table.Column<decimal>(nullable: false),
                    WeightAdjustment = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionNo = table.Column<string>(nullable: true),
                    BatchCode = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ExpiredDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RawProductCostTotal = table.Column<decimal>(nullable: false),
                    OtherCostTotal = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Production", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionExpense",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionId = table.Column<long>(nullable: false),
                    ProductionExpenseNo = table.Column<string>(nullable: true),
                    ExpenseTypeId = table.Column<int>(nullable: false),
                    ExpenseHeadId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<byte>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionExpense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionExpenseAndExpenseMapping",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductionExpenseId = table.Column<long>(nullable: false),
                    ExpenseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionExpenseAndExpenseMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionExpenseSettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionType = table.Column<int>(nullable: false),
                    ExpenseTypeId = table.Column<int>(nullable: false),
                    ExpenseHeadId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionExpenseSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionProduct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PriceEstimated = table.Column<decimal>(nullable: true),
                    PriceId = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionProductSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionType = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    PriceEstimated = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionProductSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRawProduct",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionId = table.Column<long>(nullable: false),
                    RawProductId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    PriceId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRawProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRawSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionType = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Amount = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRawSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductionTypeNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductItemNo = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    ProductType = table.Column<int>(nullable: false),
                    VATId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    IsSerialProduct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfessionName = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<long>(nullable: false),
                    PurchaseNo = table.Column<string>(nullable: true),
                    WareHouseId = table.Column<int>(nullable: true),
                    SupplierId = table.Column<long>(nullable: true),
                    PaidByEmpId = table.Column<long>(nullable: true),
                    ResponsibleEmpId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PaidAmount = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TransportCost = table.Column<decimal>(nullable: false),
                    LabourCost = table.Column<decimal>(nullable: false),
                    Vat = table.Column<decimal>(nullable: false),
                    OthersCost = table.Column<decimal>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsWarehoused = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    PurchasePriceId = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SystemDate = table.Column<DateTime>(nullable: false),
                    SupplierId = table.Column<int>(nullable: true),
                    ResponsibleEmpId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PurchaseOrderCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    IsProductReceived = table.Column<bool>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    PurchasePriceId = table.Column<int>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductItemId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Iscurrent = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationShip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelationShipName = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationShip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryGeneration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    DateOfGeneration = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryGeneration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryGenerationDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalaryGenerationId = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryGenerationDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryPayment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    SalaryPaymentNo = table.Column<string>(nullable: true),
                    ExpenseHeadId = table.Column<int>(nullable: true),
                    SalaryPaymentDate = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    VoucherId = table.Column<long>(nullable: true),
                    PaidAmount = table.Column<decimal>(nullable: true),
                    CapturedBy = table.Column<string>(nullable: true),
                    CapturedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalarySettings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarySettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WareHouseId = table.Column<int>(nullable: true),
                    SalesCode = table.Column<string>(nullable: true),
                    SalesOrderId = table.Column<long>(nullable: false),
                    SystemDate = table.Column<DateTime>(nullable: false),
                    SalesPersonId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    CounterNumber = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Vehicle = table.Column<string>(nullable: true),
                    DriverName = table.Column<string>(nullable: true),
                    MobileDriver = table.Column<string>(nullable: true),
                    AdditionalBill = table.Column<decimal>(nullable: true),
                    TransportCost = table.Column<decimal>(nullable: false),
                    LabourCost = table.Column<decimal>(nullable: false),
                    OthersCost = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    TotalDiscountProductWise = table.Column<decimal>(nullable: false),
                    DiscountExtra = table.Column<decimal>(nullable: true),
                    TotalVat = table.Column<decimal>(nullable: false),
                    TotalPayable = table.Column<decimal>(nullable: false),
                    TotalPriceInitial = table.Column<decimal>(nullable: false),
                    TotalDiscountProductWiseInitial = table.Column<decimal>(nullable: false),
                    DiscountExtraInitial = table.Column<decimal>(nullable: true),
                    TotalVatInitial = table.Column<decimal>(nullable: false),
                    TotalPayableInitial = table.Column<decimal>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    PreviousDue = table.Column<decimal>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    IsDispatched = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalesId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    QtyInitial = table.Column<decimal>(nullable: false),
                    QtyReturn = table.Column<decimal>(nullable: false),
                    PriceId = table.Column<int>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    DiscountId = table.Column<long>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    TaxAmountId = table.Column<long>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalesOrderCode = table.Column<string>(nullable: true),
                    SystemDate = table.Column<DateTime>(nullable: false),
                    SalesPersonId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    CounterNumber = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    TotalDiscount = table.Column<decimal>(nullable: false),
                    TotalVat = table.Column<decimal>(nullable: false),
                    TotalPayable = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalesOrderId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    PriceId = table.Column<int>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    DiscountId = table.Column<long>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    TaxAmountId = table.Column<long>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    PriceTypeId = table.Column<int>(nullable: true),
                    ProductItemId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Iscurrent = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturn",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SalesId = table.Column<long>(nullable: false),
                    SalesReturnCode = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalesOrderId = table.Column<long>(nullable: false),
                    SystemDate = table.Column<DateTime>(nullable: false),
                    SalesPersonId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false),
                    CounterNumber = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    DiscountProductwise = table.Column<decimal>(nullable: false),
                    TotalVat = table.Column<decimal>(nullable: false),
                    TotalPayable = table.Column<decimal>(nullable: false),
                    DiscountExtraDeduction = table.Column<decimal>(nullable: false),
                    CashCollectionId = table.Column<long>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesReturnItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    SalesReturnId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    PriceId = table.Column<int>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    DiscountId = table.Column<long>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    TaxAmountId = table.Column<long>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReturnItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesSalesServiceMapping",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ReferenceType = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<long>(nullable: false),
                    ExtraServicesId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesSalesServiceMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesServiceType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesServiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SerialProductItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    SerialNo = table.Column<string>(nullable: true),
                    PurchaseId = table.Column<long>(nullable: false),
                    SalesId = table.Column<long>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialProductItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftSection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ShiftSectionNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartTime = table.Column<TimeSpan>(nullable: true),
                    EndTime = table.Column<TimeSpan>(nullable: true),
                    ValidFrom = table.Column<DateTime>(nullable: true),
                    ValidTo = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    EmailForSystemGeneratedMail = table.Column<string>(nullable: true),
                    PasswordForSystemGeneratedMail = table.Column<string>(nullable: true),
                    VatRegNo = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttribute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    AttributeNo = table.Column<string>(nullable: true),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sequence = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttrValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecificationAttrId = table.Column<int>(nullable: false),
                    AttributeValueNo = table.Column<string>(nullable: true),
                    AttrValue = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttrValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    ChangeByType = table.Column<int>(nullable: false),
                    ChangedById = table.Column<string>(nullable: true),
                    ChangedByCode = table.Column<string>(nullable: true),
                    Qty = table.Column<decimal>(nullable: false),
                    ChangedQty = table.Column<decimal>(nullable: false),
                    IsIncreased = table.Column<bool>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockDeduction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    DeductionType = table.Column<int>(nullable: false),
                    ResponsibleEmpId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDeduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockDeductionItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    StockDeductionId = table.Column<long>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDeductionItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubjectName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<long>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    SupplierNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxAmount",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TaxId = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    IsPercent = table.Column<bool>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAmount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thana",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DevisionId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    Thana1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thana", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    UnitNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsInteger = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCreateRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    VarificationCode = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: true),
                    UserType = table.Column<int>(nullable: true),
                    RequestBy = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsVarified = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCreateRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDefinedInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReferenceType = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsMendatory = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefinedInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDefinedInfoMapping",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    ReferenceType = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<long>(nullable: false),
                    UserDefinedInfoId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDefinedInfoMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeButtonNotAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTypeId = table.Column<int>(nullable: false),
                    ButtonAccessId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeButtonNotAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeFormAccess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserTypeId = table.Column<int>(nullable: false),
                    FormAccessId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeFormAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VAT",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VatNo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsPercent = table.Column<bool>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    VendorNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    GuarantorId = table.Column<int>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RegistrationNo = table.Column<string>(nullable: true),
                    Tin = table.Column<string>(nullable: true),
                    CreditLimit = table.Column<decimal>(nullable: false),
                    DiscountPercent = table.Column<decimal>(nullable: false),
                    DayOfPayment = table.Column<DateTime>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WarehouseNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseAdjustment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WarehouseAdjustmentNo = table.Column<string>(nullable: true),
                    WareHouseId = table.Column<int>(nullable: false),
                    IsIn = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RequestBy = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseAdjustment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseAdjustmentDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WareHouseAdjustmentId = table.Column<long>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseAdjustmentDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseProductItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseProductItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseTransaction",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    TransactionType = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Responsible = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApporvedBy = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseTransaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseTransactionDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WarehouseTransactionId = table.Column<long>(nullable: false),
                    ReferenceType = table.Column<int>(nullable: false),
                    ReferenceParentId = table.Column<int>(nullable: false),
                    ReferenceId = table.Column<long>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Inqty = table.Column<decimal>(nullable: false),
                    OutQty = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseTransactionDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WareHouseTransfer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WareHouseTransferNo = table.Column<string>(nullable: true),
                    WareHouseIdfrom = table.Column<int>(nullable: false),
                    WareHouseIdto = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    RequestBy = table.Column<string>(nullable: true),
                    IsApproved = table.Column<bool>(nullable: false),
                    ApprovedBy = table.Column<string>(nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WareHouseTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseTransferDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    WareHouseTransferId = table.Column<long>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false),
                    Qty = table.Column<decimal>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    CapturedBy = table.Column<string>(nullable: true),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseTransferDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "BankTransfer");

            migrationBuilder.DropTable(
                name: "BusinessRelative");

            migrationBuilder.DropTable(
                name: "ButtonAccess");

            migrationBuilder.DropTable(
                name: "Capital");

            migrationBuilder.DropTable(
                name: "CashCollection");

            migrationBuilder.DropTable(
                name: "CashPay");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CheckInfo");

            migrationBuilder.DropTable(
                name: "ClassType");

            migrationBuilder.DropTable(
                name: "ContactPerson");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DeductionType");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "DiscountAppliedToCategories");

            migrationBuilder.DropTable(
                name: "DiscountAppliedToProductItems");

            migrationBuilder.DropTable(
                name: "DiscountAppliedToProducts");

            migrationBuilder.DropTable(
                name: "DiscountDesOnPurchasAmount");

            migrationBuilder.DropTable(
                name: "DiscountDesProductSpecific");

            migrationBuilder.DropTable(
                name: "DiscountUsageHistory");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "DistrictPostOffice");

            migrationBuilder.DropTable(
                name: "DistrictUpazila");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropTable(
                name: "EmployeeAllowance");

            migrationBuilder.DropTable(
                name: "EmployeeAttendance");

            migrationBuilder.DropTable(
                name: "EmployeeBasicInfo");

            migrationBuilder.DropTable(
                name: "EmployeeDocument");

            migrationBuilder.DropTable(
                name: "EmployeeEduQual");

            migrationBuilder.DropTable(
                name: "EmployeeRefPersonDetails");

            migrationBuilder.DropTable(
                name: "ExpenseHead");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "ExpenseType");

            migrationBuilder.DropTable(
                name: "ExternalPerson");

            migrationBuilder.DropTable(
                name: "ExternalTransfer");

            migrationBuilder.DropTable(
                name: "ExtraServices");

            migrationBuilder.DropTable(
                name: "FixedExpense");

            migrationBuilder.DropTable(
                name: "FixedExpenseSetting");

            migrationBuilder.DropTable(
                name: "FormAccess");

            migrationBuilder.DropTable(
                name: "FormGroup");

            migrationBuilder.DropTable(
                name: "GeneralExpense");

            migrationBuilder.DropTable(
                name: "IncentivePay");

            migrationBuilder.DropTable(
                name: "IncentiveSettings");

            migrationBuilder.DropTable(
                name: "InitialProductStock");

            migrationBuilder.DropTable(
                name: "InitialValues");

            migrationBuilder.DropTable(
                name: "InternalTransfer");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Ledger");

            migrationBuilder.DropTable(
                name: "LoginInfo");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "MonthlyFixedExpenseSettings");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "OrganizationType");

            migrationBuilder.DropTable(
                name: "PayIncentive");

            migrationBuilder.DropTable(
                name: "PriceType");

            migrationBuilder.DropTable(
                name: "ProducedReceived");

            migrationBuilder.DropTable(
                name: "ProducedReceivedItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductAttributeMapping");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "ProductionExpense");

            migrationBuilder.DropTable(
                name: "ProductionExpenseAndExpenseMapping");

            migrationBuilder.DropTable(
                name: "ProductionExpenseSettings");

            migrationBuilder.DropTable(
                name: "ProductionProduct");

            migrationBuilder.DropTable(
                name: "ProductionProductSettings");

            migrationBuilder.DropTable(
                name: "ProductionRawProduct");

            migrationBuilder.DropTable(
                name: "ProductionRawSettings");

            migrationBuilder.DropTable(
                name: "ProductionType");

            migrationBuilder.DropTable(
                name: "ProductItem");

            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItem");

            migrationBuilder.DropTable(
                name: "PurchasePrice");

            migrationBuilder.DropTable(
                name: "RelationShip");

            migrationBuilder.DropTable(
                name: "Salary");

            migrationBuilder.DropTable(
                name: "SalaryGeneration");

            migrationBuilder.DropTable(
                name: "SalaryGenerationDetail");

            migrationBuilder.DropTable(
                name: "SalaryPayment");

            migrationBuilder.DropTable(
                name: "SalarySettings");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "SalesItem");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "SalesOrderItem");

            migrationBuilder.DropTable(
                name: "SalesPrice");

            migrationBuilder.DropTable(
                name: "SalesReturn");

            migrationBuilder.DropTable(
                name: "SalesReturnItem");

            migrationBuilder.DropTable(
                name: "SalesSalesServiceMapping");

            migrationBuilder.DropTable(
                name: "SalesServiceType");

            migrationBuilder.DropTable(
                name: "SerialProductItem");

            migrationBuilder.DropTable(
                name: "ShiftSection");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "SpecificationAttribute");

            migrationBuilder.DropTable(
                name: "SpecificationAttrValue");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "StockDeduction");

            migrationBuilder.DropTable(
                name: "StockDeductionItem");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "TaxAmount");

            migrationBuilder.DropTable(
                name: "Thana");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "UserCreateRequest");

            migrationBuilder.DropTable(
                name: "UserDefinedInfo");

            migrationBuilder.DropTable(
                name: "UserDefinedInfoMapping");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "UserTypeButtonNotAccess");

            migrationBuilder.DropTable(
                name: "UserTypeFormAccess");

            migrationBuilder.DropTable(
                name: "VAT");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "WarehouseAdjustment");

            migrationBuilder.DropTable(
                name: "WarehouseAdjustmentDetail");

            migrationBuilder.DropTable(
                name: "WareHouseProductItem");

            migrationBuilder.DropTable(
                name: "WarehouseTransaction");

            migrationBuilder.DropTable(
                name: "WarehouseTransactionDetail");

            migrationBuilder.DropTable(
                name: "WareHouseTransfer");

            migrationBuilder.DropTable(
                name: "WarehouseTransferDetail");
        }
    }
}

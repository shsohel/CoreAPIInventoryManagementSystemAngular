using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CommonBLL.Enums
{
    public enum CommonData
    {
        lstNationalities = 1,
        lstCountries,
        lstDivisions,
        lstDistricts,
        lstUpazilas,
        lstPostOffices,
        lstProfessions,
        lstRelationShips,
        lstShiftSections,
        lstEmployees,
        lstShops,
        lstOrganizations
    }
    public enum OrganizationTypeEnum
    {
        Manufacturer = 1,
        Retailer,
    }
    public enum CitizenshipStatus
    {
        BIRTH = 1,
        PARENTAGE,
        MIGRATION,
        ATURALIZATION,
        OTHERS
    }
    public enum Gender
    {
        MALE = 1,
        FEMALE,
        OTHERS
    }
    public enum Religion
    {
        ISLAM = 1,
        CHRISTIANITY,
        HINDUISM,
        BUDDHISM,
        JAINISM,
        JUDAISM,
        SIKHISM,
        OTHERS
    }
    public enum BloodGroup
    {
        OPositive = 1,
        ONegative,
        APositive,
        ANegative,
        BPositive,
        BNegative,
        ABPositive,
        [Description("AB-")]
        ABNegative
    }
    public enum ApplicationStatus
    {
        Drafted = 1,
        Saved = 2,
        Submitted = 3,
        Forwarded = 4,
        Approved = 5,
        Rejected = 9
    }
    public enum StatusCode
    {
        Success = 1,
        Failed = 2,
        Exception = 3,
        NotFound = 4,
        UnAuthorized = 5
    }

    public enum Status
    {
        Active = 1,
        InActive = 2,
        Delete = 3
    }
    public enum IncentiveType
    {
        Commission = 1,
        Gratuity,
        Gift
    }
    public enum PaybleType
    {
        Once = 1,
        Yearly,
        Halfyearly,
        Quarterly,
        Monthly,
        Weekly,
        Daily,
        SpecificDate
    }
    public enum LoginStatus
    {
        LoggedIn = 1,
        LoggedOut = 2
    }
    public enum Actions
    {
        Insert = 1,
        Update,
        Delete,
        Search
    }

    public enum LogType
    {
        SystemLog
    }
    public enum Module
    {
        Web
    }
    public enum ExpenseType
    {
        GeneralExpense = 1,
        FixedExpense,
        PurchaseGoods,
        ProjectExpense,
        SalaryPayment,
    }

    public enum FeeCollectionStatus
    {
        Recieved = 1,
        Approved,
        Rejected,
    }
    public enum CollectionMode
    {
        Cash = 1,
        DepositeToBank,
        Online
    }
    public enum StudentStatus
    {
        Imported = 1,
        Student = 2,
        Rejected = 3,
        Transferred = 4,
        Expelled = 5
    }
    public enum ExpenseVoucherStatus
    {
        Created = 1,
        Initialized,
        Locked,
        Submitted,
        Audited,
        Approved
    }
    public enum FeeCollectionModeIfOnline //If Select Online then below items
    {
        bKash = 1,
        Rocket,
        iBanking,
        VISACard,
        MasterCard
    }
    public enum TransferStatus
    {
        Drafted = 1,
        Requested = 2,
        Rejected = 3,
        Approved = 4,
        Cancelled
    }
    public enum BankAccountType
    {
        [Description("Savings Account")]
        Savings = 1,
        [Description("Current Account")]
        Current = 2,
        [Description("Cash Credit CC")]
        CashCredit = 3
    }
    public enum AccountTransectionType
    {
        Debit = 1,
        Credit = 2
    }
    public enum DecisionMaking
    {
        [Description("Is loged in user responsible?")]
        IsLoggedinUserResponsible = 1
    }
    public enum InstitiuteType
    {
        Primary = 1,
        Secondary,
        Intermediate,
        Degree,
        Graduation,
        [Description("Post Graduation")]
        PostGraduation,
        University
    }
    public enum UserType
    {
        SuperAdmin = 1,
        Admin
    }
    public enum PayScaleGrade
    {
        Grade01 = 1,
        Grade02,
        Grade03,
        Grade04,
        Grade05,
        Grade06,
        Grade07,
        Grade08,
        Grade09,
        Grade10,
        Grade11,
        Grade12,
        Grade13,
        Grade14,
        Grade15,
        Grade16,
        Grade17,
        Grade18,
        Grade19,
        Grade20,
    }
    public enum EmployeeType
    {
        Teacher = 1,
        Librarian,
        Gurd
    }
    public enum EmployeeSalaryType
    {
        PayscaleHolder = 1,
        ContractBased,
        Hourly
    }
    public enum Relationship
    {
        Aunt = 1,
        Brother,
        [Description("Brother-In-Law")]
        BrotherInLaw,
        [Description("Business Partner")]
        BusinessPartner,
        Colleague,
        Cousin,
        Daughter,
        [Description("Daughter-In-Law")]
        DaughterInLaw,
        Employer,
        Father,
        [Description("Father-In-Law")]
        FatherInLaw,
        Friend,
        GrandFather,
        GrandMother,
        GrandSon,
        Mother,
        [Description("Mother-In-Law")]
        MotherInLaw,
        Nephew,
        Niece,
        Others,
        Sister,
        [Description("Sister-In-Law")]
        SisterInLaw,
        Son,
        [Description("Son-In-Law")]
        SonInLaw,
        Spouse,
        Uncle
    }
    public enum ClassRoutineStatus
    {
        Drafted = 1,
        Published
    }
    //public enum CommonData
    //{
    //    lstNationalities = 1,
    //    lstCountries,
    //    lstDivisions,
    //    lstDistricts,
    //    lstUpazilas,
    //    lstPostOffices,
    //    lstCamuses,
    //    lstProfessions,
    //    lstMonthlyIncomes,
    //    lstRelationShips,
    //    lstSessions,
    //    lstShiftSection,
    //    lstClassGroups,
    //    lstClassNames,
    //    lstClassSubjects,
    //    lstprevBoardUniversities,
    //    lstPrevInstitutes,
    //    lstInstitute,
    //    lstEmployeeDesignations,
    //    lstSubjects,
    //    lstClassPeriod,
    //    lstClassDays,
    //    lstTeachers,
    //}
}
